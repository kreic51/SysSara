namespace SysSara.Models.Dtos;

public class ProductoStockListDto
{    
    public string? Sucursal { get; set; } 
    public string? Producto { get; set; }    
    public string? SubProducto { get; set; }
    public int Cantidad { get; set; }
    [Display(Name = "Cantidad Minima")]
    public int CantidadMinima { get; set; }
    [Display(Name = "Uso")]
    public int Uso { get; set; }    
    public string? Estatus { get; set; }
    public DateTime? FechaRegistro { get; set; }
}
