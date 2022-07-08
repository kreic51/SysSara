namespace SysSara.Models.Dtos;

public class EmpleadoDto
{
    [Display(Name = "Id")]
    public int EmpleadoId { get; set; }
    [Display(Name = "Apellido Paterno")]
    public string? Apaterno { get; set; }
    [Display(Name = "Apellido Materno")]
    public string? Amaterno { get; set; }
    [Required(ErrorMessage = "El nombre del empleado es requerido")]
    [Display(Name = "Nombre(s)")]
    public string? Nombre { get; set; }
    [Display(Name = "Fecha Nacimiento")]
    [DataType(DataType.Date)]
    public DateTime? FechaNacimiento { get; set; } = DateTime.Now.AddYears(-18);
    public string? Curp { get; set; }
    [Display(Name = "No. Seguro Social")]
    public string? SeguridadSocial { get; set; }
    public string? Telefono { get; set; }
    public string? Celular { get; set; }
    public string? Rfc { get; set; }
    public int? Categoria { get; set; }
    [Display(Name = "Tipo Sangre")]
    public int? TipoSangre { get; set; }
    [Display(Name = "Departamento")]
    public int? DepartamentoId { get; set; }
    [Display(Name = "Sucursal")]
    public int? SucursalId { get; set; }
    public string? Calle { get; set; }
    [Display(Name = "No. Exterior")]
    public string? NoExt { get; set; }
    [Display(Name = "No. Interior")]
    public string? NoInt { get; set; }
    [Display(Name = "Colonia")]
    public string? ColoniaId { get; set; }    
    [Display(Name = "Municipio")]
    public string? MunicipioId { get; set; }
    [Display(Name = "Estado")]
    public string? EstadoId { get; set; }
    [Display(Name = "Fecha Ingreso")]
    [DataType(DataType.Date)]
    public DateTime? FechaIngreso { get; set; } = DateTime.Now;
    public string? EstatusId { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }

    public SelectList? TiposSangre { get; set; }
    public SelectList? Departamentos { get; set; }
    public SelectList? Estados { get; set; }
    public SelectList? Municipios { get; set; }    
    public SelectList? Colonias { get; set; }
    public SelectList? Estatuses { get; set; }
    public SelectList? Sucursales { get; set; }
}