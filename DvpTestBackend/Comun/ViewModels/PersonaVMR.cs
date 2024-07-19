using System;

namespace Comun.ViewModels
{
    public class PersonaVMR
    {
        public Guid Identificador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDeIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime FechaDeCreacion { get; set; }

        public string IdentificacionTipo { get; set; }

        public string NombresCompletos { get; set; }
    }
}
