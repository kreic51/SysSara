namespace SysSara.Models.Cat;

public class Rol
{    
    public int RolId { get; set; }
    public string? Descripcion { get; set; }
    public string? Estatus { get; set; }
    public string? UserRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaEstatus { get; set; }    
    //public Roles? Roles { get; set; }
}

public class RolesConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Cat_Roles");
	    builder.HasKey(x => x.RolId);
        //builder.HasOne(x => x.Roles).WithOne(y => y.Rol);
    }
}
