using System.ComponentModel.DataAnnotations;

namespace SistemaPOS.Models
{
    public class Venta
    {
        public int VentaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Total { get; set; }
    }

}
