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

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.PictureUrl = product.PictureUrl;
                existingProduct.Type = product.Type;
                existingProduct.Brand = product.Brand;
                existingProduct.QuantityInStock = product.QuantityInStock;
            }

            _context.SaveChanges();
        }
    }
}
