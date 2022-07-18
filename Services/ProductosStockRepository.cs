namespace SysSara.Services;

public interface IProductosStockRepository
{
    Task<PaginaResultado<ProductoStockListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas);
}

public class ProductosStockRepository : IProductosStockRepository
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;

    public ProductosStockRepository(AppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<List<ProductoStockListDto>> ObtenerListado()
    {
        List<ProductoStockListDto> lista = new List<ProductoStockListDto>();

        try
        {
            lista = await context.ProductosStock
                .Include(p => p.Sucursal)
                .Include(p => p.Producto)
                .Include(p => p.SubProducto)
                .Include(p => p.Estatus)
                .ProjectTo<ProductoStockListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return lista;
        }
        catch
        {
            throw;
        }
    }

    public async Task<PaginaResultado<ProductoStockListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas)
    {
        try
        {
            IQueryable<ProductoStockListDto> productos = context.ProductosStock
                .Include(p => p.Sucursal)
                .Include(p => p.Producto)
                .Include(p => p.SubProducto)
                .Include(p => p.Estatus)
                .ProjectTo<ProductoStockListDto>(mapper.ConfigurationProvider)
                .OrderByDescending(p => p.FechaRegistro);

            if (!string.IsNullOrEmpty(filtro))
                productos = productos.Where(p => p.Producto.Contains(filtro) || p.SubProducto.Contains(filtro));

            PaginaResultado<ProductoStockListDto> resultado = new();

            resultado = await productos.ObtenerListadoPaginadoAsync(pagina, filas);

            return resultado;

        }
        catch
        {
            throw;
        }
    }
}
