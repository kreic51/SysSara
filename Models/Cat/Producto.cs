namespace SysSara.Models.Cat;

public class Producto
{
    public int Id { get; set; }
    public string? CodigoBarras { get; set; }
    public int Categoria { get; set; }
    public string? Nombre { get; set; }    
    public string? EstatusId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaEstatus { get; set; }
    public Estatus? Estatus { get; set; }    
}

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Cat_Productos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CodigoBarras)
            .HasMaxLength(50);
    }
}