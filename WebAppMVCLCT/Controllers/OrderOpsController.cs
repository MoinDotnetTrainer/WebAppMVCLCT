using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebAppMVCLCT.Models;
using WebAppMVCLCT.Service;

namespace WebAppMVCLCT.Controllers
{
    public class OrderOpsController : Controller
    {

        public readonly IOrdersInterface _service;
        public OrderOpsController(IOrdersInterface service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult NewOrder()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewOrder(OrdersModel obj)
        {
            await _service.CreateOrder(obj);

            return RedirectToAction("GetAllOrders");
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var res = await _service.GetAllOrders();

            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> EditOrder(int OrderID)
        {
            var res = await _service.getDatabyID(OrderID);
            return View(res);
        }

        [HttpPost]
        public IActionResult EditOrder(OrdersModel obj)
        {
            _service.UpdateOrder(obj);
            return RedirectToAction("GetAllOrders");
           
        }
      
        public async Task<IActionResult> DeleteOrders(int OrderID)
        {
           await _service.DeleteOrder(OrderID);
            return RedirectToAction("GetallOrders");

          
        }

    }
}
