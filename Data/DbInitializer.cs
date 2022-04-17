namespace SysSara.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Empleados.Any())
        {
            return;   // DB has been seeded
        }

        var Empleados = new Empleado[]
        {
            new Empleado {Apaterno="Admin", Amaterno= "Admin", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"),
                Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5", Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7",
                Departamento=1, Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), Estatus="V", Usuario="Admin",
                Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16")},
            new Empleado {Apaterno="Rojas", Amaterno= "Jimenez", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"),
                Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5", Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91",
                Departamento=1, Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), Estatus="V", Usuario="FRojas",
                Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16")},
            new Empleado {Apaterno="Prueba", Amaterno= "Prueba", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"),
                Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5", Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91",
                Departamento=1, Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), Estatus="V", Usuario="FRojas",
                Contraseña="123", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16")}
        };

        foreach (Empleado e in Empleados)
        {
            context.Empleados.Add(e);
        }
        context.SaveChanges();

        var Domicilios = new Domicilio[]
        {
            new Domicilio { Calle="Prueba", NoExt="58", NoInt="B", Colonia=1, Poblacion=1, Municipio=1, Estado=1, EmpleadoId=1 },
            new Domicilio { Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia=9, Poblacion=6, Municipio=6, Estado=25, EmpleadoId=2 },
            new Domicilio { Calle="Probando", NoExt="123", NoInt="4", Colonia=9, Poblacion=6, Municipio=6, Estado=25, EmpleadoId=3 }
        };

        foreach (Domicilio d in Domicilios)
        {
            context.Domicilios.Add(d);
        }
        context.SaveChanges();

        var Roles = new Rol[]
        {
            new Rol { RolName=1, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=1 },
            new Rol { RolName=2, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=1 },
            new Rol { RolName=2, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=2 }
        };

        foreach (Rol r in Roles)
        {
            context.Roles.Add(r);
        }
        context.SaveChanges();
    }
}
    