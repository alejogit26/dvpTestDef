using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Metadatos
{
    public class Usuario
    {
        [MetadataType(typeof(UsuarioMetadato))]
        public partial class Usuarios
        {

        }

        public class UsuarioMetadato
        {
            [Required]
            public Guid Identificador { get; set; }

            [Required]
            [StringLength(200)]
            public string NombreUsuario { get; set; }

            [Required]
            [StringLength(100)]
            public string Pass { get; set; }

            [Required]
            public DateTime FechaDeCreacion { get; set; }
        }
    }
}
