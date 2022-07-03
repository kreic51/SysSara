namespace SysSara.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureDeleted(); //Elimina la bd si existe.
        context.Database.EnsureCreated(); //Revisa si la bd existe, si no la crea.

        // Busca si la tabla empleados tiene algun dato
        if (context.Empleados.Any())
        {
            return;   // Si la BD ya tiene informacion, sale del la funcion.
        }


        ///Se rellenan los catalogos ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var Departamentos = new Departamento[]
        {
            new Departamento { Descripcion = "Recursos Humanos", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "Ventas", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "Produccion", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "Almacen", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
        };

        foreach (Departamento d in Departamentos)
        {
            context.Departamentos.Add(d);
        }

        var rols = new Rol[]
        {
            new Rol { Descripcion = "Admin", EstatusId = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Secretaria", EstatusId = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Productor", EstatusId = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Ventas", EstatusId = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},

        };

        foreach (Rol r in rols)
        {
            context.catRoles.Add(r);
        }

        var Estados = new Estado[]
        {
            new Estado { Cve_est = "01", Descripcion = "Aguascalientes", Abreviacion =  "Ags" },
            new Estado { Cve_est = "02", Descripcion = "Baja California", Abreviacion =  "BC" },
            new Estado { Cve_est = "03", Descripcion = "Baja California Sur", Abreviacion =  "BCS" },
            new Estado { Cve_est = "04", Descripcion = "Campeche", Abreviacion =  "Camp" },
            new Estado { Cve_est = "05", Descripcion = "Coahuila de Zaragoza", Abreviacion =  "Coah" },
            new Estado { Cve_est = "06", Descripcion = "Colima", Abreviacion =  "Col" },
            new Estado { Cve_est = "07", Descripcion = "Chiapas", Abreviacion =  "Chis" },
            new Estado { Cve_est = "08", Descripcion = "Chihuahua", Abreviacion =  "Chih" },
            new Estado { Cve_est = "09", Descripcion = "Ciudad de México", Abreviacion =  "CDMX" },
            new Estado { Cve_est = "10", Descripcion = "Durango", Abreviacion =  "Dgo" },
            new Estado { Cve_est = "11", Descripcion = "Guanajuato", Abreviacion =  "Gto" },
            new Estado { Cve_est = "12", Descripcion = "Guerrero", Abreviacion =  "Gro" },
            new Estado { Cve_est = "13", Descripcion = "Hidalgo", Abreviacion =  "Hgo" },
            new Estado { Cve_est = "14", Descripcion = "Jalisco", Abreviacion =  "Jal" },
            new Estado { Cve_est = "15", Descripcion = "México", Abreviacion =  "Mex" },
            new Estado { Cve_est = "16", Descripcion = "Michoacán de Ocampo", Abreviacion =  "Mich" },
            new Estado { Cve_est = "17", Descripcion = "Morelos", Abreviacion =  "Mor" },
            new Estado { Cve_est = "18", Descripcion = "Nayarit", Abreviacion =  "Nay" },
            new Estado { Cve_est = "19", Descripcion = "Nuevo León", Abreviacion =  "NL" },
            new Estado { Cve_est = "20", Descripcion = "Oaxaca", Abreviacion =  "Oax" },
            new Estado { Cve_est = "21", Descripcion = "Puebla", Abreviacion =  "Pue" },
            new Estado { Cve_est = "22", Descripcion = "Querétaro", Abreviacion =  "Qro" },
            new Estado { Cve_est = "23", Descripcion = "Quintana Roo", Abreviacion =  "Q Roo" },
            new Estado { Cve_est = "24", Descripcion = "San Luis Potosí", Abreviacion =  "SLP" },
            new Estado { Cve_est = "25", Descripcion = "Sinaloa", Abreviacion =  "Sin" },
            new Estado { Cve_est = "26", Descripcion = "Sonora", Abreviacion =  "Son" },
            new Estado { Cve_est = "27", Descripcion = "Tabasco", Abreviacion =  "Tab" },
            new Estado { Cve_est = "28", Descripcion = "Tamaulipas", Abreviacion =  "Tamps" },
            new Estado { Cve_est = "29", Descripcion = "Tlaxcala", Abreviacion =  "Tlax" },
            new Estado { Cve_est = "30", Descripcion = "Veracruz de Ignacio de la Llave", Abreviacion =  "Ver" },
            new Estado { Cve_est = "31", Descripcion = "Yucatán", Abreviacion =  "Yuc" },
            new Estado { Cve_est = "32", Descripcion = "Zacatecas", Abreviacion =  "Zac" },
        };

        foreach (Estado e in Estados)
        {
            context.Estados.Add(e);
        }

        var Municipios = new Municipio[]
        {
            new Municipio { Cve_est = "25", Cve_mun = "001", Descripcion = "Ahome" },
            new Municipio { Cve_est = "25", Cve_mun = "002", Descripcion = "Angostura" },
            new Municipio { Cve_est = "25", Cve_mun = "003", Descripcion = "Badiraguato" },
            new Municipio { Cve_est = "25", Cve_mun = "004", Descripcion = "Concordia" },
            new Municipio { Cve_est = "25", Cve_mun = "005", Descripcion = "Cosalá" },
            new Municipio { Cve_est = "25", Cve_mun = "006", Descripcion = "Culiacán" },
            new Municipio { Cve_est = "25", Cve_mun = "007", Descripcion = "Choix" },
            new Municipio { Cve_est = "25", Cve_mun = "008", Descripcion = "Elota" },
            new Municipio { Cve_est = "25", Cve_mun = "009", Descripcion = "Escuinapa" },
            new Municipio { Cve_est = "25", Cve_mun = "010", Descripcion = "El Fuerte" },
            new Municipio { Cve_est = "25", Cve_mun = "011", Descripcion = "Guasave" },
            new Municipio { Cve_est = "25", Cve_mun = "012", Descripcion = "Mazatlán" },
            new Municipio { Cve_est = "25", Cve_mun = "013", Descripcion = "Mocorito" },
            new Municipio { Cve_est = "25", Cve_mun = "014", Descripcion = "Rosario" },
            new Municipio { Cve_est = "25", Cve_mun = "015", Descripcion = "Salvador Alvarado" },
            new Municipio { Cve_est = "25", Cve_mun = "016", Descripcion = "San Ignacio" },
            new Municipio { Cve_est = "25", Cve_mun = "017", Descripcion = "Sinaloa" },
            new Municipio { Cve_est = "25", Cve_mun = "018", Descripcion = "Navolato" },
        };

        foreach (Municipio m in Municipios)
        {
            context.Municipios.Add(m);
        }

        var Poblaciones = new Poblacion[]
        {
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0001", Descripcion = "Los Mochis" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0067", Descripcion = "El Aguajito" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0068", Descripcion = "Agua Nueva" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0070", Descripcion = "Ahome" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0072", Descripcion = "Los Algodones" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0076", Descripcion = "El Añil" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0080", Descripcion = "Bacaporobampo" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0081", Descripcion = "Bacorehuis" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0082", Descripcion = "Bachomobampo Número Uno" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0083", Descripcion = "Bagojo Colectivo" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0088", Descripcion = "Ejido Benito Juárez" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0090", Descripcion = "San Isidro" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0095", Descripcion = "El Bule" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0101", Descripcion = "Las Lilas" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0112", Descripcion = "El Carricito" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0115", Descripcion = "Cerrillos (Campo 35)" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0118", Descripcion = "Cohuibampo" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0119", Descripcion = "El Colorado" },
            new Poblacion { Cve_est = "25", Cve_mun = "001", Cve_pob = "0120", Descripcion = "Compuertas" },
        };

        foreach (Poblacion p in Poblaciones)
        {
            context.Poblaciones.Add(p);
        }

        /////Se llenan con datos de prueba las tablas de sistema///////////////////////////////////////////////////////////////////////////////////////

        var Tipos = new Tiposangre[]
        {
            new Tiposangre { Descripcion = "A +" },
            new Tiposangre { Descripcion = "A -" },
            new Tiposangre { Descripcion = "B +" },
            new Tiposangre { Descripcion = "B -" },
            new Tiposangre { Descripcion = "O +" },
            new Tiposangre { Descripcion = "O -" },
            new Tiposangre { Descripcion = "AB +" },
            new Tiposangre { Descripcion = "AB -" },
        };

        foreach (Tiposangre t in Tipos)
        {
            context.Tiposangres.Add(t);
        }

        var suc = new Sucursal[]
        {
            new Sucursal { Nombre = "Guadalupe", EstatusId = "V", FechaRegistro = new DateTime(2022, 1, 14) },
            new Sucursal { Nombre = "Tierra Blanca", EstatusId = "V", FechaRegistro = new DateTime(2022, 1, 14) }
        };

        foreach (Sucursal s in suc)
        {
            context.Sucursales.Add(s);
        }


        var est = new Estatus[]
        {
            new Estatus { EstatusId = "V", Descripcion = "Vigente" },
            new Estatus { EstatusId = "B", Descripcion = "Baja" },
        };

        foreach (Estatus e in est)
        {
            context.Estatus.Add(e);
        }


        var Empleados = new Empleado[]
        {
            new Empleado {Apaterno="Admin", Amaterno= "Admin", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Prueba", NoExt="58", NoInt="B", Colonia="1", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Rojas", Amaterno= "Jimenez", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Prueba", Amaterno= "Prueba", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Probando", NoExt="123", NoInt="4", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Lopez", Amaterno= "Rojo", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Prueba", NoExt="58", NoInt="B", Colonia="1", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Lugo", Amaterno= "Cardenaz", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="De la rocha", Amaterno= "Cataluña", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Probando", NoExt="123", NoInt="4", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Romero", Amaterno= "Alcazar", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Prueba", NoExt="58", NoInt="B", Colonia="1", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Espinoza", Amaterno= "Lizarraga", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Martinez", Amaterno= "Ficth", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Probando", NoExt="123", NoInt="4", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Regalado", Amaterno= "Cuadras", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"),Calle="Prueba", NoExt="58", NoInt="B", Colonia="1", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Muñoz", Amaterno= "Jimenez", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},
            new Empleado {Apaterno="Lerma", Amaterno= "Sainz", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="Probando", NoExt="123", NoInt="4", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1}
        };

        foreach (Empleado e in Empleados)
        {
            context.Empleados.Add(e);
        }

        context.SaveChanges();

        var Roles = new Roles[]
        {
            new Roles { EmpleadoId = 1, RolId = 1, Rol = 1, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16") },
            new Roles { EmpleadoId = 1, RolId = 2, Rol = 2, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16") },
            new Roles { EmpleadoId = 2, RolId = 1, Rol = 2, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16") },
            new Roles { EmpleadoId = 3, RolId = 2, Rol = 3, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16") }
        };

        foreach (Roles r in Roles)
        {
            context.Roles.Add(r);
        }

        context.SaveChanges();
    }
}
