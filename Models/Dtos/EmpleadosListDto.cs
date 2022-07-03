namespace SysSara.Models.Dtos;

public class EmpleadosListDto
{
    [Display(Name = "Id")]
    public int EmpleadoId { get; set; }
    [Display(Name = "Apellido Paterno")]
    public string? Apaterno { get; set; }
    [Display(Name = "Apellido Materno")]
    public string? Amaterno { get; set; }
    [Display(Name = "Nombre(s)")]
    public string? Nombre { get; set; }
    [Display(Name = "Estatus")]
    public string? Estatus { get; set; }
    [Display(Name = "Departamento")]
    public string? Descripcion { get; set; }
}