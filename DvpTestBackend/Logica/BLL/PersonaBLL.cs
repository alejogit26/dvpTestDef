using Comun.ViewModels;
using Datos.DAL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;

namespace Logica.BLL
{
    public class PersonaBLL
    {
        public static ListadoPaginadoVMR<PersonaVMR> LeerTodo(int cantidad, int pagina, string textoBusqueda)
        {
            return PersonaDAL.LeerTodo(cantidad, pagina, textoBusqueda);
        }

        public static PersonaVMR leerUno(Guid id)
        {
            return PersonaDAL.leerUno(id);
        }

        public static Guid Crear(Personas item)
        {
            return PersonaDAL.Crear(item);
        }

        public static void Actualizar(PersonaVMR item)
        {
            PersonaDAL.Actualizar(item);
        }

        public static void Eliminar(List<Guid> ids)
        {
            PersonaDAL.Eliminar(ids);
        }
    }
}
