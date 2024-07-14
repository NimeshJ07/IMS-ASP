using IMSAppliaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.IServices
{
    public interface IOrdersServices
    {
        Task<IEnumerable<Orders>> GetOrdersAsync();
        Task<Orders> GetByIdAsync(int id);
        Task<Orders> CreateOrdersAsync(Orders orders);
        Task<Orders> UpdateOrdersAsync(int id, Orders orders);
        Task<bool> DeleteOrdersAsync(int id);
    }
}
