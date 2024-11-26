using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaPOS.Models
{
	[Table("detalle_ventas")]
	public class DetalleVenta
	{
		[Column("detalle_venta_id")]
		public int Id { get; set; }

		[Column("venta_id")]
		public int VentaId { get; set; }

		[Column("producto_id")]
		public int ProductoId { get; set; }
		[Column("cantidad")]
		public int Cantidad { get; set; }
		[Column("precio_unitario")]
		public decimal PrecioUnitario { get; set; }
		[Column("subtotal")]
		public decimal subtotal { get; set; }

		[ForeignKey("VentaId")]
		public Venta? Venta { get; set; }
		[ForeignKey("ProductoId")]
		public Producto? Producto { get; set; }
	}
}
