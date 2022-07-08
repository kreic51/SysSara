namespace SysSara.Services;

public interface IUnitOfWork : IDisposable
{
    ICatalogosRepository Catalogos { get; }
    IEmpleadosRepository Empleados { get; }    
    Task<int> CompleteAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper mapper;

    public ICatalogosRepository Catalogos { get; private set; }
    public IEmpleadosRepository Empleados { get; private set; }    

    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;        
        Catalogos = new CatalogosRepository(_context);
        Empleados = new EmpleadosRepository(_context, mapper, Catalogos);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}