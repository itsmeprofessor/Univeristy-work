using Microsoft.EntityFrameworkCore;
using RestfulApisWithRepositoryDesignPattern.Models.Entities;

namespace RestfulApisWithRepositoryDesignPattern.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }


        //Seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "JohnDoe@gmail.com"
            },

            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "JaneSmith@gmail.com"
            }
            );
        }
    }
}

