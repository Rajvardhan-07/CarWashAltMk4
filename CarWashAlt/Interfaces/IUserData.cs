using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IUserData
    {
        Task<CustomReturns> Login(UserDetails user);
        Task<CustomReturns> Register(UserDetails user);
        Task<List<UserDetails>> GetUserDetails();
        Task<List<UserDetails>> GetWasherDetails();

        Task<bool> DeleteUserDetails(int id);

        Task<UserDetails> GetUserById(int id);
    }
}
