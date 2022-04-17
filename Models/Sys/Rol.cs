namespace SysSara.Models.Sys;

public class Rol
{     
    public int? RolId { get; set; }
    public int? RolName { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaEstatus { get; set; }
    public string? Estatus { get; set; }
    public int? EmpleadoId { get; set; }
    public Empleado? Empleado {get; set;}
}



