namespace SysSara.Services.Interfaces;

public interface IEmpleadosRepository : IGenericRepository<Empleado> {
    Task<Empleado> GetByIdWhitRelation(int id);
    Task<IEnumerable<Empleado>> GetAllWhitRelation();    
}