namespace SysSara.Data;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Producto, ProductoDto>();

        CreateMap<Empleado, EmpleadoDto>();

        CreateMap<EmpleadoDto, Empleado>();

        CreateMap<Empleado, EmpleadosListDto>()
            .ForMember(dto => dto.Descripcion, ent => ent.MapFrom(p => p.Departamento.Descripcion))
            .ForMember(dto => dto.Estatus, ent => ent.MapFrom(p => p.Estatus.Descripcion));            
    }
}
