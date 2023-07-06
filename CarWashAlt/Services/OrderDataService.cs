using CarWashAlt.Interfaces;
using CarWashAlt.Models;

namespace CarWashAlt.Services
{
    public class OrderDataService
    {
        private readonly IOrderData repo;

        public OrderDataService(IOrderData _repo)
        {
            repo = _repo;
        }
        public async Task<List<OrderData>> GetAllDetails()
        {
            return await repo.GetAllDetails();

        }
    }
}
