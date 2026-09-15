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
            return await _context.Products.OrderBy(p => p.Description).ToListAsync();
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetById(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
}
