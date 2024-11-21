using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.Models
{
	[Table("clientes")]
	public class Cliente
    {
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(20)]
        [Column("nit")]
        public string Nit { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [StringLength(20)]
        [Column("telefono")]
        public string Telefono { get; set; }
    }

}
