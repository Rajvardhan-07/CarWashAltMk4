using CarWashAlt.Interfaces;
using CarWashAlt.Models;

namespace CarWashAlt.Services
{
    public class AddressService
    {
        private IAddress _IAddress;
        public AddressService(IAddress Iaddress)
        {
            _IAddress = Iaddress;
        }
        public async Task<List<Address>> GetAllAddress()
        {
            return await _IAddress.GetAllAddress();
        }
        public async Task<Address> GetAddress(int id)
        {
            return await _IAddress.GetAddress(id);
        }
        public async Task<int> AddAddress(Address address)
        {
            return await _IAddress.AddAddress(address);
        }
        public async Task<bool> UpdateAddress(Address address)
        {
            return await _IAddress.UpdateAddress(address);
        }
        public async Task<bool> DeleteAddress(int id)
        {
            return await _IAddress.DeleteAddress(id);
        }
    }
}
