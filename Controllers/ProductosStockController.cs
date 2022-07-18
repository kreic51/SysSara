namespace SysSara.Controllers;

public class ProductosStockController : Controller
{
    private readonly ILogger<ProductosStockController> logger;
    private readonly AppDbContext context;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductosStockController(ILogger<ProductosStockController> logger, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.logger = logger;
        this.context = context;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ListadoProductosStock(string? palabraBuscada = null, int Pagina = 1, int Filas = 10)
    {
        ViewBag.MenuActivo = "M2";
        ViewBag.MenuActivoH = "M2H1";

        ViewData["Filtro"] = palabraBuscada;

        PaginaResultado<ProductoStockListDto> productos = new();

        try
        {
            productos = await unitOfWork.ProductosStock.ObtenerListadoPaginadoDto(palabraBuscada, Pagina, Filas);
        }
        catch(Exception ex)
        {
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);
        }

        return View(productos);
    }

}
