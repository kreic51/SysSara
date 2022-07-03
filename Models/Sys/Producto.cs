namespace SysSara.Models.Sys;

public class Producto
{
    public int Id { get; set; }
    public string? CodigoBarras { get; set; }
    public int Categoria { get; set; }
    public string? Nombre { get; set; }
    public int Cantidad { get; set; }
    public int CantidadMinima { get; set; }
    public string? Estatus { get; set; }
    public string? UsuarioId { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaActivo { get; set; }
}

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        //builder.ToTable("Productos");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.CodigoBarras)
            .HasMaxLength(50);
    }
}