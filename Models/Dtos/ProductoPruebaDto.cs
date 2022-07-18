namespace SysSara.Models.Dtos;

public class ProductoPruebaDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es requedido.")]
    [Display(Name = "Codigo de Barras")]
    public string? CodigoBarras { get; set; }
    public int Categoria { get; set; }
    [Required(ErrorMessage = "Este campo es requedido.")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Este campo es requedido.")]
    [Display(Name = "Estatus")]
    public string? EstatusId { get; set; }
    public string? UsuarioId { get; set; }
    public SelectList? Estatuses { get; set; }
}
