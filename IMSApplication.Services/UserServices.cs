
using IMSAppliaction.Model;
using IMSApplication.IRespository;
using IMSApplication.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Users> CreateUserAsync(Users users)
        {
            return await _repository.CreateAsync(users);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var olduser = await _repository.GetAsync(id);
            if (olduser != null) { 
                return await _repository.DeleteAsync(olduser);
            }
            return false;
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Users> UpdateUserAsync(int id, Users user)
        {
            var olduser = await _repository.GetAsync(id);

            if (olduser != null) { 
                olduser.FullName = user.FullName;
                olduser.Email = user.Email;
                olduser.City = user.City;
                olduser.UpdatedAt = DateTime.Now;

                await _repository.UpdateAsync(olduser);
            }

            return olduser;
        }
    }


}
