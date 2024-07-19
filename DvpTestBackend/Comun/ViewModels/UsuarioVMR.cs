using System;

namespace Comun.ViewModels
{
    public class UsuarioVMR
    {
        public Guid Identificador { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public DateTime? FechaDeCreacion { get; set; }
    }
}
