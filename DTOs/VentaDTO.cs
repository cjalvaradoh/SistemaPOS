using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPOS.DTOs
{
	public class VentaDTO
	{
		public int ClienteId { get; set; }  // Esto será 0 si es CF
		public int EmpleadoId { get; set; }
		public List<DetalleVentaDTO> Detalles { get; set; }

		// Nuevas propiedades para el cliente
		public string NitCliente { get; set; }  // NIT ingresado o "CF"
	}
}
