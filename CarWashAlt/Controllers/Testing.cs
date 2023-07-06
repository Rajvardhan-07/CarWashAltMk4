using CarWashAlt.Context;
using CarWashAlt.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAlt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testing : Controller
    {
        private readonly CarWashAltDbContext _context;
        public Testing(CarWashAltDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Postdata")]
        public ActionResult<int> Postdata(Car obj)
        {
            int id = 0;
            if (obj == null)
            {
                return id;
            }
            _context.Cars.Add(obj);
            _context.SaveChanges();
            id = obj.Id;
            return id;
        }
    }
}
