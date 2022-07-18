using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SysSara.Controllers;

public class AccountController : Controller
{
    private readonly IUsuariosRepository usuariosRepository;

    public AccountController(IUsuariosRepository usuariosRepository)
    {
        this.usuariosRepository = usuariosRepository;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;

        return RedirectToAction("Validate", "Account", new { Id = "ADMIN", pass = "123" });

        //return View();
    }

    //[HttpPost("Account/Login")]
    [AcceptVerbs("Get", "Post")]

    public async Task<IActionResult> Validate(string Id, string pass)
    {
        //ViewData["ReturnUrl"] = u.returnUrl;

        if (!ModelState.IsValid)
        {
            return View("Login");
        }

        //var User = _userRepository.GetUser(u.Usuario, u.Password);
        var usuario = await usuariosRepository.ValidarUsuario(Id, pass);

        if (usuario != null)
        {
            if (!String.IsNullOrEmpty(usuario.UsuarioId))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("UsuarioId", usuario.UsuarioId));
                claims.Add(new Claim("Departamento", usuario.Empleado.Departamento.Descripcion));
                claims.Add(new Claim(ClaimTypes.Name, usuario.Empleado.Nombre));
                claims.Add(new Claim("Foto", usuario.Empleado.Foto ?? "default.png"));
                foreach (Roles Rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, Rol.Rol.Descripcion));
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };
                //if (!u.Recordar)
                //{
                //    //authProperties.IsPersistent = true;
                //    //authProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(120);
                //    authProperties.ExpiresUtc = DateTime.UtcNow.AddSeconds(20);
                //}

                await HttpContext.SignInAsync(claimsPrincipal, authProperties);

                //return Redirect(u.returnUrl);
                return Redirect("/Home/index");
            }
        }

        TempData["error"] = "Usuario o contraseña incorrecta.";
        return View("Login");
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/Home/index");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
