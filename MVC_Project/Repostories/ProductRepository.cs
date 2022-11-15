using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using Newtonsoft.Json;

namespace MVC_Project.Repostories
{
    public class ProductRepository:GenericRepository<Product>
    {
        public List<Product> GetAllActive()
        {
            using var dbContext = new AppDbContext();
            return dbContext.Products.Include(x=>x.Category).Where(x => x.IsDeleted == false).ToList();
        }


      
    }
}
