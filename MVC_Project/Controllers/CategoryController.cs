using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.Repostories;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            var categories = categoryRepo.GetAllActive();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryAddVM category)
        {
            if (ModelState.IsValid)
            {
                Category newCate = new()
                {
                    Name = category.Name
                };
                categoryRepo.Add(newCate);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = categoryRepo.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category category,int id)
        {
            var data = categoryRepo.Get(id);
            data.Name=category.Name;
            categoryRepo.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = categoryRepo.Get(id);
            data.IsDeleted = true;
            categoryRepo.Update(data);
            return RedirectToAction("Index");
        }
    }
}
