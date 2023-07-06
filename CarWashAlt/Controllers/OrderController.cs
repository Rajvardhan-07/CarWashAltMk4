using CarWashAlt.Models;
using CarWashAlt.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController(OrderService _orderService)
        {
            orderService = _orderService;
        }
        // [Authorize(Roles = "Washer")]
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var temp = await orderService.GetAllOrder();
            return Ok(temp);
        }
        [HttpGet("AllPreviousOrder/{id}")]
        public async Task<IActionResult> AllPreviousOrder(int id)
        {
            var temp = await orderService.AllPreviousOrder(id);
            return Ok(temp);
        }


        [HttpGet("AllDeliveredOrderForAdmin")]
        public async Task<IActionResult> AllDeliveredOrderForAdmin()
        {
            var temp = await orderService.AllDeliveredOrderForAdmin();
            return Ok(temp);
        }


        [HttpGet("AllPreviousOrderForCustomer/{id}")]
        public async Task<IActionResult> AllPreviousOrderForCustomer(int id)
        {
            var temp = await orderService.AllPreviousOrderForCustomer(id);
            return Ok(temp);
        }

        [HttpGet("ScheduledWash/{id}")]
        public async Task<IActionResult> ScheduledWash(int id)
        {
            var temp = await orderService.ScheduledWash(id);
            return Ok(temp);
        }

        [HttpGet("ScheduledWashForCustomer/{id}")]
        public async Task<IActionResult> ScheduledWashForCustomer(int id)
        {
            var temp = await orderService.ScheduledWashForCustomer(id);
            return Ok(temp);
        }

        [HttpGet("GetAllRequest")]
        public async Task<IActionResult> GetAllRequest()
        {
            var temp = await orderService.GetAllRequest();
            return Ok(temp);
        }



        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            return Ok(await orderService.GetOrder(id));
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            return Ok(await orderService.AddOrder(order));
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Order admin)
        {
            return Ok(await orderService.UpdateOrder(admin));
        }
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok(await orderService.DeleteOrder(id));
        }
    }
}
