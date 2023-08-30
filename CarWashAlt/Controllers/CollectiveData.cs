using CarWashAlt.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectiveData : ControllerBase
    {
        private readonly OrderDataService service;
        public CollectiveData(OrderDataService serv)
        {
            service = serv;

        }


        [HttpGet]
        [Route("AllData")]
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await service.GetAllDetails());
        }
    }
}
