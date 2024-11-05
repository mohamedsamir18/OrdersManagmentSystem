using Microsoft.AspNetCore.Http.HttpResults;
using Orders_Managment_System.Dtos;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Services
{
    public class OrderService : IOrderService 
    {
        private readonly IOrderRepositry _repositry;

        public OrderService(IOrderRepositry repositry)
        {
            _repositry = repositry;
        }

        public async Task CreateOrderAsync(OrderDto order)
        {
            var ordercreated =  new Order
            {
                CustomerName = order.CustomerName,
                Total_Amount = order.Total_Amount
                
            };

            await _repositry.CreateOrderAsync(ordercreated);

        }

        public async Task DeleteOrderAsync(int id)
        {
            await _repositry.DeleteOrderAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
          return await _repositry.GetOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _repositry.GetOrderByIdAsync(id);
        }

        public async Task UpdateOrderAsync(OrderDto order, int id)
        {
            var orderfound = await _repositry.GetOrderByIdAsync(id);
            if(orderfound != null)
            {
                orderfound.CustomerName = order.CustomerName;
                orderfound.Total_Amount = order.Total_Amount;
                await _repositry.UpdateOrderAsync(orderfound);
            }
        }
    }
}
