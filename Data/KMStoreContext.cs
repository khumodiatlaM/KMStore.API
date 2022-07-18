using KMStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KMStore.API.Data
{
    public class KMStoreContext : DbContext
    {
        public KMStoreContext(DbContextOptions<KMStoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
