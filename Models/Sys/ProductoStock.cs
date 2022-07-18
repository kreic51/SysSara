namespace SysSara.Models.Sys;

public class ProductoStock
{
    public int SucursalId { get; set; }
    public int ProductoId { get; set; }
    public int SubProductoId { get; set; }
    public int Cantidad { get; set; }
    public int CantidadMinima { get; set; }
    public int UsoId { get; set; }
    public string? EstatusId { get; set; }
    public DateTime? FechaRegistro { get; set; }

    public Producto? Producto { get; set; }
    public SubProducto? SubProducto { get; set; }
    public Estatus? Estatus { get; set; }
    public Sucursal? Sucursal { get; set; }

}

public class ProductoStockConfiguration : IEntityTypeConfiguration<ProductoStock>
{
    public void Configure(EntityTypeBuilder<ProductoStock> builder)
    {
        builder.ToTable("Alm_ProductosStock");
        builder.HasKey(p => new { p.SucursalId, p.ProductoId, p.SubProductoId});
        builder.Property(p => p.EstatusId).HasMaxLength(2);
    }
}