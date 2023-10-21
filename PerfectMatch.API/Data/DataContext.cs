using Microsoft.EntityFrameworkCore;
using PerfectMatch.Shared.Entities;

namespace PerfectMatch.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Ubication> Ubications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Profile>().HasIndex(c => c.PersonalDescription).IsUnique();
        }


    }
}
