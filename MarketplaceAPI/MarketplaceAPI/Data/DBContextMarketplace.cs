using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Data
{
    public class DBContextMarketplace : IdentityDbContext<User>
    {
        public DBContextMarketplace(DbContextOptions<DBContextMarketplace> options) : base(options)
        {

        }

        // DbSet para cada entidad
        //public DbSet<User> Users { get; set; }

        public DbSet<ProjectContributor> ProjectContributors { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

    }//end class

}//end namespace
