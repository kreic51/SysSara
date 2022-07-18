namespace SysSara.Services;

public interface IEmpleadosRepository : IGenericRepository<Empleado>
{
    
    Task<IEnumerable<Empleado>> GetAllWhitRelation();
    Task<EmpleadoDto> RellenarCatalogos(EmpleadoDto empleado);
    Task<List<EmpleadosListDto>> ObtenerTodosListDto();    
    Task<Empleado> ObtenerEmpleado(int id);
    Task<EmpleadoDto> ObtenerEmpleadoDto(int id);
    Task<bool> GrabarActualizarEmpleado(EmpleadoDto empleado);
    Task<bool> EliminarEmpleado(int id);
    Task<PaginaResultado<EmpleadosListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas);
}

public class EmpleadosRepository : GenericRepository<Empleado>, IEmpleadosRepository
{
    private readonly IMapper mapper;
    private readonly ICatalogosRepository catalogosRepository;

    public EmpleadosRepository(AppDbContext context, IMapper mapper, ICatalogosRepository catalogosRepository) : base(context)
    {
        this.mapper = mapper;
        this.catalogosRepository = catalogosRepository;
    }

    public async Task<IEnumerable<Empleado>> GetAllWhitRelation()
    {        
        return await _context.Empleados.ToListAsync();
    } 
    
    public async Task<List<EmpleadosListDto>> ObtenerTodosListDto()
    {
        List<EmpleadosListDto> empleados = new();

        try
        {
            empleados = await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Estatus)
                .ProjectTo<EmpleadosListDto>(mapper.ConfigurationProvider).ToListAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

        return empleados;
    }

    public async Task<Empleado> ObtenerEmpleado(int id)
    {   
        if(id == 0) return new Empleado();

        Empleado? emp;

        try{
            emp = await _context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);
        }catch
        {
            throw;
        }
        
        return emp;            
    }

    public async Task<EmpleadoDto> ObtenerEmpleadoDto(int id)
    {
        if (id == 0) return new EmpleadoDto();

        EmpleadoDto? emp;

        try
        {            
            emp = await _context.Empleados
                .ProjectTo<EmpleadoDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.EmpleadoId == id);
        }
        catch
        {
            throw;
        }

        return emp;
    }

    public async Task<PaginaResultado<EmpleadosListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas)
    {
        try
        {
            IQueryable<EmpleadosListDto> empleados = _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Estatus)
                .ProjectTo<EmpleadosListDto>(mapper.ConfigurationProvider)
                .OrderByDescending(e => e.EmpleadoId);

            if (!string.IsNullOrEmpty(filtro))
                empleados = empleados.Where(e => e.Apaterno.Contains(filtro) || e.Amaterno.Contains(filtro) || e.Nombre.Contains(filtro));

            PaginaResultado<EmpleadosListDto> resultados = new();

            resultados = await empleados.ObtenerListadoPaginadoAsync(pagina, filas);

            return resultados;
        }
        catch
        {
            throw;
        }
    }

    public async Task<EmpleadoDto> RellenarCatalogos(EmpleadoDto empleado)
    {
        try
        {
            //empleado.Departamentos = new SelectList(await _context.Departamentos.ToListAsync(), "DepartamentoId", "Descripcion");
            //empleado.TiposSangre = new SelectList(await _context.Tiposangres.ToListAsync(), "SangreId", "Descripcion");
            //empleado.Estados = new SelectList(await _context.Estados.ToListAsync(), "Cve_est", "Descripcion", "25");
            //empleado.Municipios = new SelectList(await _context.Municipios.Where(m => m.Cve_est == "25").ToListAsync(), "Cve_mun", "Descripcion", "006");            
            //empleado.Colonias = new SelectList(await _context.Colonias.Where(p => p.Cve_est == "25" && p.Cve_mun == "006").OrderBy(x => x.Descripcion).ToListAsync(), "Cve_col", "Descripcion", "0001");
            //empleado.Estatuses = new SelectList(await _context.Estatus.ToListAsync(), "EstatusId", "Descripcion", "V");
            //empleado.Sucursales = new SelectList(await _context.Sucursales.ToListAsync(), "SucursalId", "Nombre");

            empleado.Departamentos = new SelectList(await catalogosRepository.GetListDepartamentos(), "DepartamentoId", "Descripcion");
            empleado.TiposSangre = new SelectList(await catalogosRepository.GetListTiposangres(), "SangreId", "Descripcion");
            empleado.Estados = new SelectList(await catalogosRepository.GetListEstados(), "Cve_est", "Descripcion", "25");
            empleado.Municipios = await catalogosRepository.GetSelectListMunicipios();
            empleado.Colonias = await catalogosRepository.GetSelectListColonias();
            empleado.Estatuses = new SelectList(await _context.Estatus.ToListAsync(), "EstatusId", "Descripcion", "V");
            empleado.Sucursales = new SelectList(await _context.Sucursales.ToListAsync(), "SucursalId", "Nombre");
            if(empleado.EmpleadoId == 0)
            {
                empleado.MunicipioId = "006";
            }
        }
        catch
        {
            throw;
        }

        return empleado;
    }

    public async Task<bool> GrabarActualizarEmpleado(EmpleadoDto empleado)
    {
        try
        {
            var empexist = await _context.Empleados.AsTracking().FirstOrDefaultAsync(x => x.EmpleadoId == empleado.EmpleadoId);
            
            if (empexist is null)
            {
                var emp = mapper.Map<Empleado>(empleado);
                await _context.AddAsync(emp);
                return true;
            }

            empexist = mapper.Map(empleado, empexist);
        }
        catch
        {
            throw;
        }

        return true;
    }

    public async Task<bool> EliminarEmpleado(int id)
    {
        try
        {
            var empexist = await _context.Empleados.AsTracking().FirstOrDefaultAsync(x => x.EmpleadoId == id);

            if (empexist is not null)
            {
                _context.Remove(empexist);
                return true;
            }
        }
        catch
        {
            throw;
        }

        return true;
    }
}