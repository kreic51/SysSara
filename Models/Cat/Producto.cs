namespace SysSara.Models.Cat;

public class Producto
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public string EstatusId { get; set; }
    public Estatus Estatus { get; set; }
}

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Cat_Productos");

        builder.HasKey(p => p.ProductoId);

        builder.Property(p => p.Nombre)
            .HasMaxLength(100);
    }
}