using IMSAppliaction.Model;
using IMSApplication.IServices;
using Microsoft.AspNetCore.Mvc;
using static IMSApplication.DTO.OrderDetailsDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsServices _services;

        public OrderDetailsController(IOrderDetailsServices services)
        {
            _services = services;
        }

        // GET: api/<OrderDetailsController>
        [HttpGet]
        public async Task<IEnumerable<GetOrderDetailDto>> Get()
        {
            return await _services.GetOrderDetailAsync();
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public async Task<GetOrderDetailDto> Get(int id)
        {
            return await _services.GetOrderDetailById(id);
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public async Task<GetOrderDetailDto> Post([FromBody] CreateOrderDetailDto orderDetailDto)
        {
            return await _services.CreateOrderDetailAsync(orderDetailDto);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        public async Task<GetOrderDetailDto> Put(int id, [FromBody] UpdateOrderDetailDto orderDetail)
        {
            return await _services.UpdateOrderDetailAsync(id, orderDetail);
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _services.DeleteOrderDetailAsync(id);
        }
    }
}
