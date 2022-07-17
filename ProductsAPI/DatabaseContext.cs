using Microsoft.EntityFrameworkCore;
using ProductsAPI.Entities;

namespace ProductsAPI
{
    public class DatabaseContext :DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("ApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Product>()
                .Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(25);
        }



    }
}
