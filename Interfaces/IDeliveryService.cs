using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IDeliveryService
    {
        Task<Delivery> GetDeliveryByOrderIdAsync(int id);
        Task<Delivery> CreateDeliveryAsync(int orderid);
        Task UpdateDeliveryStatusAsync(int deliveryid, string status);
    }
}
