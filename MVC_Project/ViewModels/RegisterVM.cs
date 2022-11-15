using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="This field is required")]
        [StringLength(16, ErrorMessage = "Maximum character limit is 16!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]

        [StringLength(24, ErrorMessage = "Maximum character limit is 24!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]

        [EmailAddress(ErrorMessage = "Invalid email adrress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]

        [StringLength(maximumLength: 16, 
            ErrorMessage = "Password length cannot be bigger than 16")]
        public string Password { get; set; }
    }
}
