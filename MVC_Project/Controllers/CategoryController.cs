﻿using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.Repostories;

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
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Add(category);
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
