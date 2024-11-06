namespace Orders_Managment_System.Interfaces
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(int orderId, decimal amount);
        Task UpdatePaymentStatusAsync(int paymentId, string status);
    }
}
