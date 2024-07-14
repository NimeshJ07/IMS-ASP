using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSApplication.IRespository;
using IMSApllication.Data;
using Microsoft.EntityFrameworkCore;

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
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(T entity)
        {
            return await _dbcontext.Set<T>().FindAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
