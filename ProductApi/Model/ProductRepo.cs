using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Model
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.AmcProducts.ToListAsync(); // Fetch all products from the database
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.AmcProducts.FirstOrDefaultAsync(p => p.Id == id); // Find product by Id
        }
    }
}