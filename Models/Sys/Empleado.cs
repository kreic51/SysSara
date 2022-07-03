namespace SysSara.Models.Sys;

public class Empleado
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
    public int? DepartamentoId { get; set; }
    public int? SucursalId { get; set; }
    public string? Calle { get; set; }
    public string? NoExt { get; set; }
    public string? NoInt { get; set; }
    public string? Colonia { get; set; }
    public string? PoblacionId { get; set; }
    public string? MunicipioId { get; set; }
    public string? EstadoId { get; set; }
    public DateTime? FechaIngreso { get; set; } = DateTime.Now;
    public string? EstatusId { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public Departamento? Departamento { get; set; }
    public Estatus? Estatus { get; set; }
}

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados");
	    builder.HasKey(e => e.EmpleadoId);
    }
}