namespace SysSara.Models.Cat;

public class SubProducto
{
    public int SubProductoId { get; set; }
    public int? ProductoId { get; set; }
    public string? Nombre { get; set; }
    public string? Medida { get; set; }
    public string? EstatusId { get; set; }
    public Producto? Producto { get; set; }
    public Estatus? Estatus { get; set; }
}

public class SubProductoConfiguration : IEntityTypeConfiguration<SubProducto>
{
    public void Configure(EntityTypeBuilder<SubProducto> builder)
    {
        builder.ToTable("Cat_SubProductos");

        builder.HasKey(p => p.SubProductoId);

        builder.Property(p => p.Nombre)
            .HasMaxLength(100);

        builder.Property(p => p.EstatusId)
            .HasMaxLength(2);

    }
}