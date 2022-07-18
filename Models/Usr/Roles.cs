namespace SysSara.Models.Usr;

public class Roles
{    
    public int? RolId { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; } = DateTime.Now;
    public DateTime? FechaEstatus { get; set; } = DateTime.Now;
    public string? EstatusId { get; set; } = "V";
    public string? UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public Rol? Rol { get; set; }
    
}

public class RolConfiguration : IEntityTypeConfiguration<Roles>
{
    public void Configure(EntityTypeBuilder<Roles> builder)
    {
        builder.ToTable("Usr_Roles");
        builder.HasKey(x => new { x.UsuarioId, x.RolId });
        builder.Property(x => x.EstatusId)
            .HasMaxLength(2);
    }
}