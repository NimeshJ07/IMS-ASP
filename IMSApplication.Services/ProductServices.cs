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
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Products> CreateProductsAsync(Products products)
        {
            return await _productRepository.CreateAsync(products);
        }

        public async Task<bool> DeleteProductsAsync(int id)
        {
            var oldproduct = await _productRepository.GetAsync(id);
            if (oldproduct != null) {
                return await _productRepository.DeleteAsync(oldproduct);
            }
            return false;
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Products> UpdateProductsAsync(int id, Products products)
        {
            var oldproduct = await _productRepository.GetAsync(id);
            if (oldproduct != null) {
                oldproduct.Product_Name = products.Product_Name;
                oldproduct.Product_Price = products.Product_Price;
                oldproduct.Product_Size = products.Product_Size;
                oldproduct.UpdatedAt = DateTime.Now;

                return await _productRepository.UpdateAsync(oldproduct);
            }
            return oldproduct;
        }
    }
}
