using SysSara.Models.Usr;

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
            new Departamento { Descripcion = "RECURSOS HUMANOS", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "VENTAS", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "PRODUCCION", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Departamento { Descripcion = "ALMACEN", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
        };

        foreach (Departamento d in Departamentos)
        {
            context.Departamentos.Add(d);
        }

        var rols = new Rol[]
        {
            new Rol { Descripcion = "ADMINISTRADOR", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "SECRETARIA", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "PRODUCTOR", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "VENTAS", EstatusId = "V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},

        };

        foreach (Rol r in rols)
        {
            context.catRoles.Add(r);
        }

        var Estados = new Estado[]
        {
            new Estado { Cve_est = "01", Descripcion = "AGUASCALIENTES", Abreviacion =  "AGS" },
            new Estado { Cve_est = "02", Descripcion = "BAJA CALIFORNIA", Abreviacion =  "BC" },
            new Estado { Cve_est = "03", Descripcion = "BAJA CALIFORNIA SUR", Abreviacion =  "BCS" },
            new Estado { Cve_est = "04", Descripcion = "CAMPECHE", Abreviacion =  "CAMP" },
            new Estado { Cve_est = "05", Descripcion = "COAHUILA DE ZARAGOZA", Abreviacion =  "COAH" },
            new Estado { Cve_est = "06", Descripcion = "COLIMA", Abreviacion =  "COL" },
            new Estado { Cve_est = "07", Descripcion = "CHIAPAS", Abreviacion =  "CHIS" },
            new Estado { Cve_est = "08", Descripcion = "CHIHUAHUA", Abreviacion =  "CHIH" },
            new Estado { Cve_est = "09", Descripcion = "CIUDAD DE MEXICO", Abreviacion =  "CDMX" },
            new Estado { Cve_est = "10", Descripcion = "DURANGO", Abreviacion =  "DGO" },
            new Estado { Cve_est = "11", Descripcion = "GUANAJUATO", Abreviacion =  "GTO" },
            new Estado { Cve_est = "12", Descripcion = "GUERRERO", Abreviacion =  "GRO" },
            new Estado { Cve_est = "13", Descripcion = "HIDALGO", Abreviacion =  "HGO" },
            new Estado { Cve_est = "14", Descripcion = "JALISCO", Abreviacion =  "JAL" },
            new Estado { Cve_est = "15", Descripcion = "MEXICO", Abreviacion =  "MEX" },
            new Estado { Cve_est = "16", Descripcion = "MICHOACAN DE OCAMPO", Abreviacion =  "MICH" },
            new Estado { Cve_est = "17", Descripcion = "MORELOS", Abreviacion =  "MOR" },
            new Estado { Cve_est = "18", Descripcion = "NAYARIT", Abreviacion =  "NAY" },
            new Estado { Cve_est = "19", Descripcion = "NUEVO LEON", Abreviacion =  "NL" },
            new Estado { Cve_est = "20", Descripcion = "OAXACA", Abreviacion =  "OAX" },
            new Estado { Cve_est = "21", Descripcion = "PUEBLA", Abreviacion =  "PUE" },
            new Estado { Cve_est = "22", Descripcion = "QUERETARO", Abreviacion =  "QRO" },
            new Estado { Cve_est = "23", Descripcion = "QUINTANA ROO", Abreviacion =  "Q ROO" },
            new Estado { Cve_est = "24", Descripcion = "SAN LUIS POTOSI", Abreviacion =  "SLP" },
            new Estado { Cve_est = "25", Descripcion = "SINALOA", Abreviacion =  "SIN" },
            new Estado { Cve_est = "26", Descripcion = "SONORA", Abreviacion =  "SON" },
            new Estado { Cve_est = "27", Descripcion = "TABASCO", Abreviacion =  "TAB" },
            new Estado { Cve_est = "28", Descripcion = "TAMAULIPAS", Abreviacion =  "TAMPS" },
            new Estado { Cve_est = "29", Descripcion = "TLAXCALA", Abreviacion =  "TLAX" },
            new Estado { Cve_est = "30", Descripcion = "VERACRUZ", Abreviacion =  "VER" },
            new Estado { Cve_est = "31", Descripcion = "YUCATAN", Abreviacion =  "YUC" },
            new Estado { Cve_est = "32", Descripcion = "ZACATECAS", Abreviacion =  "ZAC" },

        };

        foreach (Estado e in Estados)
        {
            context.Estados.Add(e);
        }

        var Municipios = new Municipio[]
        {
            new Municipio { Cve_est = "25", Cve_mun = "001", Descripcion = "AHOME" },
            new Municipio { Cve_est = "25", Cve_mun = "002", Descripcion = "ANGOSTURA" },
            new Municipio { Cve_est = "25", Cve_mun = "003", Descripcion = "BADIRAGUATO" },
            new Municipio { Cve_est = "25", Cve_mun = "004", Descripcion = "CONCORDIA" },
            new Municipio { Cve_est = "25", Cve_mun = "005", Descripcion = "COSALA" },
            new Municipio { Cve_est = "25", Cve_mun = "006", Descripcion = "CULIACAN" },
            new Municipio { Cve_est = "25", Cve_mun = "007", Descripcion = "CHOIX" },
            new Municipio { Cve_est = "25", Cve_mun = "008", Descripcion = "ELOTA" },
            new Municipio { Cve_est = "25", Cve_mun = "009", Descripcion = "ESCUINAPA" },
            new Municipio { Cve_est = "25", Cve_mun = "010", Descripcion = "EL FUERTE" },
            new Municipio { Cve_est = "25", Cve_mun = "011", Descripcion = "GUASAVE" },
            new Municipio { Cve_est = "25", Cve_mun = "012", Descripcion = "MAZATLAN" },
            new Municipio { Cve_est = "25", Cve_mun = "013", Descripcion = "MOCORITO" },
            new Municipio { Cve_est = "25", Cve_mun = "014", Descripcion = "ROSARIO" },
            new Municipio { Cve_est = "25", Cve_mun = "015", Descripcion = "SALVADOR ALVARADO" },
            new Municipio { Cve_est = "25", Cve_mun = "016", Descripcion = "SAN IGNACIO" },
            new Municipio { Cve_est = "25", Cve_mun = "017", Descripcion = "SINALOA" },
            new Municipio { Cve_est = "25", Cve_mun = "018", Descripcion = "NAVOLATO" },


        };

        foreach (Municipio m in Municipios)
        {
            context.Municipios.Add(m);
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
            new Sucursal { Nombre = "GUADALUPE VICTORIA", EstatusId = "V", FechaRegistro = new DateTime(2022, 1, 14) },
            new Sucursal { Nombre = "JUNTAS DEL HUMAYA", EstatusId = "V", FechaRegistro = new DateTime(2022, 1, 14) }
        };

        foreach (Sucursal s in suc)
        {
            context.Sucursales.Add(s);
        }


        var est = new Estatus[]
        {
            new Estatus { EstatusId = "V", Descripcion = "VIGENTE" },
            new Estatus { EstatusId = "B", Descripcion = "BAJA" },
        };

        foreach (Estatus e in est)
        {
            context.Estatus.Add(e);
        }


        var Empleados = new Empleado[]
        {
            new Empleado { Apaterno="ADMIN", Amaterno= "ADMIN", Nombre="ADMINISTRADOR", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="PRUEBA", NoExt="00", NoInt="", ColoniaId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado { Apaterno="ROJAS", Amaterno= "JIMENEZ", Nombre="FEDERICO", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="ROLANDO ARJONA", NoExt="1546", NoInt="", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado { Apaterno="BOJORQUEZ", Amaterno= "ALMANZA", Nombre="LUIS ENRIQUE", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="AZUCENA", NoExt="123", NoInt="4", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="LOPEZ", Amaterno= "ROJO", Nombre="RICARDO", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="GERANIO", NoExt="58", NoInt="B", ColoniaId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="LUGO", Amaterno= "CARDENAS", Nombre="ROGELIO", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="ANTONIO NAKAYAMA", NoExt="1546", NoInt="", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="DE LA ROCHA", Amaterno= "ACUÑA", Nombre="ALEJANDRA", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="12 DE OCTUBRE", NoExt="123", NoInt="4", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="ROMERO", Amaterno= "ALCAZAR", Nombre="MARIA", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="PATRIA", NoExt="58", NoInt="B", ColoniaId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="ESPINOZA", Amaterno= "LIZARRAGA", Nombre="FEDERICO", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="MEXICO 68", NoExt="1546", NoInt="", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="MARTINEZ", Amaterno= "FITCH", Nombre="ANA LUISA", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="EJERCITO MEXICANO", NoExt="123", NoInt="4", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="REGALADO", Amaterno= "CUADRAS", Nombre="MARIA", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1,
                        EstatusId="V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"),Calle="Prueba", NoExt="58", NoInt="B", ColoniaId="0001", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="ALMANZA", Amaterno= "LOPEZ", Nombre="FRANCISCO", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="BENITO JUAREZ", NoExt="1546", NoInt="", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1},

            new Empleado {Apaterno="LERMA", Amaterno= "ROMERO", Nombre="ANA MARIA", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5",
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        EstatusId="V", UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), Calle="AQUILES SERDAN", NoExt="123", NoInt="4", ColoniaId="0009", MunicipioId="001", EstadoId="01", SucursalId = 1}
        };

        foreach (Empleado e in Empleados)
        {
            context.Empleados.Add(e);
        }

        context.SaveChanges();

        

        var ProductosPrueba = new ProductoPrueba[]
        {
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "ASIENTOS 250 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "ASIENTOS 1 KG", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "ASIENTOS CUBETA 4 KG", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "ASIENTOS CUBETA 16 KG", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CAJA MANTEQUILLA PRIMAVERA 12 PZ/90 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHICHARRON 200 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHICHARRON GRANEL", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHILORIO 250 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHILORIO BOLSA", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHILORIO GRANEL", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHORIZO BOLSA 250 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHORIZO SARA TIRA 240 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "CHORIZO GRANEL", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "FRIJOL NATURAL 1/2", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "FRIJOL PUERCO 1/2", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "MACHACA 1 KG", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "MANTECA CUBETA 16 KG", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "MANTECA DE CERDO 1/2", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "QUESO CHESTER BARRA 250 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "QUESO CHESTER BARRA 500 GR", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "QUESO CHESTER BARRA 2.5 KG APROX", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "QUESO GOUDA OSORNO BARRA", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "TORTILLA DE HARINA 8 PZ", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "TORTILLA DE HARINA GRANDE", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "BOLIS", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
            new ProductoPrueba { CodigoBarras = "123456789", Categoria = 1, Nombre = "DIABLITOS", EstatusId = "V", UsuarioId = "ADMIN", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16") },
        };

        foreach (ProductoPrueba p in ProductosPrueba)
        {
            context.ProductosPrueba.Add(p);
        }

        var Productos = new Producto[]
        {
            new Producto{ Nombre = "FRIJOL", EstatusId = "V" },
            new Producto{ Nombre = "CHORIZO", EstatusId = "V" },
            new Producto{ Nombre = "MANTECA", EstatusId = "V" },
            new Producto{ Nombre = "ASIENTOS", EstatusId = "V" },
            new Producto{ Nombre = "CHICHARRON", EstatusId = "V" },
            new Producto{ Nombre = "CHILORIO", EstatusId = "V" },
        };
        foreach (Producto p in Productos)
        {
            context.Productos.Add(p);
        }

        context.SaveChanges();

        var SubProductos = new SubProducto[]
        {
            new SubProducto{ ProductoId = 1, Nombre = "PUERCO 1 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 1, Nombre = "PUERCO 1/2 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 1, Nombre = "NATURAL 1 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 1, Nombre = "NATURAL 1/2 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 2, Nombre = "TIRAS", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 2, Nombre = "BOLSAS", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 2, Nombre = "GRANEL", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "UNTO FRITO", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "MANTECA", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "ASIENTOS", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "MERMA", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "CUBETA MANTECA 16 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "CUBETA ASIENTOS 16 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "BANDEJA MANTECA 1/2 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 3, Nombre = "BANDEJA MANTECA 1 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 4, Nombre = "BANDEJA ASIENTOS 1/4 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 4, Nombre = "BANDEJA ASIENTOS 1 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 4, Nombre = "CUBETA ASIENTOS 4 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 5, Nombre = "CHICHARRON TOTAL", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 5, Nombre = "MANTECA", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 5, Nombre = "BOLSA CHICHARRON", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 5, Nombre = "CHICHARRON 1 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 5, Nombre = "MERMA", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 6, Nombre = "CHILORIO TOTAL", Medida = "KG", EstatusId = "V" },
            new SubProducto{ ProductoId = 6, Nombre = "BANDEJA 1/4 KG", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 6, Nombre = "BOLSAS", Medida = "PIEZA", EstatusId = "V" },
            new SubProducto{ ProductoId = 6, Nombre = "GRANEL", Medida = "KG", EstatusId = "V" },
        };
        foreach (SubProducto sp in SubProductos)
        {
            context.SubProductos.Add(sp);
        }

        var Turnos = new Turno[]
        {
            new Turno { Nombre = "MATUTINO", EstatusId = "V" },
            new Turno { Nombre = "VESPERTINO", EstatusId = "V" },
            new Turno { Nombre = "NOCTURNO", EstatusId = "V" },
        };

        foreach (Turno t in Turnos)
        {
            context.Turnos.Add(t);
        }

        var Usuarios = new Usuario[]
        {
            new Usuario { UsuarioId = "ADMIN", Password = Encrypt.GetSHA256("123"), EmpleadoId = 1, EstatusId = "V", FechaRegistro = DateTime.Now, UsuarioRegistro = "ADMIN" },
            new Usuario { UsuarioId = "FROJAS", Password = Encrypt.GetSHA256("123"), EmpleadoId = 2, EstatusId = "V", FechaRegistro = DateTime.Now, UsuarioRegistro = "ADMIN" },
        };
        foreach (Usuario u in Usuarios)
        {
            context.Usuarios.Add(u);
        }

        var Roles = new Roles[]
        {
            new Roles { UsuarioId = "ADMIN", RolId = 1, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16") },
            new Roles { UsuarioId = "ADMIN", RolId = 2, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16") },
            new Roles { UsuarioId = "FROJAS", RolId = 1, EstatusId = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="ADMIN", FechaRegistro=DateTime.Parse("2022-04-16") },

        };

        foreach (Roles r in Roles)
        {
            context.Roles.Add(r);
        }
        
        context.SaveChanges();

        var productostock = new ProductoStock[]
        {
            new ProductoStock { SucursalId = 1, ProductoId = 1, SubProductoId = 1, Cantidad = 150, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 1, SubProductoId = 2, Cantidad = 80, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 1, SubProductoId = 3, Cantidad = 250, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 1, SubProductoId = 4, Cantidad = 50, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },

            new ProductoStock { SucursalId = 1, ProductoId = 2, SubProductoId = 5, Cantidad = 70, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 2, SubProductoId = 6, Cantidad = 50, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 2, SubProductoId = 7, Cantidad = 86, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },

            new ProductoStock { SucursalId = 1, ProductoId = 3, SubProductoId = 8, Cantidad = 8, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 3, SubProductoId = 9, Cantidad = 200, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 3, SubProductoId = 10, Cantidad = 180, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 3, SubProductoId = 11, Cantidad = 9, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            
            new ProductoStock { SucursalId = 1, ProductoId = 4, SubProductoId = 16, Cantidad = 50, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },            
            new ProductoStock { SucursalId = 1, ProductoId = 4, SubProductoId = 17, Cantidad = 40, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 4, SubProductoId = 18, Cantidad = 15, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },

            new ProductoStock { SucursalId = 1, ProductoId = 5, SubProductoId = 19, Cantidad = 210, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 5, SubProductoId = 20, Cantidad = 80, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 5, SubProductoId = 21, Cantidad = 26, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 5, SubProductoId = 22, Cantidad = 10, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 5, SubProductoId = 23, Cantidad = 3, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },

            new ProductoStock { SucursalId = 1, ProductoId = 6, SubProductoId = 24, Cantidad = 34, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 6, SubProductoId = 25, Cantidad = 20, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 6, SubProductoId = 26, Cantidad = 17, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            new ProductoStock { SucursalId = 1, ProductoId = 6, SubProductoId = 27, Cantidad = 5, CantidadMinima = 10, UsoId = 1, EstatusId = "V", FechaRegistro=DateTime.Parse("2022-04-16") },
            


        };

        foreach (ProductoStock r in productostock)
        {
            context.ProductosStock.Add(r);
        }



        context.SaveChanges();
    }
}
