using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Repositories
{
    public class OrderDataRepository : IOrderData
    {
        private readonly CarWashAltDbContext _dbContext;

        public OrderDataRepository(CarWashAltDbContext carDbContext)
        {
            _dbContext = carDbContext;
        }


        public async Task<List<OrderData>> GetAllDetails()
        {
            var query = (from a in _dbContext.Orders
                         join b in _dbContext.UserDetails
                             on a.CustId equals b.UserId
                         join d in _dbContext.Cars
                            on a.CarId equals d.Id
                         join e in _dbContext.Packages
                            on a.PackageId equals e.Id
                         join f in _dbContext.Addresses
                         on a.AddressId equals f.Id

                         select new OrderData()
                         {
                             Id = a.Id,
                             CustomerName = b.FirstName + b.LastName,
                             CarName = d.Name,
                             CarModel = d.Model,
                             Adress = f.CustAddress,
                             PackageName = e.Name,
                             DeliveryStatus = a.Status,
                             PaymentStatus = a.PaymentStatus,
                             TotalCost = a.TotalCost,
                             Date_Time = a.Date_Time,
                             WasherName = (b.FirstName + b.LastName)
                         });
            List<OrderData> list1 = await query.ToListAsync();
            return list1;

        }
    }
}
