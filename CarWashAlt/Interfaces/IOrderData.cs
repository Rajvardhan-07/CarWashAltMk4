using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IOrderData
    {
        Task<List<OrderData>> GetAllDetails();
    }
}
