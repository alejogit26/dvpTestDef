using Comun.ViewModels;
using Logica.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;
using Modelo.Modelos;

namespace webAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LeerTodo(int cantidad = 10, int pagina = 0, string textoBusqueda = null)
        {
            var respuesta = new RespuestaVMR<ListadoPaginadoVMR<UsuarioVMR>>();

            try
            {
                respuesta.datos = UsuarioBLL.LeerTodo(cantidad, pagina, textoBusqueda);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpGet]
        public IHttpActionResult LeerUno(Guid id)
        {
            var respuesta = new RespuestaVMR<UsuarioVMR>();

            try
            {
                respuesta.datos = UsuarioBLL.LeerUno(id);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Elemento no encontrado.");
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpPost]
        public IHttpActionResult Crear(Usuario item)
        {
            var respuesta = new RespuestaVMR<Guid?>();

            try
            {
                item.Identificador = Guid.NewGuid();
                respuesta.datos = UsuarioBLL.Crear(item);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Guid id, UsuarioVMR item)
        {
            var respuesta = new RespuestaVMR<bool>();

            try
            {
                item.Identificador = id;
                UsuarioBLL.Actualizar(item);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(List<Guid> ids)
        {
            var respuesta = new RespuestaVMR<bool>();

            try
            {
                UsuarioBLL.Eliminar(ids);
                respuesta.datos = true;
                respuesta.codigo = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
    }
}