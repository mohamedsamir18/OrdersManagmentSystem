using Orders_Managment_System.Dtos;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IDeliveryService
    {
        Task<DeliveryDto> GetDeliveryByOrderIdAsync(int id);
        Task<DeliveryDto> CreateDeliveryAsync(int orderid);
        Task UpdateDeliveryStatusAsync(int deliveryid, string status);
    }
}
