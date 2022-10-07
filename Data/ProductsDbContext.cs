using Microsoft.EntityFrameworkCore;
using RabbitMQTutorial.Models;

namespace RabbitMQTutorial.Data
{
    public class ProductsDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProductsDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }
    }
}
