using Orders_Managment_System.Dtos;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(OrderDto order);
        Task UpdateOrderAsync(OrderDto order,int id);
        Task DeleteOrderAsync(int id);


    }
}
