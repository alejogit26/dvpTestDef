using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class UsuarioDAL
    {
        public static ListadoPaginadoVMR<UsuarioVMR> LeerTodo(int cantidad, int pagina, string textoBusqueda)
        {
            ListadoPaginadoVMR<UsuarioVMR> resultado = new ListadoPaginadoVMR<UsuarioVMR>();

            using (var db = DbConexionV6.Create())
            {
                var query = db.Usuario.Select(x => new UsuarioVMR
                {
                    Identificador = x.Identificador,
                    NombreUsuario = x.NombreUsuario,
                    Pass = x.Pass,
                    FechaDeCreacion = x.FechaDeCreacion
                    
                });

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query = query.Where(x => x.NombreUsuario.Contains(textoBusqueda));
                    
                }

                resultado.cantidadTotal = query.Count();
                resultado.elemento = query
                    .OrderBy(x => x.Identificador)
                    .Skip(pagina * cantidad)
                    .Take(cantidad)
                    .ToList();
            }

            return resultado;
        }

        public static UsuarioVMR LeerUno(Guid id)
        {
            UsuarioVMR item = null;

            using (var db = DbConexionV6.Create())
            {
                item = db.Usuario
                    .Where(x => x.Identificador == id)
                    .Select(x => new UsuarioVMR
                    {
                        Identificador = x.Identificador,
                        NombreUsuario = x.NombreUsuario,
                        Pass = x.Pass,
                        FechaDeCreacion = x.FechaDeCreacion
                        
                    })
                    .FirstOrDefault();
            }

            return item;
        }

        public static Guid Crear(Usuario item)
        {
            using (var db = DbConexionV6.Create())
            {
                db.Usuario.Add(item);
                db.SaveChanges();
            }
            return item.Identificador; 
        }

        public static void Actualizar(UsuarioVMR item)
        {
            using (var db = DbConexionV6.Create())
            {
                var usuarioUpdate = db.Usuario.Find(item.Identificador);

                if (usuarioUpdate != null)
                {
                    usuarioUpdate.NombreUsuario = item.NombreUsuario;
                    usuarioUpdate.Pass = item.Pass;
                    usuarioUpdate.FechaDeCreacion = item.FechaDeCreacion;
                    

                    db.Entry(usuarioUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró el usuario con Identificador: {item.Identificador}");
                }
            }
        }

        public static void Eliminar(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
                throw new ArgumentException("La lista de ids no puede estar vacía.", nameof(ids));

            using (var db = DbConexionV6.Create())
            {
                var id = ids.First();
                var usuario = db.Usuario.SingleOrDefault(x => x.Identificador == id);

                if (usuario != null)
                {
                    db.Usuario.Remove(usuario);
                    db.SaveChanges();
                }
            }
        }

        public static Usuario ValidarUsuario(string usuario, string contraseña)
        {
            using (var context = new DbConexionV6())
            {
                // Buscar el usuario con las credenciales proporcionadas
                return context.Usuario
                    .FirstOrDefault(u => u.NombreUsuario == usuario && u.Pass == contraseña);
            }
        }
    }
}
