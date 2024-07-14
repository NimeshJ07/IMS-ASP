using IMSAppliaction.Model;
using IMSApplication.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersServices _ordersServices;

        public OrdersController(IOrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IEnumerable<Orders>> Get()
        {
            return await _ordersServices.GetOrdersAsync();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<Orders> Get(int id) { 
            return await _ordersServices.GetByIdAsync(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<Orders> Post([FromBody] Orders orders)
        {
            return await _ordersServices.CreateOrdersAsync(orders);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<Orders> Put(int id, [FromBody] Orders orders)
        {
            return await _ordersServices.UpdateOrdersAsync(id, orders);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _ordersServices.DeleteOrdersAsync(id);
        }
    }
    
}
