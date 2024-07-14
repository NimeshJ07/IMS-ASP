using IMSAppliaction.Model;
using IMSApplication.IRespository;
using IMSApplication.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersServices(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<string> GenerateNumber()
        {
            IEnumerable<Orders> cnt = await _ordersRepository.GetAllAsync();
            int number = cnt.Count() + 1;
            string id = "OR" + DateTime.Now.Month.ToString("00") + DateTime.Now.ToString("yy") + number.ToString("0000");
            return id;
        }


        public async Task<Orders> CreateOrdersAsync(Orders orders)
        {
            orders.OrderNumber = await GenerateNumber();
            orders.CretedAt = DateTime.Now;
            orders.UpdatedAt = DateTime.Now;
            return await _ordersRepository.CreateAsync(orders);
        }

        public async Task<bool> DeleteOrdersAsync(int id)
        {
            var oldorder = await _ordersRepository.GetAsync(id);
            if (oldorder != null) {
                return await _ordersRepository.DeleteAsync(oldorder);
            }
            return false;
        }

        public async Task<Orders> GetByIdAsync(int id)
        {
            return await _ordersRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task<Orders> UpdateOrdersAsync(int id, Orders orders)
        {
            var oldorder = await _ordersRepository.GetAsync(id);
            if (oldorder != null) { 
                oldorder.OrderTotal = orders.OrderTotal;
                oldorder.UpdatedAt = DateTime.Now;

                return await _ordersRepository.UpdateAsync(oldorder);
            }
            return oldorder;
        }

    }
}
