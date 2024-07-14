using IMSAppliaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApplication.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetByIdAsync(int id);
        Task<Products> CreateProductsAsync(Products products);
        Task<Products> UpdateProductsAsync(int id, Products products);
        Task<bool> DeleteProductsAsync(int id);
    }
}
