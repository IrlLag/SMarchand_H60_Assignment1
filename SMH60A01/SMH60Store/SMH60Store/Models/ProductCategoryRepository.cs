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
        public async Task<List<ProductCategory>> GetList()
        {
            return await _context.ProductCategories.OrderBy(pc => pc.ProdCat).ToListAsync();
        }

        public void Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory?> GetById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
