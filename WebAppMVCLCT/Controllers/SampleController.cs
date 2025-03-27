using Microsoft.AspNetCore.Mvc;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class SampleController : Controller
    {


        public IActionResult Add(ValuesModel obj)
        {
            int z = obj.x + obj.y;
            TempData["res"] = z;
            return View();
        }

        public IActionResult Sub()
        {
            return View();
        }
    }
}
