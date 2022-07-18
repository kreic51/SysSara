namespace SysSara.Models.Dtos;

public class ProductosPruebaListDto
{    
    public int Id { get; set; }
    [Display(Name = "Codigo de Barras")]
    public string? CodigoBarras { get; set; }    
    public string? Nombre { get; set; }    
    public string? Estatus { get; set; }
}
