using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IDerliveryRepo
    {
        Task<Delivery> GetDeliveryByorderIdAsync(int orderId);
        Task CreateDeliveryAsync(Delivery delivery);
        Task UpdateDeliveryStatusAsync(int deliveryId , string status);
    }
}
