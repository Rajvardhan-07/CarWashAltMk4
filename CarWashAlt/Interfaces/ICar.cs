using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface ICar
    {
        Task<List<Car>> GetAllCar();
        Task<Car> GetCar(int id);
        Task<int> AddCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(int id);
    }
}
