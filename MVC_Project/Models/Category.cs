﻿namespace MVC_Project.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}
