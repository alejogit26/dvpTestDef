﻿using Comun.ViewModels;
using Datos.DAL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.BLL
{
    public class UsuarioBLL
    {
        public static ListadoPaginadoVMR<UsuarioVMR> LeerTodo(int cantidad, int pagina, string textoBusqueda)
        {
            return UsuarioDAL.LeerTodo(cantidad, pagina, textoBusqueda);
        }

        public static UsuarioVMR LeerUno(Guid id)
        {
            return UsuarioDAL.LeerUno(id);
        }

        public static Guid Crear(Usuario item)
        {
            return UsuarioDAL.Crear(item);
        }

        public static void Actualizar(UsuarioVMR item)
        {
            UsuarioDAL.Actualizar(item);
        }

        public static void Eliminar(List<Guid> ids)
        {
            UsuarioDAL.Eliminar(ids);
        }
    }
}