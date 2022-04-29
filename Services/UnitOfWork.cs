namespace SysSara.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IEmpleadosRepository Empleados { get; private set; }
    public ICatalogosRepository Catalogos { get; private set; }
    public IDomiciliosRepository Domicilios { get; private set; }
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Empleados = new EmpleadosRepository(_context);
        Catalogos = new CatalogosRepository(_context);
        Domicilios = new DomiciliosRepository(_context);
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