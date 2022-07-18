namespace SysSara.Models.Cat;

public class Turno
{
    public int TurnoId { get; set; }
    public string Nombre { get; set; }
    public string EstatusId { get; set; }
    public Estatus Estatus { get; set; }
}

public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.ToTable("Cat_Turnos");

        builder.HasKey(p => p.TurnoId);

        builder.Property(p => p.Nombre)
            .HasMaxLength(100);
        builder.Property(p => p.EstatusId)
            .HasMaxLength(2);

    }
}