namespace SysSara.Data;

/* public abstract class PagedResultBase
{
    public int CurrentPage { get; set; } 
    public int PageCount { get; set; } 
    public int PageSize { get; set; } 
    public int RowCount { get; set; }
 
    public int FirstRowOnPage
    {
 
        get { return (CurrentPage - 1) * PageSize + 1; }
    }
 
    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * PageSize, RowCount); }
    }
} */
 

public abstract class PaginaResultadoBase
{
    public int FilasPagina { get; set; } = 0;
    public int PaginaActual { get; set; } = 0;
    public int TotalFilas { get; set; }
    public int TotalPaginas => (int)Math.Ceiling(decimal.Divide(TotalFilas, FilasPagina)) == 0 ? 1 : (int)Math.Ceiling(decimal.Divide(TotalFilas, FilasPagina));
    public bool Anterior => PaginaActual > 1;
    public bool Siguente => PaginaActual < TotalPaginas;
    public bool Primero => PaginaActual != 1;
    public bool Ultimo => PaginaActual != TotalPaginas;
    public int PaginaInicial => (TotalPaginas > 3 && PaginaActual > 1 ? (PaginaActual - 1 > TotalPaginas - 2 ? TotalPaginas - 2 : PaginaActual - 1) : 1);
    public int PaginaFinal => (TotalPaginas > 3 && (PaginaActual + 1) < TotalPaginas ? (PaginaActual + 1 < 3 ? 3 : PaginaActual + 1) : TotalPaginas);
    //public int PaginaInicial => (TotalPaginas > 10 && PaginaActual > 5 ? (PaginaActual - 5 > TotalPaginas - 10 ? TotalPaginas - 10 : PaginaActual - 5) : 1);
    //public int PaginaFinal => (TotalPaginas > 10 && (PaginaActual + 5) < TotalPaginas ? (PaginaActual + 5 < 10 ? 10 : PaginaActual + 5) : TotalPaginas);
}

/* public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> Results { get; set; }
 
    public PagedResult()
    {
        Results = new List<T>();
    }
} */

public class PaginaResultado<T> : PaginaResultadoBase where T : class
{
    public IList<T> Resultados { get; set; }

    public PaginaResultado()
    {
        Resultados = new List<T>();
    }
}

public static class Pagination
{
    /* public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.RowCount = query.Count();

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = query.Skip(skip).Take(pageSize).ToList();

        return result;
    }

    public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.RowCount = await query.CountAsync();

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    } */

    ///<sumary>
    ///
    ///</sumary>
    public static async Task<PaginaResultado<T>> GetPaginaResultadoAsync<T>(this IQueryable<T> query, int Pagina, int Filas) where T : class
    {
        var resultado = new PaginaResultado<T>();

        resultado.PaginaActual = Pagina;
        resultado.FilasPagina = Filas;
        resultado.TotalFilas = await query.CountAsync();

        var skip = ((Pagina - 1) * Filas);
        resultado.Resultados = await query.Skip(skip).Take(Filas).ToListAsync();


        return resultado;
    }




}