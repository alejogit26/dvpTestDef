using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class PersonaDAL
    {
        public static ListadoPaginadoVMR<PersonaVMR> LeerTodo(int cantidad, int pagina, string textoBusqueda)
        {
            ListadoPaginadoVMR<PersonaVMR> resultado = new ListadoPaginadoVMR<PersonaVMR>();

            using (var db = DbConexionV6.Create())
            {
                var query = db.Personas.Select(x => new PersonaVMR
                {
                    Identificador = x.Identificador,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    NumeroDeIdentificacion = x.NumeroDeIdentificacion,
                    Email = x.Email,
                    TipoIdentificacion = x.TipoIdentificacion,
                    FechaDeCreacion = x.FechaDeCreacion,
                    IdentificacionTipo = x.IdentificacionTipo,
                    NombresCompletos = x.NombresCompletos
                });

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query = query.Where(x => x.NumeroDeIdentificacion.Contains(textoBusqueda) || (x.Nombres + " " + x.Apellidos).Contains(textoBusqueda));
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


        public static PersonaVMR leerUno(Guid id)
        {
            PersonaVMR item = null;

            using (var db = DbConexionV6.Create())
            {
                item = db.Personas
                    .Where(x => x.Identificador == id)
                    .Select(x => new PersonaVMR
                    {
                        Identificador = x.Identificador,
                        Nombres = x.Nombres,
                        Apellidos = x.Apellidos,
                        NumeroDeIdentificacion = x.NumeroDeIdentificacion,
                        Email = x.Email,
                        TipoIdentificacion = x.TipoIdentificacion,
                        FechaDeCreacion = x.FechaDeCreacion,
                        IdentificacionTipo = x.IdentificacionTipo,
                        NombresCompletos = x.NombresCompletos
                    })
                    .FirstOrDefault();
            }

            return item;
        }

        public static Guid Crear(Personas item)
        {

            using (var db = DbConexionV6.Create())
            {                
                db.Personas.Add(item);
                db.SaveChanges();
            }
            return item.Identificador; // Retornamos el Identificador generado
        }

        public static void Actualizar(PersonaVMR item)
        {
            using (var db = DbConexionV6.Create())
            {
                var personaUpdate = db.Personas.Find(item.Identificador);

                if (personaUpdate != null)
                {
                    personaUpdate.Nombres = item.Nombres;
                    personaUpdate.Apellidos = item.Apellidos;
                    personaUpdate.NumeroDeIdentificacion = item.NumeroDeIdentificacion;
                    personaUpdate.Email = item.Email;
                    personaUpdate.TipoIdentificacion = item.TipoIdentificacion;
                    personaUpdate.FechaDeCreacion = item.FechaDeCreacion;
                     

                    db.Entry(personaUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró la persona con Identificador: {item.Identificador}");
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
                var persona = db.Personas.SingleOrDefault(x => x.Identificador == id);

                if (persona != null)
                {
                    db.Personas.Remove(persona);
                    db.SaveChanges();
                }
            }
        }

    }
}
