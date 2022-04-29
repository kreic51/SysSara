namespace SysSara.Services.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IEmpleadosRepository Empleados { get; }
    ICatalogosRepository Catalogos { get; }
    IDomiciliosRepository Domicilios { get; }
    Task<int> CompleteAsync();
}