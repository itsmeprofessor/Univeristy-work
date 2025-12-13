using EFMV.Models;
using EFMV.Models.AddModels;
using EFMV.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFMV.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _MyDbContext;
        public UserController(MyDbContext myDbContext)
        {
            this._MyDbContext = myDbContext;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var dbUsers=_MyDbContext.Users.ToList();
            return View(dbUsers);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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
                _MyDbContext.Users.Add(u);
                _MyDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var selectedUser=_MyDbContext.Users.SingleOrDefault(x=>x.Id==id);
            return View(selectedUser);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var selectedUser = _MyDbContext.Users.SingleOrDefault(x => x.Id == id);
                selectedUser.Name = user.Name;
                selectedUser.Email = user.Email;
                _MyDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                var selectedUser = _MyDbContext.Users.SingleOrDefault(x => x.Id == id);
                _MyDbContext.Users.Remove(selectedUser);
                _MyDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
