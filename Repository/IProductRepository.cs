using KMStore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMStore.API.Repository
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task AddProduct(Product product);

        Task UpdateProduct(int id, Product product);

        Task DeleteProduct(int id);
    }
}
