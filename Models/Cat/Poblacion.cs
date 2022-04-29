namespace SysSara.Models.Cat;

public class Poblacion
{    
    public string? Cve_est { get; set; }
    public string? Cve_mun { get; set; }
    public string? Cve_pob { get; set; }
    public string? Descripcion { get; set; }
    //public Domicilio? Domicilio { get; set; }
}

public class PoblacionConfiguration : IEntityTypeConfiguration<Poblacion>
{
    public void Configure(EntityTypeBuilder<Poblacion> builder)
    {
        builder.ToTable("Cat_Poblaciones");
	    builder.HasKey(x => new { x.Cve_est, x.Cve_mun, x.Cve_pob});
        //builder.HasOne(x => x.Domicilio).WithOne(y => y.Poblacion).HasForeignKey<Domicilio>(y => new { y.EstadoId, y.MunicipioId, y.PoblacionId});
    }
}