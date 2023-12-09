using Azure;
using lab_4.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace lab_4
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Port>()
            .HasMany(p => p.history)  // Assuming you have a property like List<Ship> CurrentShips in Port
            .WithOne(s => s.currentPort)
            .HasForeignKey(s => s.ID);

            builder.Entity<Container>()
            .HasMany(c => c.items);

            builder.Entity<List<IAbstractItem>>()
            .HasNoKey();

            base.OnModelCreating(builder);
        }
    }
}