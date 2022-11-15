using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using MVC_Project.Repostories;
using MVC_Project.ViewModels;
using Newtonsoft.Json;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        AppDbContext appDbContext = new AppDbContext();

        [NonAction]
        public List<Product> GetAllOthersProduct()
        {
            using var dbContext = new AppDbContext();

            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));

            return dbContext.Products.Include(x => x.Category).Where(x => x.IsDeleted == false && x.UserId != sessionUser.UserId).ToList();
        }

        public IActionResult Index()
        {
            var products = GetAllOthersProduct();  
            return View(products);
        }
        public IActionResult Create()
        {
            CategoryValues();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM product)
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("username"));
            product.UserId = sessionUser.UserId;
            if (ModelState.IsValid)
            {
                Product prod = new()
                {
                    Name = product.Name,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    Price = product.Price,
                    Stock = product.Stock,
                    UserId=sessionUser.UserId
                };

                productRepository.Add(prod);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = productRepository.Get(id);
            CategoryValues();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM product,int id)
        {
            var data = productRepository.Get(id);

            if (ModelState.IsValid)
            {
                data.Name = product.Name;
                data.Description = product.Description;
                data.CategoryID = product.CategoryID;
                data.Price = product.Price;
                data.Stock = product.Stock;
             
                productRepository.Update(data);
                return RedirectToAction("Index");
            }
            return View(product);

        }

        public IActionResult Delete(int id)
        {
            var data = productRepository.Get(id);
            data.IsDeleted = true;
            productRepository.Update(data);
            return RedirectToAction("Index");
        }


        [NonAction]
        private void CategoryValues()
        {
            List<SelectListItem> categories = 
                (from y in appDbContext.Categories.ToList().Where(x => x.IsDeleted == false)
                                               select new SelectListItem
                                               {
                                                   Value = y.CategoryID.ToString(),
                                                   Text = y.Name
                                               }).ToList();
            ViewBag.categoryValues = categories;
        }



    }
}
