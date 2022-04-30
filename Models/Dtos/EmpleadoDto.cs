namespace SysSara.Models.Dtos;

public class EmpleadoDto
{
    public int EmpleadoId { get; set; }
    public string? Apaterno { get; set; }
    public string? Amaterno { get; set; }
    public string? Nombre { get; set; }
    public DateTime? FechaNacimiento { get; set; } = DateTime.Now.AddYears(-18);
    public string? Curp { get; set; }
    public string? SeguridadSocial { get; set; }
    public string? Telefono { get; set; }
    public string? Celular { get; set; }
    public string? Rfc { get; set; }
    public int? Categoria { get; set; }
    public int? TipoSangre { get; set; }
    public DateTime? FechaIngreso { get; set; } = DateTime.Now;
    public string? Estatus { get; set; }
    public string? Usuario { get; set; }
    public string? Contraseña { get; set; }    
    public int? DepartamentoId { get; set; }
    public List<int?> Rol { get; set; }

    public SelectList? TiposSangre { get; set; }
    public SelectList? Departamentos { get; set; }
    public SelectList? Roles { get; set; }

    
    public int DomicilioId { get; set; }    
    public string? Calle { get; set; }
    public string? NoExt { get; set; }
    public string? NoInt { get; set; }
    public string? Colonia { get; set; }
    public string? Poblacion { get; set; }
    public string? Municipio { get; set; }
    public string? Estado { get; set; }
    
    public SelectList? Estados { get; set; }
    public SelectList? Municipios { get; set; }
    public SelectList? Poblaciones { get; set; }
    public SelectList? Colonias { get; set; }
    public SelectList? Estatuses { get; set; }

    public MensajeDto? Mensaje { get; set; } = new();
}