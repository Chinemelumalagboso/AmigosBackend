using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Model
{
    public class ProductContext :DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {

    }

public DbSet<Product> AmcProducts { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
    
}