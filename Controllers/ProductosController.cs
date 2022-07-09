namespace SysSara.Controllers;

public class ProductosController : Controller
{
    private readonly ILogger<EmpleadosController> logger;
    private readonly AppDbContext context;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductosController(ILogger<EmpleadosController> logger, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.logger = logger;
        this.context = context;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Listado(string? palabraBuscada = null, int Pagina = 1, int Filas = 10)
    {
        ViewBag.MenuActivo = "M5";
        ViewBag.MenuActivoH = "M5H1";

        ViewData["Filtro"] = palabraBuscada;
                
        PaginaResultado<ProductosListDto> paginaResultado = new();

        try
        {
            if (!string.IsNullOrEmpty(palabraBuscada))
            {
                paginaResultado = await unitOfWork.CatProductos.ObtenerListadoPaginadoDto(palabraBuscada, Pagina, Filas);
            }
            else
            {
                paginaResultado = await unitOfWork.CatProductos.ObtenerListadoPaginadoDto(palabraBuscada, Pagina, Filas);
            }
        }
        catch (Exception ex)
        {
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);
        }

        return View(paginaResultado);
    }

    [HttpGet]
    public async Task<IActionResult> Agregar(int Id = 0)
    {
        ViewBag.MenuActivo = "M5";
        ViewBag.MenuActivoH = "M5H1";

        ProductoDto producto = new();

        try
        {
            if (Id != 0)
            {
                producto = await unitOfWork.CatProductos.ObtenerDtoPorId(Id);
            }
            producto = await unitOfWork.CatProductos.RellenarCatalogos(producto);
        }
        catch (Exception ex)
        {
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);
        }

        return View(producto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<JsonResult> Agregar(ProductoDto producto)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, titulo = "Agregar Producto", mensaje = "Existe un error en los campos, favor de revisar", icono = IconError.Warning });
        }

        try
        {
            await unitOfWork.CatProductos.GrabarActualizar(producto);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Agregar Producto", mensaje = ex.Message, icono = IconError.Info });
        }

        return Json(new { success = true, titulo = "Agregar Producto", mensaje = "Se guardó correctamente", icono = IconError.Info });
    }

    [HttpDelete]
    public async Task<IActionResult> Eliminar(int id)
    {
        try
        {
            await unitOfWork.CatProductos.Eliminar(id);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return Json(new { success = false, titulo = "Eliminar Producto", mensaje = ex.Message, icono = IconError.Info });
        }

        return Json(new { success = true, titulo = "Eliminar Producto", mensaje = "Se eliminó el Empleado correctamente", icono = IconError.Info });
    }

}
