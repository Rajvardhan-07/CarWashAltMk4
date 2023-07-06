using CarWashAlt.Models;

namespace CarWashAlt.Interfaces
{
    public interface IPackage
    {
        Task<List<Package>> GetAllPackage();
        Task<Package> GetPackage(int id);
        Task<int> AddPackage(Package package);
        Task<bool> UpdatePackage(Package package);
        Task<bool> DeletePackage(int id);
    }
}
