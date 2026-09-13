using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models
{
    public class ProductRepository : IStoreRepository<Product>
    {
        private readonly H60AssignmentDbSmContext _context;

        public ProductRepository(H60AssignmentDbSmContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetList()
        {
            return await _context.Products.ToListAsync();
        }

        public async void Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async void Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async void Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
