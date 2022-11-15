using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using MVC_Project.Repostories;
using MVC_Project.ViewModels;
using Newtonsoft.Json;

namespace MVC_Project.Controllers
{
    public class ShopController : Controller
    {
        SalesRepository salesRepository = new();
        ProductRepository productRepository = new();
        UserRepository userRepository = new();
        public IActionResult Buy(int id)
        {
            var data = productRepository.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Buy(ShopVM model, Product product, int id)
        {
            var data = productRepository.Get(id);
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

            model.BuyerId = sessionUser.UserId;
            model.SellerId = product.UserId;
            model.ProductId = id;
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Sale newSale = new()
            {
                BuyerId = model.BuyerId,
                SellerId = data.UserId,
                ProductId = model.ProductId,
                Date = model.Date
            };

            if (sessionUser.Budget >= data.Price && data.Stock > 0)
            {
                sessionUser.Budget -= data.Price;

                var sellerUser = userRepository.Get(data.UserId);
                sellerUser.Budget += data.Price;
                data.Stock--;

                productRepository.Update(data);
                userRepository.Update(sessionUser);
                userRepository.Update(sellerUser);
                salesRepository.Add(newSale);
                TempData["succes"] = "Successfully bought";
                return RedirectToAction("Index", "Product");
            }
            TempData["notEnough"] = "Your budget too low";

            return RedirectToAction("Buy");
        }


    }
}
