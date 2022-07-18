namespace SysSara.Services;

public interface IUnitOfWork : IDisposable
{
    ICatalogosRepository Catalogos { get; }
    IEmpleadosRepository Empleados { get; }
    ICatProductosRepository CatProductos { get; }
    IProductosStockRepository ProductosStock { get; }
    Task<int> CompleteAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;

    public ICatalogosRepository Catalogos { get; private set; }
    public IEmpleadosRepository Empleados { get; private set; }
    public ICatProductosRepository CatProductos { get; private set; }
    public IProductosStockRepository ProductosStock { get; private set; }

    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;

        Catalogos = new CatalogosRepository(context);
        Empleados = new EmpleadosRepository(context, mapper, Catalogos);
        CatProductos = new CatProductosRepository(context, mapper);
        ProductosStock = new ProductosStockRepository(context, mapper);
    }

    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }
    public void Dispose()
    {
        context.Dispose();
    }
}