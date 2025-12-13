using EFMV.Models;
using EFMV.Models.AddModels;
using EFMV.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFMV.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext dbdcontext;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(MyDbContext dbdcontext)
        {
            this.dbdcontext = dbdcontext;
        }

        public IActionResult Index()
        {
            var users = dbdcontext.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddUser addUser1)
        {
            try
            {
                User u = new User()
                {
                    Name = addUser1.Name,
                    Email = addUser1.Email
                };
                dbdcontext.Users.Add(u);
                dbdcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
