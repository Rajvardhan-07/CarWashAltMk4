using CarWashAlt.Interfaces;
using CarWashAlt.Models;

namespace CarWashAlt.Services
{
    public class CarService
    {
        private ICar _ICar;
        public CarService(ICar Icar)
        {
            _ICar = Icar;
        }
        public async Task<List<Car>> GetAllCar()
        {
            return await _ICar.GetAllCar();
        }
        public async Task<Car> GetCar(int id)
        {
            return await _ICar.GetCar(id);
        }
        public async Task<int> AddCar(Car car)
        {
            return await _ICar.AddCar(car);
        }
        public async Task<bool> UpdateCar(Car car)
        {
            return await _ICar.UpdateCar(car);
        }
        public async Task<bool> DeleteCar(int id)
        {
            return await _ICar.DeleteCar(id);
        }
    }
}
