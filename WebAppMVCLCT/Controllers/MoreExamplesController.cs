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
    }
}
