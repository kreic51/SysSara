namespace SysSara.Services;

public interface IUnitOfWork : IDisposable
{
    IEmpleadosRepository Empleados { get; }
    ICatalogosRepository Catalogos { get; }
    Task<int> CompleteAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper mapper;

    public IEmpleadosRepository Empleados { get; private set; }
    public ICatalogosRepository Catalogos { get; private set; }
    
    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;
        Empleados = new EmpleadosRepository(_context, mapper);
        Catalogos = new CatalogosRepository(_context);        
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