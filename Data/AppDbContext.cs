using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaPOS.Models;

namespace SistemaPOS.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Venta> Venta { get; set; }
		public DbSet<DetalleVenta> DetallesVenta { get; set; }
		public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Producto> Producto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        
    }
}
