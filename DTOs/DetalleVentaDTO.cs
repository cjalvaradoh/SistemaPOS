using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.DTOs
{
	public class DetalleVentaDTO
	{
		public int ProductoId { get; set; }
		public int Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
	}
}
