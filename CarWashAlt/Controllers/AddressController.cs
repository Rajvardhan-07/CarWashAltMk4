using CarWashAlt.Models;
using CarWashAlt.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService addressService;
        public AddressController(AddressService _addressService)
        {
            addressService = _addressService;
        }
        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            var temp = await addressService.GetAllAddress();
            return Ok(temp);
        }
        [HttpGet("GetAddress/{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            return Ok(await addressService.GetAddress(id));
        }
        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress(Address address)
        {
            return Ok(await addressService.AddAddress(address));
        }
        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(Address address)
        {
            return Ok(await addressService.UpdateAddress(address));
        }
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            return Ok(await addressService.DeleteAddress(id));
        }
    }
}
