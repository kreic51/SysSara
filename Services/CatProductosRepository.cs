namespace SysSara.Services;

public interface ICatProductosRepository : IGenericRepository<Empleado>
{
    Task<bool> Eliminar(int id);
    Task<bool> GrabarActualizar(ProductoPruebaDto producto);
    Task<ProductoPruebaDto> ObtenerDtoPorId(int id);
    Task<List<ProductosPruebaListDto>> ObtenerListadoDto();
    Task<List<ProductosPruebaListDto>> ObtenerListadoDto(string filtro);
    Task<PaginaResultado<ProductosPruebaListDto>> ObtenerListadoPaginadoDto(string filtro, int pagina, int filas);
    Task<ProductoPrueba> ObtenerPorId(int id);
    Task<ProductoPruebaDto> RellenarCatalogos(ProductoPruebaDto producto);
}

public class CatProductosRepository : ICatProductosRepository
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;
    

    public CatProductosRepository(AppDbContext context, IMapper mapper) 
    {
        this.context = context;
        this.mapper = mapper;        
    }

    public async Task<ProductoPrueba> ObtenerPorId(int id)
    {
        if (id == 0)
            return new ProductoPrueba();

        ProductoPrueba? prod;

        try
        {
            prod = await context.ProductosPrueba.FirstOrDefaultAsync(p => p.Id == id);
            return prod;
        }
        catch
        {
            throw;
        }        
    }

    public async Task<ProductoPruebaDto> ObtenerDtoPorId(int id)
    {
        try
        {
            ProductoPruebaDto? prod = await context.ProductosPrueba
                .ProjectTo<ProductoPruebaDto>(mapper.ConfigurationProvider)                
                .FirstOrDefaultAsync(p => p.Id == id);

            return prod;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<ProductosPruebaListDto>> ObtenerListadoDto()
    {
        try
        {
            List<ProductosPruebaListDto> productos = await context.ProductosPrueba
                .Include(p => p.Estatus)
                .ProjectTo<ProductosPruebaListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return productos;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<ProductosPruebaListDto>> ObtenerListadoDto(string filtro)
    {
        try
        {
            List<ProductosPruebaListDto> productos = await context.ProductosPrueba
                .Include(p => p.Estatus)
                .Where(p => p.Nombre.Contains(filtro))
                .ProjectTo<ProductosPruebaListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return productos;
        }
        catch
        {
            throw;
        }
    }

    public async Task<PaginaResultado<ProductosPruebaListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas)
    {
        try
        {
            IQueryable<ProductosPruebaListDto> productos = context.ProductosPrueba
                .Include(p => p.Estatus)
                .ProjectTo<ProductosPruebaListDto>(mapper.ConfigurationProvider)
                .OrderByDescending(p => p.Id);

            if (!string.IsNullOrEmpty(filtro))
                productos = productos.Where(p => p.Nombre.Contains(filtro));
                

            PaginaResultado<ProductosPruebaListDto> resultados = new();

            resultados = await productos.ObtenerListadoPaginadoAsync(pagina, filas);

            return resultados;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> GrabarActualizar(ProductoPruebaDto producto)
    {
        try
        {
            var existeEntidad = await context.ProductosPrueba.AsTracking()
                .FirstOrDefaultAsync(x => x.Id == producto.Id);

            if (existeEntidad is null)
            {
                var prod = mapper.Map<ProductoPrueba>(producto);
                
                prod.FechaRegistro = DateTime.Now;
                prod.FechaEstatus = DateTime.Now;

                await context.AddAsync(prod);
                return true;
            }

            existeEntidad = mapper.Map(producto, existeEntidad);
            existeEntidad.FechaEstatus = DateTime.Now;
        }
        catch
        {
            throw;
        }

        return true;
    }

    public async Task<bool> Eliminar(int id)
    {
        try
        {
            var existeEntidad = await context.ProductosPrueba.AsTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existeEntidad is not null)
            {
                context.Remove(existeEntidad);                
            }

            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<ProductoPruebaDto> RellenarCatalogos(ProductoPruebaDto producto)
    {
        try
        {
            producto.Estatuses = new SelectList(await context.Estatus.ToListAsync(), "EstatusId", "Descripcion", "V");

            return producto;
        }
        catch
        {
            throw;
        }
    }



}
