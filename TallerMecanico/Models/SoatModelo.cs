using System.ComponentModel.DataAnnotations;
namespace TallerMecanico.Models
{
    public class SoatModelo
    {
        public int IdSoat { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public int FKIdAutomovil { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? Placa { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public string? NumeroSoat { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public String? FechaCompra { get; set; }
        [Required(ErrorMessage = "campo es obligatorio")]
        public String? FechaExpira { get; set; }

    }
}
