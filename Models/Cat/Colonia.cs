namespace SysSara.Models.Cat;

public class Colonia
{
    public string? Cve_est { get; set; }
    public string? Cve_mun { get; set; }
    public string? Cve_col { get; set; }
    public string? Descripcion { get; set; }
    public int? TipoColoniaId { get; set; }
    public string? CodigoPostal { get; set; }
}

public class PoblacionConfiguration : IEntityTypeConfiguration<Colonia>
{
    public void Configure(EntityTypeBuilder<Colonia> builder)
    {
        builder.ToTable("Cat_Colonias");
	    builder.HasKey(x => new { x.Cve_est, x.Cve_mun, x.Cve_col});        
    }
}