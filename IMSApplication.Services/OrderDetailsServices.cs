using IMSAppliaction.Model;
using IMSApplication.IRespository;
using IMSApplication.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMSApplication.DTO.OrderDetailsDto;

namespace IMSApplication.Services
{
    public class OrderDetailsServices : IOrderDetailsServices
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsServices(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<GetOrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto)
        {
            var orders = await _orderDetailsRepository.CreateAsync(new OrderDetail()
            {
                OrderId = orderDetailDto.OrderId,
                ProductId = orderDetailDto.ProductId,
                ProductTotal = orderDetailDto.ProductTotal,
                ProductQty = orderDetailDto.ProductQty,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            return new GetOrderDetailDto( orders.Id,orders.Orders.OrderNumber, orders.Products.Product_Name, orders.ProductTotal, orders.Orders.OrderTotal, orders.ProductQty);
        }

        public async Task<bool> DeleteOrderDetailAsync(int id)
        {
            var oldod = await _orderDetailsRepository.GetAsync(id);
            if (oldod != null)
            {
                return await _orderDetailsRepository.DeleteAsync(oldod);
            }
            return false;
        }

        public async Task<IEnumerable<GetOrderDetailDto>> GetOrderDetailAsync()
        {
            var orders = await _orderDetailsRepository.GetAllAsync();
            var orderDto = orders.Select(order => new GetOrderDetailDto(order.Id, order.Orders.OrderNumber, order.Products.Product_Name, order.ProductTotal, order.Orders.OrderTotal, order.ProductQty));
            return orderDto;
        }

        public async Task<GetOrderDetailDto> GetOrderDetailById(int id)
        {
            var order = await _orderDetailsRepository.GetAsync(id);
            if (order == null)
            {
                return null; // Or handle the case where order is not found
            }

            return new GetOrderDetailDto(order.Id, order.Orders.OrderNumber, order.Products.Product_Name, order.ProductTotal, order.Orders.OrderTotal, order.ProductQty);
        }

        public async Task<GetOrderDetailDto> UpdateOrderDetailAsync(int id, UpdateOrderDetailDto updateorderdetailDto)
        {
            var oldod = await _orderDetailsRepository.GetAsync(id);
            if (oldod != null)
            {
                oldod.OrderId = updateorderdetailDto.OrderId;
                oldod.ProductId = updateorderdetailDto.ProductId;
                oldod.ProductQty = updateorderdetailDto.ProductQty;
                oldod.ProductTotal = updateorderdetailDto.ProductTotal;
                oldod.UpdatedAt = DateTime.Now;

                var updatedOrder = await _orderDetailsRepository.UpdateAsync(oldod);

                return new GetOrderDetailDto(updatedOrder.Id, updatedOrder.Orders.OrderNumber, updatedOrder.Products.Product_Name, updatedOrder.ProductTotal, updatedOrder.Orders.OrderTotal, updatedOrder.ProductQty);
            }
            return null; // Or handle the case where oldod is not found
        }
    }

}
