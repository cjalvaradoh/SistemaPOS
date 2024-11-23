using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
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

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Codigo,Nombre,Descripcion,Precio,Stock,FotoUrl")] Producto producto, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    try
                    {
                        // Subir la imagen a Cloudinary
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(Imagen.FileName, Imagen.OpenReadStream()),
                            Folder = "productos" // Carpeta dentro de tu cuenta de Cloudinary
                        };

                        var uploadResult = _cloudinary.Upload(uploadParams);

                        // Validar si la subida fue exitosa
                        if (uploadResult != null && uploadResult.Url != null)
                        {
                            producto.FotoUrl = uploadResult.Url.ToString(); // Guardar la URL en el modelo
                        }
                        else
                        {
                            ModelState.AddModelError("", "No se pudo subir la imagen a Cloudinary.");
                            return View(producto); // Devolver a la vista con el error
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores en la subida de la imagen
                        ModelState.AddModelError("", $"Error al subir la imagen: {ex.Message}");
                        return View(producto); // Devolver a la vista con el error
                    }
                }

                // Guardar el producto en la base de datos
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, regresar a la vista con los errores
            return View(producto);
        }


    }
}
