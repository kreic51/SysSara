namespace SysSara.Services.Interfaces;

public interface ICatalogosRepository 
{
    Task<Departamento> GetDepartamento(int id);
    Task<IEnumerable<Departamento>> GetListDepartamentos();

    Task<Estado> GetEstado(string estado);
    Task<IEnumerable<Estado>> GetListEstados();

    Task<Municipio> GetMunicipio(string estado, string municipio);
    Task<IEnumerable<Municipio>> GetListMunicipios(string estado);

    Task<Poblacion> GetPoblacion(string estado, string municipio, string poblacion);
    Task<IEnumerable<Poblacion>> GetListPoblaciones(string estado, string municipio);

    Task<Rol> GetRol(int id);
    Task<IEnumerable<Rol>> GetListRol();

    Task<Tiposangre> GetTiposangre(int id);
    Task<IEnumerable<Tiposangre>> GetListTiposangres();
    
}