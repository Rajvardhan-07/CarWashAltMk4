using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Repositories
{
    public class OrderRepository : IOrder
    {
        private CarWashAltDbContext _orderDb;
        public OrderRepository(CarWashAltDbContext orderDbContext)
        {
            _orderDb = orderDbContext;
        }



        #region  Adding Order
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                Order id = null;
                if (order == null)
                {
                    return id;
                }
                await _orderDb.Orders.AddAsync(order);
                await _orderDb.SaveChangesAsync();
                // id=order.Id;
                return order;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Order

        #region Delete Order
        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderDb.Orders.FindAsync(id);
                if (order == null)
                    return false;
                _orderDb.Orders.Remove(order);
                await _orderDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Order

        #region GetAll Order
        public async Task<List<Order>> GetAllOrder()
        {
            try
            {


                var temp = await _orderDb.Orders.ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Order


        #region GetAll AllPreviousOrder
        public async Task<List<Order>> AllPreviousOrder(int id)
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.WasherId == id && x.Status == "Delivered").ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll AllPreviousOrder


        #region GetAll AllDeliveredOrderForAdmin
        public async Task<List<Order>> AllDeliveredOrderForAdmin()
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.PaymentStatus == "Paid" && x.Status == "Delivered").ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll AllDeliveredOrderForAdmin

        #region GetAll AllPreviousOrderForCustomer
        public async Task<List<Order>> AllPreviousOrderForCustomer(int id)
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.CustId == id && x.Status == "Delivered").ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll AllPreviousOrderForCustomer

        #region GetAll ScheduledWash
        public async Task<List<Order>> ScheduledWash(int id)
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.WasherId == id && x.Status == "Not Delievered").ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll ScheduledWash



        #region GetAll ScheduledWashForCustomer
        public async Task<List<Order>> ScheduledWashForCustomer(int id)
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.CustId == id && x.Status == "Not Delievered").ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll ScheduledWashForCustomer


        #region GetAll Request
        public async Task<List<Order>> GetAllRequest()
        {
            try
            {


                var temp = await _orderDb.Orders.Where(x => x.WasherId == 0).ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Request



        #region Get Order
        public async Task<Order> GetOrder(int id)
        {
            Order order;
            try
            {
                order = await _orderDb.Orders.FindAsync(id);
                if (order != null)
                {
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return order;
        }
        #endregion Get Order

        #region Update Order
        public async Task<bool> UpdateOrder(Order order)
        {
            try
            {
                var order1 = await _orderDb.Orders.AsNoTracking().FirstOrDefaultAsync(u => u.Id == order.Id);
                if (order1 == null)
                    return false;
                _orderDb.Orders.Update(order);
                await _orderDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Order



    }
}
