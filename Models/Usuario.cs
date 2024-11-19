using Microsoft.AspNetCore.Identity;

namespace SistemaPOS.Models
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
}
