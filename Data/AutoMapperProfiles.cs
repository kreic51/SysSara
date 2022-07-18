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

        CreateMap<ProductoPrueba, ProductoPruebaDto>();
        CreateMap<ProductoPruebaDto, ProductoPrueba>();
        CreateMap<ProductoPrueba, ProductosPruebaListDto>()
            .ForMember(dto => dto.Estatus, ent => ent.MapFrom(e => e.Estatus.Descripcion));

        CreateMap<ProductoStock, ProductoStockListDto>()
            .ForMember(dto => dto.Sucursal, ent => ent.MapFrom(p => p.Sucursal.Nombre))
            .ForMember(dto => dto.Producto, ent => ent.MapFrom(p => p.Producto.Nombre))
            .ForMember(dto => dto.SubProducto, ent => ent.MapFrom(p => p.SubProducto.Nombre))
            .ForMember(dto => dto.Uso, ent => ent.MapFrom(p => p.UsoId))
            .ForMember(dto => dto.Estatus, ent => ent.MapFrom(p => p.Estatus.Descripcion));


    }
}
