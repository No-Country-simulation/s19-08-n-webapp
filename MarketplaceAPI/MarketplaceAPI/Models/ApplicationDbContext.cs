using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Data // Usa el namespace de tu proyecto
{
    public class ApplicationDbContext : IdentityDbContext<User> // Cambia "User" si usas otro nombre para tu clase de usuario
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
    }
}