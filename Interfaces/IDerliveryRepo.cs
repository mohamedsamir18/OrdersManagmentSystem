using Orders_Managment_System.Dtos;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IDerliveryRepo
    {
        Task<Delivery> GetDeliveryByorderIdAsync(int orderId);
        Task CreateDeliveryAsync(DeliveryDto deliverydto);
        Task UpdateDeliveryStatusAsync(int deliveryId , string status);
    }
}
