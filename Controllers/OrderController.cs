using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Orders_Managment_System.Dtos;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> GetOrderByID(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles ="enduser")]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            await _orderService.CreateOrderAsync(orderDto);
            return Ok();
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "enduser")]
        public async Task<IActionResult> UpdateOrder(int id , OrderDto orderDto)
        {

            await _orderService.UpdateOrderAsync(orderDto, id);
            return Ok();

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "enduser")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();

        }

    }
}
