using System.ComponentModel.DataAnnotations;

namespace TallerMecanico.Models
{
    public class PersonaModelo
    {
        public int Idpersona { get; set; }
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo Nacimiento es obligatorio")]
        public string? Nacimiento { get; set; }
        [Required(ErrorMessage = "El campo Ciudad es obligatorio")]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }
    }
}
