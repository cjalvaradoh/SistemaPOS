using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Data;
using SistemaPOS.Models;

namespace SistemaPOS.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly Cloudinary _cloudinary;

        public ProductosController(AppDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Producto.ToListAsync();
            return View(productos); 
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Codigo,Nombre,Descripcion,Precio,Stock")] Producto producto, IFormFile FotoUrl)
        {
            if (ModelState.IsValid)
            {
                if (FotoUrl != null)
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(FotoUrl.FileName, FotoUrl.OpenReadStream()),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill")
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    producto.FotoUrl = uploadResult.SecureUrl.ToString();

                    var thumbnailParams = new Transformation().Width(150).Height(150).Crop("thumb");
                    producto.thumbnail_url = _cloudinary.Api.UrlImgUp.Transform(thumbnailParams).BuildUrl(uploadResult.PublicId);
                }
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Codigo,Nombre,Descripcion,Precio,Stock")] Producto producto, IFormFile FotoUrl)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (FotoUrl != null)
                    {
                        // Subir la nueva imagen a Cloudinary
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(FotoUrl.FileName, FotoUrl.OpenReadStream()),
                            Transformation = new Transformation().Width(500).Height(500).Crop("fill")
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                        producto.FotoUrl = uploadResult.SecureUrl.ToString();

                        // Generar la miniatura
                        var thumbnailParams = new Transformation().Width(150).Height(150).Crop("thumb");
                        producto.thumbnail_url = _cloudinary.Api.UrlImgUp.Transform(thumbnailParams).BuildUrl(uploadResult.PublicId);
                    }

                    // Actualizar el producto en la base de datos
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Producto
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        private bool ProductoExists(int productoId)
        {
            throw new NotImplementedException();
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Producto.FindAsync(id);
            if (productos != null)
            {
                _context.Producto.Remove(productos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoId == id);
        }
    }
}
