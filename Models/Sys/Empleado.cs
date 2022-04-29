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
    public DateTime? FechaIngreso { get; set; } = DateTime.Now;
    public string? Estatus { get; set; }
    public string? Usuario { get; set; }
    public string? Contraseña { get; set; }
    public string? UserRegistro { get; set; }
    public int? DepartamentoId { get; set; }    
    public int? DomicilioId { get; set; }    
    public DateTime? FechaRegistro { get; set; }
    public Domicilio? Domicilio { get; set; }
    public ICollection<Roles>? Roles { get; set; }
    
}

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados");
	    builder.HasKey(e => e.EmpleadoId);	
        //builder.HasOne(x => x.Domicilio).WithOne(y => y.Empleado).HasForeignKey<Domicilio>(x => x.EmpleadoId);
    }
}