

//namespace SysSara.Models.Sys;

//public class Domicilio
//{
//    public int DomicilioId { get; set; }    
//    public string? Calle { get; set; }
//    public string? NoExt { get; set; }
//    public string? NoInt { get; set; }
//    public string? Colonia { get; set; }
//    public string? PoblacionId { get; set; }
//    public string? MunicipioId { get; set; }
//    public string? EstadoId { get; set; }
//    //public int EmpleadoId { get; set; }
//    public Empleado? Empleado {get; set;}
//    /* public Estado? Estado { get; set; }
//    public Municipio? Municipio { get; set; }
//    public Poblacion? Poblacion { get; set; }
// */
//}

//public class DomicilioConfiguration : IEntityTypeConfiguration<Domicilio>
//{
//    public void Configure(EntityTypeBuilder<Domicilio> builder)
//    {
//        builder.ToTable("Domicilios");
//        builder.HasKey(x => x.DomicilioId);
//        builder.HasOne(x => x.Empleado).WithOne(y => y.Domicilio).HasForeignKey<Empleado>(x => x.DomicilioId)
//        .IsRequired().OnDelete(DeleteBehavior.Cascade);
//    }
//}