namespace SysSara.Services;

public interface ICatProductosRepository : IGenericRepository<Empleado>
{
    Task<bool> Eliminar(int id);
    Task<bool> GrabarActualizar(ProductoDto producto);
    Task<ProductoDto> ObtenerDtoPorId(int id);
    Task<List<ProductosListDto>> ObtenerListadoDto();
    Task<List<ProductosListDto>> ObtenerListadoDto(string filtro);
    Task<PaginaResultado<ProductosListDto>> ObtenerListadoPaginadoDto(string filtro, int pagina, int filas);
    Task<Producto> ObtenerPorId(int id);
    Task<ProductoDto> RellenarCatalogos(ProductoDto producto);
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

    public async Task<Producto> ObtenerPorId(int id)
    {
        if (id == 0)
            return new Producto();

        Producto? prod;

        try
        {
            prod = await context.Productos.FirstOrDefaultAsync(p => p.Id == id);
            return prod;
        }
        catch
        {
            throw;
        }        
    }

    public async Task<ProductoDto> ObtenerDtoPorId(int id)
    {
        try
        {
            ProductoDto? prod = await context.Productos
                .ProjectTo<ProductoDto>(mapper.ConfigurationProvider)                
                .FirstOrDefaultAsync(p => p.Id == id);

            return prod;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<ProductosListDto>> ObtenerListadoDto()
    {
        try
        {
            List<ProductosListDto> productos = await context.Productos
                .Include(p => p.Estatus)
                .ProjectTo<ProductosListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return productos;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<ProductosListDto>> ObtenerListadoDto(string filtro)
    {
        try
        {
            List<ProductosListDto> productos = await context.Productos
                .Include(p => p.Estatus)
                .Where(p => p.Nombre.Contains(filtro))
                .ProjectTo<ProductosListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return productos;
        }
        catch
        {
            throw;
        }
    }

    public async Task<PaginaResultado<ProductosListDto>> ObtenerListadoPaginadoDto(string? filtro, int pagina, int filas)
    {
        try
        {
            IQueryable<ProductosListDto> productos = context.Productos
                .Include(p => p.Estatus)
                .ProjectTo<ProductosListDto>(mapper.ConfigurationProvider)
                .OrderByDescending(p => p.Id);

            if (!string.IsNullOrEmpty(filtro))
                productos = productos.Where(p => p.Nombre.Contains(filtro));
                

            PaginaResultado<ProductosListDto> resultados = new();

            resultados = await productos.ObtenerListadoPaginadoAsync(pagina, filas);

            return resultados;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> GrabarActualizar(ProductoDto producto)
    {
        try
        {
            var existeEntidad = await context.Productos.AsTracking()
                .FirstOrDefaultAsync(x => x.Id == producto.Id);

            if (existeEntidad is null)
            {
                var prod = mapper.Map<Producto>(producto);
                prod.UsuarioId = 1;
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
            var existeEntidad = await context.Productos.AsTracking()
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

    public async Task<ProductoDto> RellenarCatalogos(ProductoDto producto)
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
