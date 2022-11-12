﻿using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    public class ProductEditVM
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
