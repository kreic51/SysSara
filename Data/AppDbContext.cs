namespace SysSara.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Empleado>? Empleados { get; set; }    
    public DbSet<Roles>? Roles { get; set; }
    public DbSet<Rol>? catRoles { get; set; }
    public DbSet<Departamento>? Departamentos { get; set; }
    public DbSet<Estado>? Estados { get; set; }
    public DbSet<Municipio>? Municipios { get; set; }
    public DbSet<Poblacion>? Poblaciones { get; set; }
    public DbSet<Tiposangre>? Tiposangres { get; set; }
    public DbSet<Estatus>? Estatus { get; set; }
    public DbSet<Sucursal>? Sucursales { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    } */
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());        
    }

}