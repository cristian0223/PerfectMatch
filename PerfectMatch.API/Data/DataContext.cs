using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.Shared.Entities;

namespace PerfectMatch.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Ubication> Ubications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Profile>().HasIndex(c => c.PersonalDescription).IsUnique();
            modelBuilder.Entity<Appointment>().HasIndex(c => c.Hour).IsUnique();
            modelBuilder.Entity<Ubication>().HasIndex(c => c.Latitude).IsUnique();
            modelBuilder.Entity<Notification>().HasIndex(c => c.Description).IsUnique();
            modelBuilder.Entity<Message>().HasIndex(c => c.Content).IsUnique();
            modelBuilder.Entity<Comment>().HasIndex(c => c.Date).IsUnique();
            modelBuilder.Entity<Post>().HasIndex(c => c.Title).IsUnique();



        }


    }
}
