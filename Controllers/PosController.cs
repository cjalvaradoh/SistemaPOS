using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Data;

namespace SistemaPOS.Controllers
{
	public class PosController : Controller
	{
		private readonly AppDbContext _context;

		public PosController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			// Obtener los productos, clientes y empleados de la base de datos
			var productos = _context.Producto.ToList();
			var clientes = _context.Cliente.ToList();
			var empleados = _context.Empleado.ToList();  

			// Asignar los datos a ViewBag
			ViewBag.Clientes = clientes;
			ViewBag.Empleados = empleados;  

			return View(productos);
		}
	}
}
