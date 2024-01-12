using B2C2_Web_Applications_2023_Gelegenheid_2.Data;
using B2C2_Web_Applications_2023_Gelegenheid_2.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Controllers
{
    public class LoginController : Controller
    {
        private readonly CollectionDBContext _db;

        public LoginController(CollectionDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if it's an admin login
                var admin = _db.Admins.FirstOrDefault(a => a.Name == model.UserName && a.Password == model.Password);

                if (admin != null)
                {
                    // Set role for the admin
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Name),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false // Non-persistent cookie
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Admin login successful
                    // Perform any necessary actions (e.g., set authentication cookie, redirect)
                    return RedirectToAction("Index", "Home");
                }

                // Check if it's a user login
                var user = _db.Users.FirstOrDefault(u => u.Name == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    // Set role for the user
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "User")
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false // Non-persistent cookie
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // User login successful
                    // Perform any necessary actions (e.g., set authentication cookie, redirect)
                    return RedirectToAction("Index", "Home");
                }

                // Invalid login credentials
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            // If the model state is invalid or login fails, return to the login view
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Sign the user out
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Clear any roles or claims associated with the user
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.User = new ClaimsPrincipal(identity);

            return RedirectToAction("Index", "Login"); // Redirect to /Login/Index
        }

    }
}
