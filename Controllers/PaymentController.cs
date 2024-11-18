using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders_Managment_System.Interfaces;

namespace Orders_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _payment;

        public PaymentController(IPaymentService payment)
        {
            _payment = payment;
        }
        [HttpPost]
        [Route("{orderid}/pay")]
        [Authorize(Roles ="enduser")]
        public async Task<IActionResult> ProcessPayment(int orderid, [FromBody] decimal amount)
        {
           await _payment.ProcessPaymentAsync(orderid, amount);
            return Ok("payment processed succesfully");
        }
    }
}
