using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.DTOs
{
	public class VentaDTO
	{
		public int ClienteId { get; set; }
		public int EmpleadoId { get; set; }
		public List<DetalleVentaDTO> Detalles { get; set; }
	}
}
