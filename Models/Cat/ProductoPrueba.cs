namespace SysSara.Models.Cat;

public class ProductoPrueba
{
    public int Id { get; set; }
    public string? CodigoBarras { get; set; }
    public int Categoria { get; set; }
    public string? Nombre { get; set; }    
    public string? EstatusId { get; set; }
    public string? UsuarioId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaEstatus { get; set; }
    public Estatus? Estatus { get; set; }    
}

public class ProductoPruebaConfiguration : IEntityTypeConfiguration<ProductoPrueba>
{
    public void Configure(EntityTypeBuilder<ProductoPrueba> builder)
    {
        builder.ToTable("Cat_ProductosPrueba");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CodigoBarras)
            .HasMaxLength(50);
    }
}