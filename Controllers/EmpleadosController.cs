using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            // Cargar la lista de usuarios para el desplegable
            ViewData["Usuarios"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,Apellido,Dpi,Cargo,UsuarioId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                // Asignar un usuario por defecto si no se selecciona ninguno
                if (empleado.UsuarioId == null)
                {
                    var usuario = await _context.Users.FirstOrDefaultAsync();
                    if (usuario == null)
                    {
                        ModelState.AddModelError("", "No hay usuarios disponibles para asignar a este empleado.");
                        return View(empleado);
                    }
                    empleado.UsuarioId = usuario.Id;
                }

                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["Usuarios"] = new SelectList(_context.Users, "Id", "UserName", empleado.UsuarioId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            // Cargar la lista de usuarios para el desplegable
            ViewData["Usuarios"] = new SelectList(_context.Users, "Id", "UserName", empleado.UsuarioId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Nombre,Apellido,Dpi,Cargo,UsuarioId")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Recargar la lista de usuarios si algo falla
            ViewData["Usuarios"] = new SelectList(_context.Users, "Id", "UserName", empleado.UsuarioId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }



        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoId == id);
        }
    }
}
