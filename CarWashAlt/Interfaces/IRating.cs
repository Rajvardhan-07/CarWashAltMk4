using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IRating
    {
        Task<double> GetAverageRating(int id);
        Task<int> AddRating(Rating rate);
        Task<bool> UpdateRating(Rating rate);
        Task<bool> DeleteRating(int id);
    }
}
