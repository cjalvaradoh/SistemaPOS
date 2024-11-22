using System.ComponentModel.DataAnnotations;

namespace SistemaPOS.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string Dpi { get; set; }

        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contraseña { get; set; }
    }
}
