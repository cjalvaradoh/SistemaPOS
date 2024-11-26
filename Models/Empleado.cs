using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.Models
{
    [Table("empleados")]
    public class Empleado
    {
		[Column("empleado_id")]
        public int EmpleadoId { get; set; }

		[Column("nombre")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }



        [StringLength(50)]
        [Column("apellido")]
        public string Apellido { get; set; }


        [StringLength(13)]
        [Column("dpi")]
        public string Dpi { get; set; }


        [StringLength(50)]
        [Column("cargo")]
        public string Cargo { get; set; }


        [StringLength(450)]
        [Column("usuario_id")]
        public string UsuarioId { get; set; } // Cambiado a string
    }
}
