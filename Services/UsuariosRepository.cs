namespace SysSara.Services;

public interface IUsuariosRepository
{
    Task<Usuario> ObtenerUsuarioPorId(string Id);
    string ObternerUsuarioIdActual();
    Task<Usuario> ValidarUsuario(string Id, string pass);
}

public class UsuariosRepository : IUsuariosRepository
{
    private readonly AppDbContext context;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UsuariosRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<Usuario> ObtenerUsuarioPorId(string Id)
    {
        return await context.Usuarios
            .Include(u => u.Empleado)
                .ThenInclude(e => e.Departamento)
            .Include(u => u.Roles)
                .ThenInclude(r => r.Rol)
            .FirstOrDefaultAsync(u => u.UsuarioId == Id);       
    }

    public async Task<Usuario> ValidarUsuario(string Id, string pass)
    {
        var usuario = await ObtenerUsuarioPorId(Id);

        if (usuario != null && usuario.Password == Encrypt.GetSHA256(pass))
            return usuario;

        return null;
    }

    public string ObternerUsuarioIdActual()
    {
        var usuarioId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UsuarioId").Value;
        return usuarioId;
    }
}
