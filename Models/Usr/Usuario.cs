namespace SysSara.Models.Usr;

public class Usuario
{
    public string UsuarioId { get; set; }
    public string Password { get; set; }
    public int EmpleadoId { get; set; }
    public string EstatusId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string UsuarioRegistro { get; set; }
    public Empleado Empleado { get; set; }
    public Estatus Estatus { get; set; }
    public List<Roles> Roles { get; set; }

}

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usr_Usuarios");

        builder.HasKey(p => p.UsuarioId);

        builder.Property(p => p.EstatusId)
            .HasMaxLength(2);

    }
}