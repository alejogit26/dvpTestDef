using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class UsuarioVMR
    {
        public Guid Identificador { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaDeCreacion { get; set; }
    }
}
