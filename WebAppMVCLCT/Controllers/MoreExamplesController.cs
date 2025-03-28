using Microsoft.AspNetCore.Mvc;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class MoreExamplesController : Controller
    {
        public readonly Databasecontext _context;
        public MoreExamplesController(Databasecontext context)
        {
            _context = context;
        }

        public IActionResult GettingUserInfo()
        {
            IList<UsersModel> obj;
            obj = (from s in _context.UsersModel select s).ToList();
            return View(obj);
        }

        public IActionResult Example()
        {
        
            return View();
        }


        [HttpGet]
        public IActionResult InsertDataWithValidations()
        {

            return View();
        }

        [HttpPost]
        public IActionResult InsertDataWithValidations(ValidateModel obj)
        {
            _context.validateModels.Add(obj);
            _context.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult AddStudents()
        {

            return View();
        }


        [HttpPost]
        public IActionResult AddStudents(Student obj)
        {
            _context.students.Add(obj);
            _context.SaveChanges();
            return View();
        }
    }
}
