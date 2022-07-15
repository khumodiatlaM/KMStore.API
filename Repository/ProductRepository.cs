using KMStore.API.Data;
using KMStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMStore.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly KMStoreContext _context;

        public ProductRepository(KMStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
