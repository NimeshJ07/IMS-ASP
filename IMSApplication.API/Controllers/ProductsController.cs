using IMSAppliaction.Model;
using IMSApplication.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            return await _services.GetProductsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Products> Get(int id)
        {
            return await _services.GetByIdAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<Products> Post([FromBody] Products products)
        {
            return await _services.CreateProductsAsync(products);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<Products> Put(int id, [FromBody] Products products)
        {
            return await _services.UpdateProductsAsync(id, products);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _services.DeleteProductsAsync(id);
        }
    }
}
