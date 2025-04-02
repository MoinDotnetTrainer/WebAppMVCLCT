using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Service
{
    public interface IOrdersInterface
    {
        Task CreateOrder(OrdersModel obj);
        Task<IEnumerable<OrdersModel>> GetAllOrders();
        Task<OrdersModel> getDatabyID(int OrderID);
        Task UpdateOrder(OrdersModel obj);
        Task DeleteOrder(int OrderID);

    }
}
