using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSApplication.IRespository;
using IMSApllication.Data;
using Microsoft.EntityFrameworkCore;
using IMSAppliaction.Model;

namespace IMSApllication.Respository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMSDbContext _dbcontext;

        public Repository(IMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();

            // Ensure you're dealing with OrderDetail specifically for Includes
            if (entity is OrderDetail orderDetail)
            {
                return await _dbcontext.Set<OrderDetail>()
                    .Include(od => od.Orders)
                    .Include(od => od.Products)
                    .FirstOrDefaultAsync(od => od.Id == orderDetail.Id) as T;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbcontext.Remove(entity);
            var row = await _dbcontext.SaveChangesAsync();
            return row > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(OrderDetail))
            {
                return await _dbcontext.Set<OrderDetail>()
                    .Include(od => od.Orders)
                    .Include(od => od.Products)
                    .Cast<T>()
                    .ToListAsync();
            }
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity is OrderDetail orderDetail)
            {
                await _dbcontext.Entry(orderDetail).Reference(od => od.Orders).LoadAsync();
                await _dbcontext.Entry(orderDetail).Reference(od => od.Products).LoadAsync();
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
