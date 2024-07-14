using IMSAppliaction.Model;
using IMSApplication.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userservices;

        public UsersController(IUserServices _userservices)
        {
            userservices = _userservices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            return await userservices.GetUsersAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<Users> Get(int id)
        {
            return await userservices.GetUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<Users> Post([FromBody] Users users)
        {
            return await userservices.CreateUserAsync(users);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<Users> Put(int id, [FromBody] Users users)
        {
            return await userservices.UpdateUserAsync(id, users);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return userservices.DeleteUserAsync(id);
        }
    }
}
