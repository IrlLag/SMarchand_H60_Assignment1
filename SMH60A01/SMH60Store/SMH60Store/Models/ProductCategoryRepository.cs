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
            var productList = await _context.Products.Where(p => p.ProdCatId == item.ProdCatId).ToListAsync();
            for (int i = 0; i < productList.Count; i++)
            {
                Product product = productList[i];
                var orderitemList = await _context.OrderItems.Where(oi => oi.ProductId == product.ProductId).ToListAsync();
                _context.OrderItems.RemoveRange(orderitemList);
                var cartItemListView = await _context.CartItems.Where(oi => oi.ProductId == product.ProductId).ToListAsync();
                _context.CartItems.RemoveRange(cartItemListView);
                
                _context.Products.Remove(product);
            }
            _context.ProductCategories.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductCategory?> GetById(int? id)
        {
            return await _context.ProductCategories.Include(pc => pc.Products).FirstOrDefaultAsync(pc => pc.ProdCatId == id);
        }

    }
}
