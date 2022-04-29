namespace SysSara.Services;

public class CatalogosRepository : ICatalogosRepository
{
    protected readonly AppDbContext _context;

    public CatalogosRepository(AppDbContext context)
    {
        _context = context;    
    }    

    public async Task<Departamento> GetDepartamento(int id)
    {
        try{
            return await _context.Departamentos.Where(x => x.DepartamentoId == id).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<Estado> GetEstado(string estado)
    {
        try{
            return await _context.Estados.Where(x => x.Cve_est == estado).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Departamento>> GetListDepartamentos()
    {
        try{
            return await _context.Departamentos.ToListAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Estado>> GetListEstados()
    {
        try{
            return await _context.Estados.ToListAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Municipio>> GetListMunicipios(string estado)
    {
        try{
            return await _context.Municipios.Where(x => x.Cve_est == estado).ToListAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Poblacion>> GetListPoblaciones(string estado, string municipio)
    {
        try{
            return await _context.Poblaciones.Where(x => x.Cve_est == estado && x.Cve_mun == municipio).ToListAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Rol>> GetListRol()
    {
        try{
            return await _context.catRoles.ToListAsync();
        }catch{
            throw;
        }
    }

    public async Task<Municipio> GetMunicipio(string estado, string municipio )
    {
        try{            
            return await _context.Municipios.Where(x => x.Cve_est == estado && x.Cve_mun == municipio).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<Poblacion> GetPoblacion(string estado, string municipio, string poblacion)
    {
        try{
            return await _context.Poblaciones.Where(x => x.Cve_est == estado && x.Cve_mun == municipio && x.Cve_pob == poblacion).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<Rol> GetRol(int id)
    {
        try{
            return await _context.catRoles.Where(x => x.RolId == id).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<Tiposangre> GetTiposangre(int id)
    {
        try{
            return await _context.Tiposangres.Where(x => x.SangreId == id).FirstOrDefaultAsync();
        }catch{
            throw;
        }
    }

    public async Task<IEnumerable<Tiposangre>> GetListTiposangres()
    {
        try{
            return await _context.Tiposangres.ToListAsync();
        }catch{
            throw;
        }
    }
}