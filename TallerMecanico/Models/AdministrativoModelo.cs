using System.ComponentModel.DataAnnotations;
namespace TallerMecanico.Models
{
    public class AdministrativoModelo
    {
        public int Idpersona { get; set; }
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El campo Identificacion es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string? Nacimiento { get; set; }
        [Required(ErrorMessage = "El campo Nacimiento es obligatorio")]
        public string? Cargo { get; set; }
        

    }
}