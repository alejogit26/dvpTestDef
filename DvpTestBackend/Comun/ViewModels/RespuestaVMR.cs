using System.Collections.Generic;
using System.Net;

namespace Comun.ViewModels
{
    public class RespuestaVMR<T>
    {
        public HttpStatusCode codigo { get; set; }
        public T datos { get; set; }

        public List<string> mensajes { get; set; }

        public RespuestaVMR()
        {
            codigo = HttpStatusCode.OK;
            datos = default(T);
            mensajes = new List<string>();
        }

    }
}
