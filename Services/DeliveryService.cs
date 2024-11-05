using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDerliveryRepo _derlivery;
        private readonly IOrderRepositry _order;

        public DeliveryService(IDerliveryRepo derlivery , IOrderRepositry order)
        {
            _derlivery = derlivery;
           _order = order;
        }
        public async Task<Delivery> CreateDeliveryAsync(int orderid)
        {
            var order = await _order.GetOrderByIdAsync(orderid);
            if (order == null)
                throw new Exception("order not found");
            if (order.delivery != null)
            {
                throw new Exception("delivry was assigned to this order");
            }
            else
            {
                var delivery = new Delivery
                {
                    OrderId = orderid,
                    shipingdate = DateTime.UtcNow,
                    status = "shipped"
                };

                await _derlivery.CreateDeliveryAsync(delivery);

                order.Status = "shipped";
                order.delivery = delivery;
                await _order.UpdateOrderAsync(order);
               
                return delivery;
            }
        }

        public async Task<Delivery> GetDeliveryByOrderIdAsync(int id)
        {
            var result = await _derlivery.GetDeliveryByorderIdAsync(id);
            return result;

        }

        public async Task UpdateDeliveryStatusAsync(int deliveryid, string status)
        {
            if(status != "pending" || status != "shipped" || status != "deliverd")
            {
                throw new Exception("invalid delivery status");
            }

            await _derlivery.UpdateDeliveryStatusAsync(deliveryid, status);
        }
    }
}
