using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.Repostories;
using MVC_Project.ViewModels;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MVC_Project.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        UserRepository userRepository = new UserRepository();
        AppDbContext appDbContext = new AppDbContext();
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                };
                userRepository.Add(newUser);
                return RedirectToAction("Login");
            }

            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var datavalue = appDbContext.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,model.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", JsonConvert.SerializeObject(datavalue));
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["login"] = "Email or password is incorrect";
                return View(model);
            }

        }
    }
}
