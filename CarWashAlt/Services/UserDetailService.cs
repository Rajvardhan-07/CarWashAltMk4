using CarWashAlt.Interfaces;
using CarWashAlt.Models;

namespace CarWashAlt.Services
{
    public class UserDetailService
    {
        public readonly IUserData inter;
        public UserDetailService(IUserData repository)
        {
            inter = repository;
        }

        public async Task<CustomReturns> Login(UserDetails user)
        {
            return await inter.Login(user);
        }

        public async Task<CustomReturns> Register(UserDetails user)
        {
            return await inter.Register(user);
        }

        public async Task<List<UserDetails>> GetUserDetails()
        {
            return await inter.GetUserDetails();
        }



        public async Task<List<UserDetails>> GetWasherDetails()
        {
            return await inter.GetWasherDetails();
        }

        public async Task<bool> DeleteUserDetails(int id)
        {
            return await inter.DeleteUserDetails(id);
        }

        public async Task<UserDetails> GetUserById(int id)
        {
            return await inter.GetUserById(id);
        }

    }
}
