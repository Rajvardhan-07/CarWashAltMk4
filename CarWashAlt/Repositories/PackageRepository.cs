using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Repositories
{
    public class PackageRepository : IPackage
    {
        private readonly CarWashAltDbContext _packageDb;

        public PackageRepository(CarWashAltDbContext context)
        {
            _packageDb = context;
        }
        #region Adding Package
        public async Task<int> AddPackage(Package package)
        {
            try
            {
                int id = 0;
                if (package == null)
                {
                    return id;
                }
                await _packageDb.Packages.AddAsync(package);
                await _packageDb.SaveChangesAsync();
                id = package.Id;
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Package

        #region Delete Package
        public async Task<bool> DeletePackage(int id)
        {
            try
            {
                var package = await _packageDb.Packages.FindAsync(id);
                if (package == null)
                    return false;
                _packageDb.Packages.Remove(package);
                await _packageDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Package

        #region GetAll Package
        public async Task<List<Package>> GetAllPackage()
        {
            try
            {
                var temp = await _packageDb.Packages.ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Package

        #region Get Package
        public async Task<Package> GetPackage(int id)
        {
            Package package;
            try
            {
                package = await _packageDb.Packages.FindAsync(id);
                if (package != null)
                {
                    return package;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return package;
        }
        #endregion Get Package

        #region Update Package
        public async Task<bool> UpdatePackage(Package package)
        {
            try
            {
                var package1 = await _packageDb.Packages.AsNoTracking().FirstOrDefaultAsync(u => u.Id == package.Id);
                if (package1 == null)
                    return false;
                _packageDb.Packages.Update(package);
                await _packageDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Package


    }
}
