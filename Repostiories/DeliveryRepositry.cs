using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Repostiories
{
    public class DeliveryRepositry : IDerliveryRepo
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateDeliveryAsync(Delivery delivery)
        {
            
                await _context.deliveries.AddAsync(delivery);
                await _context.SaveChangesAsync();
            

        }

        public async Task<Delivery> GetDeliveryByorderIdAsync(int orderId)
        {
           var result = await _context.deliveries.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (result == null)
                throw new Exception("delivery not found");
            return result;
        }

        public async Task UpdateDeliveryStatusAsync(int deliveryId, string status)
        {
            var deliv = await _context.deliveries.FindAsync(deliveryId);
            if(deliv == null)
            {
                throw new Exception("not found");
            }
            deliv.status = status;
            if(status == "delivered")
            {
                deliv.deliverydate = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }
    }
}
