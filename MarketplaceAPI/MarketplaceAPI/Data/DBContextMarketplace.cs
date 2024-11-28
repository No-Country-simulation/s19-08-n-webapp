using MarketplaceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Data
{
    public class DBContextMarketplace : DbContext
    {
        public DBContextMarketplace(DbContextOptions<DBContextMarketplace> options) : base(options)
        {

        }

        // DbSet para cada entidad
        public DbSet<User> Users { get; set; }

        public DbSet<ProjectContributor> ProjectContributors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user and role
            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.idRole)
                .OnDelete(DeleteBehavior.Restrict);

            //chat and user 
            modelBuilder.Entity<Chat>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.idUser)
                .OnDelete(DeleteBehavior.Restrict);

            //chat and project
            modelBuilder.Entity<Chat>()
                .HasOne<Project>()
                .WithMany()
                .HasForeignKey(c => c.idProject)
                .OnDelete(DeleteBehavior.Restrict);

            //message and chat 
            modelBuilder.Entity<Message>()
                .HasOne<Chat>()
                .WithMany()
                .HasForeignKey(m => m.idChat)
                .OnDelete(DeleteBehavior.Restrict);

            //notification and project 
            modelBuilder.Entity<Notification>()
                .HasOne<Project>()
                .WithMany()
                .HasForeignKey(n => n.idProject)
                .OnDelete(DeleteBehavior.Restrict);

            //notification and user
            modelBuilder.Entity<Notification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(n => n.idUserCollaborator)
                .OnDelete(DeleteBehavior.Restrict);

            //publication and user 
            modelBuilder.Entity<Publication>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.idUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(n => n.idUserCollaborator)
                .OnDelete(DeleteBehavior.Restrict);

            //project and publication 
            modelBuilder.Entity<Project>()
                .HasOne<Publication>()
                .WithMany()
                .HasForeignKey(pr => pr.idPublication)
                .OnDelete(DeleteBehavior.Restrict);

            //project and user (requester and collaborator)
            modelBuilder.Entity<Project>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(pr => pr.idUserRequester)
                .OnDelete(DeleteBehavior.Restrict);

            //rating and project
            modelBuilder.Entity<Evaluation>()
                .HasOne<Project>()
                .WithMany()
                .HasForeignKey(r => r.idProject)
                .OnDelete(DeleteBehavior.Restrict);

            //rating and user 
            modelBuilder.Entity<Evaluation>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.idEvaluatorUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evaluation>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.idEvaluatedUser)
                .OnDelete(DeleteBehavior.Restrict);

            //project and projectContributor

            modelBuilder.Entity<ProjectContributor>()
            .HasKey(pa => new { pa.idProject, pa.idUserContributor });

            modelBuilder.Entity<ProjectContributor>()
                .HasOne(pa => pa.Project)
                .WithMany()
                .HasForeignKey(pa => pa.idProject)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectContributor>()
                .HasOne(pa => pa.Applicant)
                .WithMany(u => u.ProjectApplications)
                .HasForeignKey(pa => pa.idUserContributor)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }//end class

}//end namespace
