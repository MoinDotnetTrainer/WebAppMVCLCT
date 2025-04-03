using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLCT.Controllers
{

    public class Test
    {
        public string? Name { get; set; }
    }
    public class StateManagenentController : Controller
    {
        public IActionResult StoringData()
        {


            ViewBag.vb = "Trying to store data with Viewbag:" + System.DateTime.Now.ToLongDateString();


            ViewData["vd"] = "Trying to store data with view data:" + System.DateTime.Now.ToLongDateString();


            TempData["td"] = "Trying to store data with temp data:" + System.DateTime.Now.ToLongDateString();
            //  return View();
            return RedirectToAction("Testing");
            //  return RedirectToAction("Index", "Home");
        }

        public IActionResult RetriveData()
        {
            // no data 

            return View();
            //   return RedirectToAction("GetData");
        }

        public IActionResult GetData()
        {
            // no data 
            return View();
        }

        public IActionResult ExampleOnViewBag()
        {

            List<Test> test = new List<Test>() {
            new Test{ Name="Abc"},
             new Test{ Name="xyz"},
              new Test{ Name="pqr"},
               new Test{ Name="Mno"},
            };
            // ViewBag.result = test;

            //   ViewData["results"] = test;

            TempData["res"] = test;
            return View();
        }

        public IActionResult Testing()
        {

            string str = TempData["td"].ToString();
            return View();
        }

        public IActionResult StoreCookieData()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMonths(2);
            Response.Cookies.Append("CompanyName", "Accenture", cookieOptions);
            Response.Cookies.Append("Batch", "Dotnet", cookieOptions);
            return RedirectToAction("RetriveCookieData");
        }

        public IActionResult RetriveCookieData()
        {
            TempData["nme"] = Request.Cookies["CompanyName"];
            TempData["batch"] = Request.Cookies["Batch"];
            return View();
        }
    }
}
