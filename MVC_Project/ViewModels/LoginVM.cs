using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage ="Invalid email adress")]
        [Required(ErrorMessage ="This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Password { get; set; }
    }
}
