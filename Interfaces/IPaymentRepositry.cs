using Orders_Managment_System.Dtos;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IPaymentRepositry
    {
        Task CreatePaymentAsync(PaymentDto paymentdto);
        Task<Payment> GetPaymentByOrderIdAsync(int orderid);
        Task UpdatePaymentStatusAsync(int paymentid, string status);
    }
}
