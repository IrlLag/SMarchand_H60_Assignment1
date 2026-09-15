using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models
{
    public interface IStoreRepository<T>
    {
        public Task<List<T>> GetList();

        public Task Add( T item);

        public Task Update( T item);

        public Task Delete( T item);

        public Task<T?> GetById( int? id);

    }
}
