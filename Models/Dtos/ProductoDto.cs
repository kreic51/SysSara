namespace SysSara.Models.Dtos;

public class ProductoDto
{
    public int Id { get; set; }
    public string? CodigoBarras { get; set; }
    public int Categoria { get; set; }
    public string? Nombre { get; set; }
    public int Cantidad { get; set; }
    public int CantidadMinima { get; set; }
    public string? Estatus { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaActivo { get; set; }
}
