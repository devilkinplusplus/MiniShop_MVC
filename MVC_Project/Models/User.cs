using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(16,ErrorMessage ="Maximum character limit is 16!")]
        public string Name { get; set; }
        [StringLength(24, ErrorMessage = "Maximum character limit is 24!")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Invalid email adrress")]
        public string Email { get; set; }
        [StringLength(maximumLength:16,ErrorMessage ="Password length cannot be bigger than 16")]
        public string Password { get; set; }
        public decimal Budget { get; set; } = 0;
        public List<Product>? Products { get; set; }
        public virtual ICollection<Sale> SellersSale { get; set; }
        public virtual ICollection<Sale> BuyersSale { get; set; }
    }
}
