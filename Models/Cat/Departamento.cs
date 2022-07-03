namespace SysSara.Models.Cat;

public class Departamento
{    
    public int DepartamentoId { get; set; }
    public string? Descripcion { get; set; }
    public string? Estatus { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaEstatus { get; set; }
}

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Cat_Departamentos");
	    builder.HasKey(x => x.DepartamentoId);        
    }
}
