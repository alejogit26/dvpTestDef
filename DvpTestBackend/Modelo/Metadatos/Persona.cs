using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Modelos
{
    [MetadataType(typeof(PersonaMetadato))]
    public partial class Persona
    {
    }

    public class PersonaMetadato
    {
        [Required]
        public Guid Identificador { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroDeIdentificacion { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public string TipoIdentificacion { get; set; }

        [Required]
        public DateTime FechaDeCreacion { get; set; }
        public string IdentificacionTipo { get; set; }
        public string NombresCompletos { get; set; }


    }
}
