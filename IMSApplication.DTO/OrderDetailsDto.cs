using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.DTO
{
    public class OrderDetailsDto
    {
        public record CreateOrderDetailDto(
            int OrderId,
            int ProductId,
            int ProductTotal,
            int ProductQty,
            DateTime CreatedAt,
            DateTime UpdatedAt
        );

        public record GetOrderDetailDto(
            int Id,
            string OrderNumber,
            string Product_Name,
            int Product_Total,
            int OrderTotal,
            int ProductQty
        );

        public record UpdateOrderDetailDto(
            int Id,
            int OrderId,
            int ProductId,
            int ProductTotal,
            int ProductQty,
            DateTime UpdatedAt
        );
    }
}
