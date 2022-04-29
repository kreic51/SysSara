namespace SysSara.Models.Sys;

public class Roles
{     
    public int? RolId { get; set; }
    public int? Rol { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; } = DateTime.Now;
    public DateTime? FechaEstatus { get; set; } = DateTime.Now;
    public string? Estatus { get; set; } = "V";
    public int? EmpleadoId { get; set; }
    public Empleado? Empleado { get; set; }
    //public Rol? Rol { get; set; }
}

public class RolConfiguration : IEntityTypeConfiguration<Roles>
{
    public void Configure(EntityTypeBuilder<Roles> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(x => new { x.EmpleadoId, x.RolId });
        builder.HasOne(x => x.Empleado).WithMany(y => y.Roles);
    }
}