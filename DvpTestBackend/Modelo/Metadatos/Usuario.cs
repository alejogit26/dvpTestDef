using System;
using System.ComponentModel.DataAnnotations;

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

            public DateTime? FechaDeCreacion { get; set; }
        }
    }
}
