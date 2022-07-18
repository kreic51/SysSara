using SysSara.Models.Usr;

namespace SysSara.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //catalogos    
    public DbSet<Rol>? catRoles { get; set; }
    public DbSet<Departamento>? Departamentos { get; set; }
    public DbSet<Estado>? Estados { get; set; }
    public DbSet<Municipio>? Municipios { get; set; }
    public DbSet<Colonia>? Colonias { get; set; }
    public DbSet<Tiposangre>? Tiposangres { get; set; }
    public DbSet<Estatus>? Estatus { get; set; }
    public DbSet<Sucursal>? Sucursales { get; set; }    
    public DbSet<ProductoPrueba>? ProductosPrueba { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<SubProducto> SubProductos { get; set; }
    public DbSet<Turno> Turnos { get; set; }

    //Sistema
    public DbSet<Empleado>? Empleados { get; set; }
    public DbSet<ProductoStock> ProductosStock { get; set; } 

    //Usuarios
    public DbSet<Roles>? Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    } */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());        
    }

}