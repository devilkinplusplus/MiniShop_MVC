using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using MVC_Project.Repostories;
using Newtonsoft.Json;

namespace MVC_Project.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        ProductRepository productRepository = new();

        [NonAction]
        public List<Sale> SaleList()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));
            using var context = new AppDbContext();

            return context.Sales.Include(x => x.Product).Include(x => x.Seller).Include(x => x.Buyer).Where(x => x.SellerId == sessionUser.UserId).ToList();
        }

        [NonAction]
        public List<Sale> BuyingList()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));
            using var context = new AppDbContext();

            return context.Sales.Include(x => x.Product).Include(x => x.Seller).Include(x => x.Buyer).Where(x => x.BuyerId == sessionUser.UserId).ToList();
        }

        [NonAction]
        public List<Product> GetMyProducts()
        {
            using var dbContext = new AppDbContext();

            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

            return dbContext.Products.Include(x => x.Category).Where(x => x.IsDeleted == false && x.UserId == sessionUser.UserId).ToList();
        }

        public IActionResult Index()
        {
            var values = SaleList();
            return View(values);
        }

        public IActionResult Buyings()
        {
            var values = BuyingList();
            return View(values);
        }

        public IActionResult Product()
        {
            var values = GetMyProducts();
            return View(values);
        }

    }
}
