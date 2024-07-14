using IMSAppliaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMSApplication.DTO.OrderDetailsDto;

namespace IMSApplication.IServices
{
    public interface IOrderDetailsServices
    {
        public Task<IEnumerable<GetOrderDetailDto>> GetOrderDetailAsync();
        public Task<GetOrderDetailDto> GetOrderDetailById(int id);
        public Task<GetOrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto);
        public Task<GetOrderDetailDto> UpdateOrderDetailAsync(int id, UpdateOrderDetailDto updateorderdetailDto);
        public Task<bool> DeleteOrderDetailAsync(int id);
    }
}
