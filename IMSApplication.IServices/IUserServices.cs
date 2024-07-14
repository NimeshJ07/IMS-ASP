using IMSAppliaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.IServices
{
    public interface IUserServices
    {
        public Task<IEnumerable<Users>> GetUsersAsync();
        public Task<Users> GetUserById(int id);
        public Task<Users> CreateUserAsync(Users user);
        public Task<Users> UpdateUserAsync(int id, Users users);
        public Task<bool> DeleteUserAsync(int id);
    }
}
