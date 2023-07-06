using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IAddress
    {
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddress(int id);
        Task<int> AddAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddress(int id);
    }
}
