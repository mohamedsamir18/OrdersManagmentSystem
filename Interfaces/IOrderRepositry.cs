using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IOrderRepositry
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
