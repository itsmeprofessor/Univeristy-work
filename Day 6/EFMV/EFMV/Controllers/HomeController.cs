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
        public HomeController(MyDbContext dbdcontext)
        {
            this.dbdcontext = dbdcontext;
        }
        public ActionResult Index()
        {
            var homeusers = dbdcontext.Users.ToList();
            return View(homeusers);
        }
        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddUser addUser)
        {
            try
            {
                User u = new User()
                {
                    Name = addUser.Name,
                    Email = addUser.Email
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
        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var homeSelectedUser = dbdcontext.Users.SingleOrDefault(x => x.Id == id);
            return View(homeSelectedUser);
        }
        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var homeSelectedUser = dbdcontext.Users.SingleOrDefault(x => x.Id == id);
                homeSelectedUser.Name = user.Name;
                homeSelectedUser.Email = user.Email;
                dbdcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        //public HomeController(MyDbContext dbdcontext)
        //{
        //    this.dbdcontext = dbdcontext;
        //}

        //public IActionResult Index()
        //{
        //    var users = dbdcontext.Users.ToList();
        //    return View(users);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(AddUser addUser1)
        //{
        //    try
        //    {
        //        User u = new User()
        //        {
        //            Name = addUser1.Name,
        //            Email = addUser1.Email
        //        };
        //        dbdcontext.Users.Add(u);
        //        dbdcontext.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
