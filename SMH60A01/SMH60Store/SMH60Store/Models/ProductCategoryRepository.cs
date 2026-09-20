using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models
{
    public class ProductCategoryRepository : IStoreRepository<ProductCategory>
    {
        private readonly H60AssignmentDbSmContext _context;

        public ProductCategoryRepository(H60AssignmentDbSmContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCategory>> GetList(string? search)
        {
            return await _context.ProductCategories.OrderBy(pc => pc.ProdCat).ToListAsync();
        }

        public async Task Add(ProductCategory item)
        {
            _context.ProductCategories.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductCategory item)
        {
            _context.ProductCategories.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductCategory item)
        {
            _context.ProductCategories.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductCategory?> GetById(int? id)
        {
            return await _context.ProductCategories.Include(pc => pc.Products).FirstOrDefaultAsync(pc => pc.ProdCatId == id);
        }

    }
}
