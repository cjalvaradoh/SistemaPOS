using SistemaPOS.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.Models
{
	[Table("ventas")]
	public class Venta
	{
		[Column("venta_id")]
		public int? Id { get; set; }

		[Column("fecha")]
		public DateTime Fecha { get; set; }

		[Column("total")]
		public decimal Total { get; set; }

		[Column("cliente_id")]
		public int ClienteId { get; set; }

		[ForeignKey("ClienteId")]
		public Cliente? Cliente { get; set; } // Relacion de uno a uno

		[Column("empleado_id")]
		public int EmpleadoId { get; set; }

		[ForeignKey("EmpleadoId")]
		public Empleado? Empleado { get; set; } // Relacion de uno a uno
		public ICollection<DetalleVenta> DetallesVenta { get; set; }

	}

}
