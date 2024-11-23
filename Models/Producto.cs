using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.Models
{
    [Table("productos")] // Coincide con la tabla en SQL
    public class Producto
    {
        [Key]
        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("codigo")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [StringLength(255)]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("foto_url")]
        public string? FotoUrl { get; set; }

        [Column("thumbnail_url")]
        public string? thumbnail_url { get; set; }
    }
}
