using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Service
{
    public class IOrderClass : IOrdersInterface //Service
    {

        public readonly Databasecontext _context;
        public IOrderClass(Databasecontext context)
        {
            _context = context;
        }
        public async Task CreateOrder(OrdersModel obj)
        {
            // insert logic
            _context.ordersModels.Add(obj);
            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<OrdersModel>> GetAllOrders()
        {
            // return await _context.ordersModels.ToListAsync();

            var res = await (from s in _context.ordersModels select s).ToListAsync();
            return res;
        }

        public async Task<OrdersModel> getDatabyID(int OrderID)
        {
            return await _context.ordersModels.FindAsync(OrderID);
        }

        public async Task UpdateOrder(OrdersModel obj)
        {
            _context.ordersModels.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int OrderID)
        {

            var res = await _context.ordersModels.FindAsync(OrderID);
            if (res != null)
            {
                _context.ordersModels.Remove(res);
                await _context.SaveChangesAsync();

            }

        }
    }
}
