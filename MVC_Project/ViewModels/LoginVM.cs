using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
