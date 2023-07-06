using CarWashAlt.Models;
using CarWashAlt.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private PaymentService carService;
        public PaymentController(PaymentService _carService)
        {
            carService = _carService;
        }
        [HttpGet("GetAllPayment")]
        public async Task<IActionResult> GetAllPayment()
        {
            var cars = await carService.GetAllPayment();
            return Ok(cars);
        }
        [HttpGet("GetPayment/{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            return Ok(await carService.GetPayment(id));
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment(Payment car)
        {
            return Ok(await carService.AddPayment(car));
        }
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(Payment car)
        {
            return Ok(await carService.UpdatePayment(car));
        }
        [HttpDelete("DeletePayment/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            return Ok(await carService.DeletePayment(id));
        }
    }
}
