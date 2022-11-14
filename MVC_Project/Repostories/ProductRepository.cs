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
      

        //public  List<Product> GetAllOthersProduct()
        //{
        //    using var dbContext = new AppDbContext();

        //    var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

        //    return dbContext.Products.Include(x => x.Category).Where(x => x.IsDeleted == false && x.UserId!=sessionUser.UserId).ToList();
        //}
    }
}
