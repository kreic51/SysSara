namespace SysSara.Models.Cat;

public class Sucursal
{
    public int? SucursalId { get; set; }
    public string? Nombre { get; set; }
    public string? EstatusId { get; set; }
    public DateTime? FechaRegistro { get; set; }
}

public class SucursalConfiguration : IEntityTypeConfiguration<Sucursal>
{
    public void Configure(EntityTypeBuilder<Sucursal> builder)
    {
        builder.ToTable("Sucursales");
        builder.HasKey(x => x.SucursalId);        
    }
}