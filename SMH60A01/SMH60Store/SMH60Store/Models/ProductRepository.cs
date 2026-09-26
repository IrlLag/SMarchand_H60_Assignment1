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
        public async Task<List<Product>> GetList(string? search)
        {
            if(search == "Category")
            {
                return await _context.Products.OrderBy(p => p.ProdCatId).ThenBy(p => p.Description).ToListAsync();
            }
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
            var orderitemList = await _context.OrderItems.Where(oi => oi.ProductId == product.ProductId).ToListAsync();
            _context.OrderItems.RemoveRange(orderitemList);
            var cartItemListView = await _context.CartItems.Where(oi => oi.ProductId == product.ProductId).ToListAsync();
            _context.CartItems.RemoveRange(cartItemListView);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetById(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product is not null)
            {
                product.ProdCat = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.ProdCatId == product.ProdCatId);
            }
            return product;
        }
    }
}
