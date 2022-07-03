//namespace SysSara.Controllers;

//public class RHController : Controller
//{
//    private readonly ILogger<RHController> _logger;
//    private readonly AppDbContext context;
//    private readonly IMapper mapper;

//    public RHController(ILogger<RHController> logger, AppDbContext context, IMapper mapper)
//    {
//        _logger = logger;
//        this.context = context;
//        this.mapper = mapper;
//    }

//    public async Task<IActionResult> Empleados()
//    {        
//        ViewBag.MenuActivo = "M4";
//        ViewBag.MenuActivoH = "M4H1";
        
//        List<EmpleadosListDto> lEmpleados = new();
        
    
//        try
//        {
//            lEmpleados = await context.Empleados.ProjectTo<EmpleadosListDto>(mapper.ConfigurationProvider).ToListAsync();            

//        }catch(Exception ex){
//            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);            
//        }

//        return View(lEmpleados.ToList());
//    }


    
//}