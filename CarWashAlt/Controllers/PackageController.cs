using CarWashAlt.Models;
using CarWashAlt.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private PackageService packageService;
        public PackageController(PackageService _packageService)
        {
            packageService = _packageService;
        }
        // [Authorize(Roles = "Admin")]
        [HttpGet("GetAllPackage")]
        public async Task<IActionResult> GetAllPackage()
        {
            var temp = await packageService.GetAllPackage();
            return Ok(temp);
        }
        [HttpGet("GetPackage/{id}")]
        public async Task<IActionResult> GetPackage(int id)
        {
            return Ok(await packageService.GetPackage(id));
        }
        // [Authorize(Roles = "Admin")]
        [HttpPost("AddPackage")]
        public async Task<IActionResult> AddPackage(Package package)
        {
            return Ok(await packageService.AddPackage(package));
        }
        // [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePackage")]
        public async Task<IActionResult> UpdatePackage(Package package)
        {
            return Ok(await packageService.UpdatePackage(package));
        }
        // [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePackage/{id}")]
        public async Task<IActionResult> DeletePackage([FromRoute] int id)
        {
            return Ok(await packageService.DeletePackage(id));
        }
    }
}
