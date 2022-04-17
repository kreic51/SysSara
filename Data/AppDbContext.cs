namespace SysSara.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Domicilio> Domicilios { get; set; }    
    public DbSet<Rol> Roles { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    } */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity => {
            entity.ToTable("Empleados");
            entity.HasKey(x => x.EmpleadoId);
        });

        modelBuilder.Entity<Domicilio>(entity => {
            entity.ToTable("Domicilios");
            entity.HasKey(x => x.DomicilioId);
            entity.HasOne(x => x.Empleado).WithOne(y => y.Domicilio);
        });

        modelBuilder.Entity<Rol>(entity => {
            entity.ToTable("Roles");
            entity.HasKey(x => x.RolId);
            entity.HasOne(x => x.Empleado).WithMany(y => y.Roles);
        });
            
    }

}