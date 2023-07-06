using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Repositories
{
    public class PaymentRepository : IPayment
    {
        private CarWashAltDbContext _paymentDb;
        public PaymentRepository(CarWashAltDbContext carDbContext)
        {
            _paymentDb = carDbContext;
        }

        #region Adding Payment  
        public async Task<int> AddPayment(Payment payment)
        {
            try
            {
                int id = 0;
                if (payment == null)
                {
                    return id;
                }
                await _paymentDb.Payments.AddAsync(payment);
                await _paymentDb.SaveChangesAsync();
                id = payment.Id;
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Payment

        #region Delete Payment
        public async Task<bool> DeletePayment(int id)
        {
            try
            {
                var car = await _paymentDb.Payments.FindAsync(id);
                if (car == null)
                    return false;
                _paymentDb.Payments.Remove(car);
                await _paymentDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Payment

        #region GetAll Payment
        public async Task<List<Payment>> GetAllPayment()
        {
            try
            {
                var payment = await _paymentDb.Payments.ToListAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Payment

        #region Get Payment
        public async Task<Payment> GetPayment(int id)
        {
            Payment payment;
            try
            {
                payment = await _paymentDb.Payments.FindAsync(id);
                if (payment != null)
                {
                    return payment;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return payment;
        }
        #endregion Get Payment

        #region Update Payment
        public async Task<bool> UpdatePayment(Payment payment)
        {
            try
            {
                var car = await _paymentDb.Payments.AsNoTracking().FirstOrDefaultAsync(u => u.Id == payment.Id);
                if (car == null)
                    return false;
                _paymentDb.Payments.Update(payment);
                await _paymentDb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Payment
    }
}
