namespace SysSara.Data;

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

public class PaginaResultado<T> : PaginaResultadoBase where T : class
{
    public IList<T> Listado { get; set; }

    public PaginaResultado()
    {
        Listado = new List<T>();
    }
}

public static class Paginacion
{
    ///<sumary>
    ///
    ///</sumary>
    public static async Task<PaginaResultado<T>> ObtenerListadoPaginadoAsync<T>(this IQueryable<T> query, int Pagina, int Filas) where T : class
    {
        var resultado = new PaginaResultado<T>();

        resultado.PaginaActual = Pagina;
        resultado.FilasPagina = Filas;
        resultado.TotalFilas = await query.CountAsync();

        var skip = ((Pagina - 1) * Filas);
        resultado.Listado = await query.Skip(skip).Take(Filas).ToListAsync();

        return resultado;
    }

}