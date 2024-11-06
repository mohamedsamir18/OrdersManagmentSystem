using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Repostiories
{
    public class PaymentRepositry : IPaymentRepositry
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreatePaymentAsync(Payment payment)
        {
            await _context.payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderid)
        {
            var result = await _context.orders.FirstOrDefaultAsync(p=>p.ID == orderid);
            if (result == null) {
                throw new Exception("order not found");
            }
            var payment = result.payment;
            return payment;

        }

        public async Task UpdatePaymentStatusAsync(int paymentid, string status)
        {
            var result = await _context.payments.FindAsync(paymentid);
            if (result == null) {
                throw new Exception("payment not found");
            }
            result.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
