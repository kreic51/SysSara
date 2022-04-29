namespace SysSara.Models.Cat;

public class Tiposangre
{    
    public int SangreId { get; set; }
    public string? Descripcion { get; set; }    
}

public class TiposangreConfiguration : IEntityTypeConfiguration<Tiposangre>
{
    public void Configure(EntityTypeBuilder<Tiposangre> builder)
    {
        builder.ToTable("Cat_Tiposangre");
	    builder.HasKey(x => x.SangreId);        
    }
}