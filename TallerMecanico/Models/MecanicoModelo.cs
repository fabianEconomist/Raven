using System.ComponentModel.DataAnnotations;
namespace TallerMecanico.Models
{
    public class MecanicoModelo
    {
        public int Idpersona { get; set; }
        public int IdMecanico { get; set; }

        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El campo Identificacion es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string? Nacimiento { get; set; }
        [Required(ErrorMessage = "El campo Nacimiento es obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El campo direccion es obligatorio")]
        public string? Escolaridad { get; set; }
        [Required(ErrorMessage = "El campo escolaridad es obligatorio")]
        public string? Telefono { get; set; }

    }
}
