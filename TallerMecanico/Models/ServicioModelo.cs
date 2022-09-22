using System.ComponentModel.DataAnnotations;
namespace TallerMecanico.Models
{
    public class ServicioModelo
    {
        public int IdServicio { get; set; }
        public int FKIdCliente { get; set; }
        public int FKIdAutomovil { get; set; }
        public int FKIdMecanico { get; set; }
        public string? Placa { get; set; }
        public string? NivelAceite { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? NivelFrenos { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? NivelDireccion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? NivelRefrigerante { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Repuestos { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Fecha { get; set; }
    }
}
