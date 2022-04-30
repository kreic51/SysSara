namespace SysSara.Models.Cat;

public class Estatus
{    
    public string EstatusId { get; set; }
    public string? Descripcion { get; set; }    
}

public class EstatusConfiguration : IEntityTypeConfiguration<Estatus>
{
    public void Configure(EntityTypeBuilder<Estatus> builder)
    {
        builder.ToTable("Cat_Estatus");
	    builder.HasKey(x => x.EstatusId);        
    }
}