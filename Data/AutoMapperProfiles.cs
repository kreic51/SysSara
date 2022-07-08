namespace SysSara.Data;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Empleado, EmpleadoDto>();
        CreateMap<EmpleadoDto, Empleado>();
        CreateMap<Empleado, EmpleadosListDto>()
            .ForMember(dto => dto.Descripcion, ent => ent.MapFrom(p => p.Departamento.Descripcion))
            .ForMember(dto => dto.Estatus, ent => ent.MapFrom(p => p.Estatus.Descripcion));

        CreateMap<Producto, ProductoDto>();
        CreateMap<ProductoDto, Producto>();
        CreateMap<Producto, ProductosListDto>()
            .ForMember(dto => dto.Estatus, ent => ent.MapFrom(e => e.Estatus.Descripcion));
    }
}
