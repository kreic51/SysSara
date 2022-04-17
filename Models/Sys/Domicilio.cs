namespace SysSara.Models.Sys;

public class Domicilio
{
    public int DomicilioId { get; set; }    
    public string? Calle { get; set; }
    public string? NoExt { get; set; }
    public string? NoInt { get; set; }
    public int? Colonia { get; set; }
    public int? Poblacion { get; set; }
    public int? Municipio { get; set; }
    public int? Estado { get; set; }
    public int? EmpleadoId { get; set; }    
    public Empleado? Empleado {get; set;} 
}