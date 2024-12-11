using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Model
{
    public class FakeProductRepo : IProductRepo
    {
        private readonly List<Product> _products;

        public FakeProductRepo()
        {
            // Initialize with some fake data
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Biscuit", Price = 10.99m, description = "Green biscuit" },
                new Product { Id = 2, Name = " Phone", Price = 20.99m, description = "New iphone" },
                new Product { Id = 3, Name = "Samsung", Price = 30.99m, description = "Enjoy galaxy s3" }
            };
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(product);
        }
    }
}