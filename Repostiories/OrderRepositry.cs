using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Repostiories
{
    public class OrderRepositry : IOrderRepositry
    {
        private readonly ApplicationDbContext _context;

        public OrderRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrderAsync(Order order)
        {
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            if(order != null)
            {
                _context.orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
          return await _context.orders.FindAsync(id);
           
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var result = await _context.orders.ToListAsync();
            return result;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var orderfound = await GetOrderByIdAsync(order.ID);
            if( orderfound != null )
            {
                orderfound.CustomerName = order.CustomerName;
                orderfound.Total_Amount = order.Total_Amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
