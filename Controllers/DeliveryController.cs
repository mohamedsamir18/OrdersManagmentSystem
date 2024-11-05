using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpPost]
        [Route("{orderid}")]
        public async Task<ActionResult> CreateDelivery(int orderid)
        {
            var result = await _deliveryService.CreateDeliveryAsync(orderid);
            
            return Ok(result);

        }

        [HttpGet]
        [Route("{orderid}")]
        public async Task<ActionResult<Delivery>> GetDeliverybyidAsync(int orderid) 
        {
            var result = await _deliveryService.GetDeliveryByOrderIdAsync(orderid);
            if(result == null)
            {
                throw new Exception("delivery not found");
            }
            return Ok(result);
        }

        [HttpPatch]
        [Route("{deliveryid}/status")]
        public async Task<ActionResult> UpdateDeliveryStatus(int deliveryid, [FromQuery] string status)
        {
            await _deliveryService.UpdateDeliveryStatusAsync(deliveryid, status);
            return NoContent();
        }
    }
}
