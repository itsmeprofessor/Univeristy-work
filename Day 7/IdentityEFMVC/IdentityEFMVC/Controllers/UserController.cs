using IdentityEFMVC.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEFMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegistrationModel registeration)
        {

        }
    }
}
