using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class UsersController : Controller
    {
        public readonly Databasecontext _context;
        public UsersController(Databasecontext context)
        {
            _context = context;
        }


        [HttpGet] // on load
        public IActionResult CreateUser() ///action return a view also performing a backend logic
        {
            return View();
        }

        [HttpPost] // on click
        public IActionResult CreateUser(UsersModel obj)
        {

            // insert logic obj will be trabsfed to db
            _context.UsersModel.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }


        //get 
        public IActionResult UsersList()
        {
            IList<UsersModel> obj;
            obj = (from s in _context.UsersModel select s).ToList();
            return View(obj);
        }


        [HttpGet]
        public IActionResult UpdateUser(int ID)
        {
            UsersModel obj;
            obj = _context.UsersModel.FirstOrDefault(x => x.ID == ID);
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateUser(UsersModel obj)
        {
            _context.Attach(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("UsersList");
        }

        public IActionResult DeleteUser(int ID)
        {
            var res = _context.UsersModel.Find(ID);
            if (res != null)
            {
                _context.UsersModel.Remove(res);
                _context.SaveChanges();
            }
            return RedirectToAction("UsersList");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UsersModel obj)
        {
            var res = _context.UsersModel.Any(x => x.Email == obj.Email && x.Password == obj.Password);
            if (res)
            {
                return RedirectToAction("HomePage");
            }
            else
            {
                TempData["res"] = "Email or Password is Not Correct!";
            }
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }
    }
}
