using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class RegisterVM
    {
        [StringLength(16, ErrorMessage = "Maximum character limit is 16!")]
        public string Name { get; set; }
        [StringLength(24, ErrorMessage = "Maximum character limit is 24!")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
