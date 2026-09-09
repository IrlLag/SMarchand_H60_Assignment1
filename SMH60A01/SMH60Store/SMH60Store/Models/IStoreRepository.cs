using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models
{
    public interface IStoreRepository
    {
        public Task<List<Product>> GetProducts(H60AssignmentDbSmContext context);

        public void AddProduct(H60AssignmentDbSmContext context, Product product);

        public void UpdateProduct(H60AssignmentDbSmContext context, Product product);


        public void DeleteProduct(H60AssignmentDbSmContext context, Product product);

        public Task<Product?> GetProductById(H60AssignmentDbSmContext context, int? id);

    }
}
