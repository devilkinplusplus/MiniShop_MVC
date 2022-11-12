using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-0AVBIPRU9F2;Database=MiniMVC;" +
                "integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
