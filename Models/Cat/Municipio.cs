namespace SysSara.Models.Cat;

public class Municipio
{    
    public string? Cve_est { get; set; }
    public string? Cve_mun { get; set; }
    public string? Descripcion { get; set; }
    //public Domicilio? Domicilio { get; set; }
}

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("Cat_Municipios");
	    builder.HasKey(x => new { x.Cve_est, x.Cve_mun});
        //builder.HasOne(x => x.Domicilio).WithOne(y => y.Municipio).HasForeignKey<Domicilio>(y => new { y.EstadoId, y.MunicipioId});
    }
}