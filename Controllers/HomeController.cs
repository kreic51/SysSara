namespace SysSara.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;        
    }

    public IActionResult Index()
    {
        ViewBag.MenuActivo = "M1";
        ViewBag.MenuActivoH = "M1H1";
        return View();
    }
    
    public IActionResult V404()
    {
        return View();
    }

    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
