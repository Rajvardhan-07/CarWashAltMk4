using CarWashAlt.Interfaces;
using CarWashAlt.Models;

namespace CarWashAlt.Services
{
    public class OrderService
    {
        private IOrder _IOrder;
        public OrderService(IOrder Iorder)
        {
            _IOrder = Iorder;
        }
        public async Task<List<Order>> GetAllOrder()
        {
            return await _IOrder.GetAllOrder();
        }

        public async Task<List<Order>> AllPreviousOrder(int id)
        {
            return await _IOrder.AllPreviousOrder(id);
        }

        public async Task<List<Order>> AllDeliveredOrderForAdmin()
        {
            return await _IOrder.AllDeliveredOrderForAdmin();
        }

        public async Task<List<Order>> AllPreviousOrderForCustomer(int id)
        {
            return await _IOrder.AllPreviousOrderForCustomer(id);
        }
        public async Task<List<Order>> ScheduledWash(int id)
        {
            return await _IOrder.ScheduledWash(id);
        }

        public async Task<List<Order>> ScheduledWashForCustomer(int id)
        {
            return await _IOrder.ScheduledWashForCustomer(id);
        }


        public async Task<List<Order>> GetAllRequest()
        {
            return await _IOrder.GetAllRequest();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _IOrder.GetOrder(id);
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _IOrder.AddOrder(order);
        }
        public async Task<bool> UpdateOrder(Order order)
        {
            return await _IOrder.UpdateOrder(order);
        }
        public async Task<bool> DeleteOrder(int id)
        {
            return await _IOrder.DeleteOrder(id);
        }
    }
}
