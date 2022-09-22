using System.ComponentModel.DataAnnotations;
namespace TallerMecanico.Models
{
    public class AutomovilModelo
    {
        public int IdAutomovil { get; set; }
        public int FKIdCliente { get; set; }
        public string? Identificacion { get; set; }

        public string? Placa { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? CiudadOrigen { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Capacidad { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Cilindraje { get; set; }
        
    }



}