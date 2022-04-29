namespace SysSara.Models.Cat;

public class Estado
{    
    public string? Cve_est { get; set; }
    public string? Descripcion { get; set; }
    public string? Abreviacion { get; set; }
    //public Domicilio? Domicilio { get; set; }
}

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Cat_Estados");
	    builder.HasKey(x => x.Cve_est);
        //builder.HasOne(x => x.Domicilio).WithOne(y => y.Estado).HasForeignKey<Domicilio>(y => y.EstadoId);
    }
}