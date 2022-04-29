namespace SysSara.Services;

public class EmpleadosRepository : GenericRepository<Empleado>, IEmpleadosRepository
{
    public EmpleadosRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Empleado>> GetAllWhitRelation()
    {
        //return await _context.Set<Empleado>().ToListAsync();
        return await _context.Empleados            
            .Include(x => x.Domicilio)
            .Include(x => x.Roles)
            .ToListAsync();
    }
    

    public async Task<Empleado> GetByIdWhitRelation(int id)
    {   
        if(id == 0) return new Empleado();

        Empleado? emp;

        try{
            emp = await _context.Empleados.Where(x => x.EmpleadoId == id)                                        
                                        .Include(x => x.Domicilio)
                                        .Include(x => x.Roles)
                                        .FirstOrDefaultAsync();
        }catch
        {
            throw;
        }
        
        return emp;
            
    }
}