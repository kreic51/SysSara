namespace SysSara.Controllers;

public class RHController : Controller
{
    private readonly ILogger<RHController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _catContext;
    
    public RHController(ILogger<RHController> logger, IUnitOfWork unitOfWork, AppDbContext context)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _catContext = context;
    }

/*     public async Task<IActionResult> Empleados(string sortOrder, string searchString, MensajeDto? mens = null)
    {        
        ViewBag.MenuActivo = "M4";
        ViewBag.MenuActivoH = "M4H1";

        ViewBag.APaternoSortParm = String.IsNullOrEmpty(sortOrder) ? "Apaterno_desc" : "";
        ViewBag.AMaternoSortParm = sortOrder == "Amaterno" ? "Amaterno_desc" : "Amaterno";

        if(mens != null) ViewData["Mensaje"] = mens;

        List<EmpleadosListDto> lEmpleados = new();
    
        try{
            
            IEnumerable<Empleado> Empleados =  await _unitOfWork.Empleados.GetAllWhitRelation();

           /*  foreach(var emp in Empleados){
                lEmpleados.Add(
                    new EmpleadosListDto(){
                        EmpleadoId = emp.EmpleadoId,
                        Apaterno = emp.Apaterno,
                        Amaterno = emp.Amaterno,
                        Nombre = emp.Nombre,
                        Estatus = emp.Estatus,
                        Descripcion = await _catContext.Departamentos.Where(x => x.DepartamentoId == emp.DepartamentoId).Select(x => x.Descripcion).SingleOrDefaultAsync(),
                    }
                );
            } */

            /* lEmpleados =  (from emp in Empleados
                        join dep in _catContext.Departamentos on emp.DepartamentoId equals dep.DepartamentoId 
                        select new EmpleadosListDto() {
                            EmpleadoId = emp.EmpleadoId,
                            Apaterno = emp.Apaterno,
                            Amaterno = emp.Amaterno,
                            Nombre = emp.Nombre,
                            Estatus = emp.Estatus,
                            Descripcion = dep.Descripcion,}
                        ).ToList(); */

            /* lEmpleados = Empleados
                        .Join(_catContext.Departamentos, 
                            e => e.DepartamentoId, 
                            d => d.DepartamentoId, 
                            (e, d) => new EmpleadosListDto
                                {
                                    EmpleadoId = e.EmpleadoId,
                                    Apaterno = e.Apaterno,
                                    Amaterno = e.Amaterno,
                                    Nombre = e.Nombre,
                                    Estatus = e.Estatus,
                                    Descripcion = d.Descripcion
                                }
                        ).ToList(); */
                                
            /*var llEmpleados = Empleados
                        .Join(_catContext.Departamentos, 
                            e => e.DepartamentoId, 
                            d => d.DepartamentoId, 
                            (e, d) => new EmpleadosListDto
                                {
                                    EmpleadoId = e.EmpleadoId,
                                    Apaterno = e.Apaterno,
                                    Amaterno = e.Amaterno,
                                    Nombre = e.Nombre,
                                    Estatus = e.Estatus,
                                    Descripcion = d.Descripcion
                                }
                        );
            if (!String.IsNullOrEmpty(searchString))
            {
                llEmpleados = llEmpleados.Where(e => e.Apaterno.Contains(searchString)
                                            || e.Amaterno.Contains(searchString)
                                            || e.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Apaterno_desc":
                    llEmpleados = llEmpleados.OrderByDescending(e => e.Apaterno);
                    break;
                case "Amaterno":
                    llEmpleados = llEmpleados.OrderBy(e => e.Amaterno);
                    break;
                case "Amaterno_desc":
                    llEmpleados = llEmpleados.OrderByDescending(e => e.Amaterno);
                    break;
                default:
                    llEmpleados = llEmpleados.OrderBy(e => e.Apaterno);
                    break;
            }




            lEmpleados = llEmpleados.ToList();

        }catch(Exception ex){
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);            
        }

        return View(lEmpleados);
    } */

    public async Task<IActionResult> Empleados(string sortOrder, string currentFilter, string searchString, MensajeDto? mens = null, int? page = 1)
    {        
        ViewBag.MenuActivo = "M4";
        ViewBag.MenuActivoH = "M4H1";

        ViewBag.CurrentSort = sortOrder;
        ViewBag.APaternoSortParm = String.IsNullOrEmpty(sortOrder) ? "Apaterno_desc" : "";
        ViewBag.AMaternoSortParm = sortOrder == "Amaterno" ? "Amaterno_desc" : "Amaterno";
        
        if (searchString != null)
        {
            page = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewBag.CurrentFilter = searchString;


        if(mens != null) ViewData["Mensaje"] = mens;

        List<EmpleadosListDto> lEmpleados = new();
    
        try{
            
            IEnumerable<Empleado> Empleados =  await _unitOfWork.Empleados.GetAllWhitRelation();
                                
            var llEmpleados = Empleados
                        .Join(_catContext.Departamentos, 
                            e => e.DepartamentoId, 
                            d => d.DepartamentoId, 
                            (e, d) => new EmpleadosListDto
                                {
                                    EmpleadoId = e.EmpleadoId,
                                    Apaterno = e.Apaterno,
                                    Amaterno = e.Amaterno,
                                    Nombre = e.Nombre,
                                    Estatus = e.Estatus,
                                    Descripcion = d.Descripcion
                                }
                        );
            //var llEmpleados = _catContext.Empleados.Include(x => x.Domicilio);

                        
            if (!String.IsNullOrEmpty(searchString))
            {
                llEmpleados = llEmpleados.Where(e => e.Apaterno.Contains(searchString)
                                            || e.Amaterno.Contains(searchString)
                                            || e.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Apaterno_desc":
                    llEmpleados = llEmpleados.OrderByDescending(e => e.Apaterno);
                    break;
                case "Amaterno":
                    llEmpleados = llEmpleados.OrderBy(e => e.Amaterno);
                    break;
                case "Amaterno_desc":
                    llEmpleados = llEmpleados.OrderByDescending(e => e.Amaterno);
                    break;
                default:
                    llEmpleados = llEmpleados.OrderBy(e => e.Apaterno);
                    break;
            }
           
            
            lEmpleados = llEmpleados.ToList();
            

        }catch(Exception ex){
            ViewData["Mensaje"] = new MensajeDto(true, "Error", ex.Message, IconError.Error);            
        }

        int pageSize = 10;
        int pageNumber = (page ?? 1);
            //lEmpleados.Skip((pageNumber) * pageSize).Take(pageSize).ToList()
        return View(lEmpleados);
    }


    [HttpGet]
    public async Task<IActionResult> AddEmpleado(int id)
    {
        EmpleadoDto empleado = new();

        try{
            var emp = await _unitOfWork.Empleados.GetByIdWhitRelation(id);
            if(emp.EmpleadoId != 0){
                empleado = new EmpleadoDto{
                    Amaterno = emp.Amaterno,
                    Apaterno = emp.Apaterno,
                    Nombre = emp.Nombre,
                    FechaNacimiento = emp.FechaNacimiento,
                    Curp = emp.Curp,
                    SeguridadSocial = emp.SeguridadSocial,
                    Telefono = emp.Telefono,
                    Celular = emp.Celular,
                    Rfc = emp.Rfc,
                    Categoria = emp.Categoria,
                    TipoSangre = emp.TipoSangre,
                    FechaIngreso = emp.FechaIngreso,
                    Estatus = emp.Estatus,
                    Usuario = emp.Usuario,
                    Contraseña = emp.Contraseña,
                    DepartamentoId = emp.DepartamentoId,                        
                    Calle = emp.Domicilio.Calle,
                    NoExt = emp.Domicilio.NoExt,
                    NoInt = emp.Domicilio.NoInt,
                    Colonia = emp.Domicilio.Colonia,
                    Poblacion = emp.Domicilio.PoblacionId,
                    Municipio = emp.Domicilio.MunicipioId,
                    Estado = emp.Domicilio.EstadoId,
                    Rol = emp.Roles.Select(x => x.Rol).ToList(),
                };
            }
            var cPob = new SelectList(_catContext.Poblaciones.ToList(),"Cve_pob","Descripcion");            
            empleado.Departamentos = new SelectList(_catContext.Departamentos.ToList(),"DepartamentoId","Descripcion");
            empleado.Roles = new SelectList(_catContext.catRoles.ToList(),"RolId","Descripcion");
            empleado.Estados = new SelectList(_catContext.Estados.ToList(),"Cve_est","Descripcion");
            empleado.Municipios = new SelectList(_catContext.Municipios.ToList(),"Cve_mun","Descripcion");
            empleado.Poblaciones = cPob;
            empleado.Colonias = cPob;
            empleado.TiposSangre = new SelectList(_catContext.Tiposangres.ToList(),"SangreId","Descripcion");
        }catch(Exception ex){
            Console.WriteLine(ex);
        }

        return View(empleado);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmpleado(EmpleadoDto emp)
    {
        Empleado empleado = new Empleado{
            Amaterno = emp.Amaterno,
            Apaterno = emp.Apaterno,
            Nombre = emp.Nombre,
            FechaNacimiento = emp.FechaNacimiento,
            Curp = emp.Curp,
            SeguridadSocial = emp.SeguridadSocial,
            Telefono = emp.Telefono,
            Celular = emp.Celular,
            Rfc = emp.Rfc,
            Categoria = emp.Categoria,
            TipoSangre = emp.TipoSangre,
            FechaIngreso = emp.FechaIngreso,
            Estatus = emp.Estatus,
            Usuario = emp.Usuario,
            Contraseña = emp.Contraseña,
            DepartamentoId = emp.DepartamentoId,
            Domicilio = new Domicilio{
                Calle = emp.Calle,
                NoExt = emp.NoExt,
                NoInt = emp.NoInt,
                Colonia = emp.Colonia,
                PoblacionId = emp.Poblacion,
                MunicipioId = emp.Municipio,
                EstadoId = emp.Estado,
            },
        };        
        empleado.Roles = new List<Roles>();

        for(int i = 0; i < emp.Rol.Count(); i++ ){
            empleado.Roles.Add(new Roles{ RolId = i + 1, Rol = emp.Rol[i], UserRegistro = "Admin" });
        };
        

        try{
            await _unitOfWork.Empleados.Add(empleado);            
            await _unitOfWork.CompleteAsync();
            emp.Mensaje = new MensajeDto(true, "Informacion", "Empleado guardado correctamente.", IconError.Info);
        }catch(Exception ex){
            emp.Mensaje = new MensajeDto(true, "Error", ex.Message, IconError.Error);            
        }

        var cPob = new SelectList(_catContext.Poblaciones.ToList(),"Cve_pob","Descripcion");            
        emp.Departamentos = new SelectList(_catContext.Departamentos.ToList(),"DepartamentoId","Descripcion");
        emp.Roles = new SelectList(_catContext.catRoles.ToList(),"RolId","Descripcion");
        emp.Estados = new SelectList(_catContext.Estados.ToList(),"Cve_est","Descripcion");
        emp.Municipios = new SelectList(_catContext.Municipios.ToList(),"Cve_mun","Descripcion");
        emp.Poblaciones = cPob;
        emp.Colonias = cPob;
        emp.TiposSangre = new SelectList(_catContext.Tiposangres.ToList(),"SangreId","Descripcion");
        
        return View(emp);
    }

    public async Task<IActionResult> DeleteEmpleado(int id) {
        
        MensajeDto? mensaje = new();

        try{
            Empleado emp = await _unitOfWork.Empleados.GetById(id);
            if(emp != null){
                _unitOfWork.Empleados.Remove(emp);
                await _unitOfWork.CompleteAsync();
                mensaje = new MensajeDto(true, "Informacion", "El empleado se eliminó correctamente.", IconError.Success);            
            }
        }catch(Exception ex){
            mensaje = new MensajeDto(true, "Error", ex.Message, IconError.Error);            
        }

        return RedirectToAction("Empleados", mensaje);
    }
}