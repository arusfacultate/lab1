using Microsoft.EntityFrameworkCore;
using System;

namespace lab1_web_api.Models
{
        public class ProductsDbContext : DbContext
        {
            public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }
        }
    }
