using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Category cannot be empty!")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
