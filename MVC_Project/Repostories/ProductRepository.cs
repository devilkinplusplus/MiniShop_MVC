using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Repostories
{
    public class ProductRepository
    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
        }

        public Product Get(int id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public List<Product> GetAllActive()
        {
            return dbContext.Products.Include(x=>x.Category).Where(x => x.IsDeleted == false).ToList();
        }
    }
}
