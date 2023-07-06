using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IPayment
    {
        Task<List<Payment>> GetAllPayment();
        Task<Payment> GetPayment(int id);
        Task<int> AddPayment(Payment car);
        Task<bool> UpdatePayment(Payment car);
        Task<bool> DeletePayment(int id);
    }
}
