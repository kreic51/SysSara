namespace SysSara.Controllers;

[Authorize]
public class EmpleadosController : Controller
{
    private readonly ILogger<EmpleadosController> logger;
    private readonly AppDbContext context;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmpleadosController(ILogger<EmpleadosController> logger, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.logger = logger;
        this.context = context;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
        
    [HttpGet]
    public async Task<IActionResult> ListadoEmpleados(string? palabraBuscada = null, int Pagina = 1, int Filas = 10)
    {
        ViewBag.MenuActivo = "M4";
        ViewBag.MenuActivoH = "M4H1";

        ViewData["Filtro"] = palabraBuscada;

        PaginaResultado<EmpleadosListDto> lEmpleados = new();

        try
        {
            lEmpleados = await unitOfWork.Empleados.ObtenerListadoPaginadoDto(palabraBuscada, Pagina, Filas);
        }
        catch (Exception ex)
        {
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);
        }

        return View(lEmpleados);
    }

    [HttpGet]
    public async Task<IActionResult> AgregarEmpleado(int Id = 0)
    {
        ViewBag.MenuActivo = "M4";
        ViewBag.MenuActivoH = "M4H1";

        EmpleadoDto empleado = new();

        try
        {
            if(Id != 0)
            {                
                empleado = await unitOfWork.Empleados.ObtenerEmpleadoDto(Id);
            }
            empleado = await unitOfWork.Empleados.RellenarCatalogos(empleado);
        }
        catch (Exception ex)
        {
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);
        }

        return View(empleado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<JsonResult> AgregarEmpleado(EmpleadoDto empleado)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, titulo = "Agregar Empleado", mensaje = "Existe un error en los campos, favor de revisar", icono = IconError.Warning });
        }

        try
        {
            empleado.UserRegistro = User.Claims.FirstOrDefault(c => c.Type == "UsuarioId").Value;
            empleado.FechaRegistro = DateTime.Now;
            await unitOfWork.Empleados.GrabarActualizarEmpleado(empleado);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Agregar Empleado", mensaje = ex.Message, icono = IconError.Info });
        }

        return Json(new { success = true, titulo = "Agregar Empleado", mensaje = "Se guardó el Empleado correctamente", icono = IconError.Info });
    }

    [HttpDelete]
    public async Task<IActionResult> EliminarEmpleado(int id)
    {
        try
        {
            await unitOfWork.Empleados.EliminarEmpleado(id);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Eliminar Empleado", mensaje = ex.Message, icono = IconError.Info });
        }

        return Json(new { success = true, titulo = "Eliminar Empleado", mensaje = "Se eliminó el Empleado correctamente", icono = IconError.Info });
    }

    [HttpGet]
    public async Task<JsonResult> GetMunicipios(string estado)
    {
        SelectList resultado;

        try
        {
            resultado = await unitOfWork.Catalogos.GetSelectListMunicipios(estado);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Error", mensaje = ex.Message, icono = IconError.Warning });
        }

        return Json(resultado);
    }

    [HttpGet]
    public async Task<JsonResult> GetColonias(string estado, string municipio)
    {
        SelectList resultado;

        try
        {
            resultado = await unitOfWork.Catalogos.GetSelectListColonias(estado, municipio);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Error", mensaje = ex.Message, icono = IconError.Warning });
        }

        return Json(resultado);
    }

}
