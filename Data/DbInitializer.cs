namespace SysSara.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated(); //Revisa si esta creada la bd, si no esta la crea.

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
            new Rol { Descripcion = "Admin", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Secretaria", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Productor", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            new Rol { Descripcion = "Ventas", Estatus = "V", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), FechaEstatus=DateTime.Parse("2022-04-16")},
            
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
            new Municipio { Cve_est = "01", Cve_mun = "001", Descripcion = "Aguascalientes" },
            new Municipio { Cve_est = "01", Cve_mun = "002", Descripcion = "Asientos" },
            new Municipio { Cve_est = "01", Cve_mun = "003", Descripcion = "Calvillo" },
            new Municipio { Cve_est = "01", Cve_mun = "004", Descripcion = "Cosío" },
            new Municipio { Cve_est = "01", Cve_mun = "005", Descripcion = "Jesús María" },
            new Municipio { Cve_est = "01", Cve_mun = "006", Descripcion = "Pabellón de Arteaga" },
            new Municipio { Cve_est = "01", Cve_mun = "007", Descripcion = "Rincón de Romos" },
            new Municipio { Cve_est = "01", Cve_mun = "008", Descripcion = "San José de Gracia" },
            new Municipio { Cve_est = "01", Cve_mun = "009", Descripcion = "Tepezalá" },
            new Municipio { Cve_est = "01", Cve_mun = "010", Descripcion = "El Llano" },
            new Municipio { Cve_est = "01", Cve_mun = "011", Descripcion = "San Francisco de los Romo" },
            new Municipio { Cve_est = "02", Cve_mun = "001", Descripcion = "Ensenada" },
            new Municipio { Cve_est = "02", Cve_mun = "002", Descripcion = "Mexicali" },
            new Municipio { Cve_est = "02", Cve_mun = "003", Descripcion = "Tecate" },
            new Municipio { Cve_est = "02", Cve_mun = "004", Descripcion = "Tijuana" },
            new Municipio { Cve_est = "02", Cve_mun = "005", Descripcion = "Playas de Rosarito" },
            new Municipio { Cve_est = "02", Cve_mun = "006", Descripcion = "San Quintín" },
            new Municipio { Cve_est = "02", Cve_mun = "007", Descripcion = "San Felipe" },
            new Municipio { Cve_est = "03", Cve_mun = "001", Descripcion = "Comondú" },
            new Municipio { Cve_est = "03", Cve_mun = "002", Descripcion = "Mulegé" },
            new Municipio { Cve_est = "03", Cve_mun = "003", Descripcion = "La Paz" },
            new Municipio { Cve_est = "03", Cve_mun = "008", Descripcion = "Los Cabos" },
            new Municipio { Cve_est = "03", Cve_mun = "009", Descripcion = "Loreto" },
            new Municipio { Cve_est = "04", Cve_mun = "001", Descripcion = "Calkiní" },
            new Municipio { Cve_est = "04", Cve_mun = "002", Descripcion = "Campeche" },
            new Municipio { Cve_est = "04", Cve_mun = "003", Descripcion = "Carmen" },
            new Municipio { Cve_est = "04", Cve_mun = "004", Descripcion = "Champotón" },
            new Municipio { Cve_est = "04", Cve_mun = "005", Descripcion = "Hecelchakán" },
            new Municipio { Cve_est = "04", Cve_mun = "006", Descripcion = "Hopelchén" },
            new Municipio { Cve_est = "04", Cve_mun = "007", Descripcion = "Palizada" },
            new Municipio { Cve_est = "04", Cve_mun = "008", Descripcion = "Tenabo" },
            new Municipio { Cve_est = "04", Cve_mun = "009", Descripcion = "Escárcega" },
            new Municipio { Cve_est = "04", Cve_mun = "010", Descripcion = "Calakmul" },
            new Municipio { Cve_est = "04", Cve_mun = "011", Descripcion = "Candelaria" },
            

        };

        foreach (Municipio m in Municipios)
        {
            context.Municipios.Add(m);
        }

        var Poblaciones = new Poblacion[] 
        {
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0001", Descripcion = "Aguascalientes" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0094", Descripcion = "Granja Adelita" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0096", Descripcion = "Agua Azul" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0100", Descripcion = "Rancho Alegre" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0102", Descripcion = "Los Arbolitos [Rancho]" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0104", Descripcion = "Ardillas de Abajo (Las Ardillas)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0106", Descripcion = "Arellano" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0112", Descripcion = "Bajío los Vázquez" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0113", Descripcion = "Bajío de Montoro" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0120", Descripcion = "Buenavista de Peñuelas" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0121", Descripcion = "Cabecita 3 Marías (Rancho Nuevo)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0125", Descripcion = "Cañada Grande de Cotorina" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0126", Descripcion = "Cañada Honda [Estación]" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0127", Descripcion = "Los Caños" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0128", Descripcion = "El Cariñán" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0135", Descripcion = "El Cedazo (Cedazo de San Antonio)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0138", Descripcion = "Centro de Arriba (El Taray)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0139", Descripcion = "Cieneguilla (La Lumbrera)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0141", Descripcion = "Cobos" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0144", Descripcion = "El Colorado (El Soyatal)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0146", Descripcion = "El Conejal" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0157", Descripcion = "Cotorina de Abajo" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0162", Descripcion = "Coyotes" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0166", Descripcion = "La Huerta (La Cruz)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0170", Descripcion = "Cuauhtémoc (Las Palomas)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0171", Descripcion = "Los Cuervos (Los Ojos de Agua)" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0172", Descripcion = "San José [Granja]" },
            new Poblacion { Cve_est = "01", Cve_mun = "001", Cve_pob = "0176", Descripcion = "La Chiripa" },
        };

        foreach (Poblacion p in Poblaciones)
        {
            context.Poblaciones.Add(p);
        }

        ///Se llenan con datos de prueba las tablas de sistema///////////////////////////////////////////////////////////////////////////////////////

        var Roles = new Roles[]
        {
            new Roles { RolId=1, Rol = 1, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=1 },
            new Roles { RolId=2, Rol = 2, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=1 },
            new Roles { RolId=1, Rol = 2, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=2 },
            new Roles { RolId=2, Rol = 3, Estatus = "V", FechaEstatus = DateTime.Parse("2022-04-16"), UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), EmpleadoId=3 }
        };

        foreach (Roles r in Roles)
        {
            context.Roles.Add(r);
        }

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


        var Empleados = new Empleado[]
        {
            /* new Empleado {Apaterno="Admin", Amaterno= "Admin", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1, 
                        Estatus="V", Usuario="Admin", Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16")},
            new Empleado {Apaterno="Rojas", Amaterno= "Jimenez", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        Estatus="V", Usuario="FRojas", Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16")},
            new Empleado {Apaterno="Prueba", Amaterno= "Prueba", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        Estatus="V", Usuario="FPrueba", Contraseña="123", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16")} */

            new Empleado {Apaterno="Admin", Amaterno= "Admin", Nombre="Administrador", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ADAA220101XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="6671223344", Celular="6672334455", Rfc="ADAA2201015R7", Categoria=1, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=1, 
                        Estatus="V", Usuario="Admin", Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), DomicilioId = 1},
            new Empleado {Apaterno="Rojas", Amaterno= "Jimenez", Nombre="Federico", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="ROJF931201XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="6671223344", Celular="6672334455", Rfc="ROJF931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=2,
                        Estatus="V", Usuario="FRojas", Contraseña="123", UserRegistro="Admin", FechaRegistro=DateTime.Parse("2022-04-16"), DomicilioId = 2},
            new Empleado {Apaterno="Prueba", Amaterno= "Prueba", Nombre="Prueba", FechaNacimiento=DateTime.Parse("2005-09-01"), Curp="PRPP931201XXXXXX", SeguridadSocial="1254ddfg5", 
                        Telefono="1234567890", Celular="1234567890", Rfc="PRPP931201A91", Categoria=2, TipoSangre=2, FechaIngreso=DateTime.Parse("2022-04-16"), DepartamentoId=3,
                        Estatus="V", Usuario="FPrueba", Contraseña="123", UserRegistro="Prueba", FechaRegistro=DateTime.Parse("2022-04-16"), DomicilioId = 3}
        };

        foreach (Empleado e in Empleados)
        {
            context.Empleados.Add(e);
        }

        var Domicilios = new Domicilio[]
        {
            /* new Domicilio { Calle="Prueba", NoExt="58", NoInt="B", Colonia=1, PoblacionId="0001", MunicipioId="001", EstadoId="01", EmpleadoId = 1 },
            new Domicilio { Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia=9, PoblacionId="0001", MunicipioId="001", EstadoId="01", EmpleadoId = 2  },
            new Domicilio { Calle="Probando", NoExt="123", NoInt="4", Colonia=9, PoblacionId="0001", MunicipioId="001", EstadoId="01", EmpleadoId = 3  } */

            new Domicilio { Calle="Prueba", NoExt="58", NoInt="B", Colonia="1", PoblacionId="0001", MunicipioId="001", EstadoId="01" },
            new Domicilio { Calle="Rolando Arjona", NoExt="1546", NoInt="", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01"  },
            new Domicilio { Calle="Probando", NoExt="123", NoInt="4", Colonia="9", PoblacionId="0001", MunicipioId="001", EstadoId="01"  }
        };

        foreach (Domicilio d in Domicilios)
        {
            context.Domicilios.Add(d);
        }



        context.SaveChanges();
    }
}
    