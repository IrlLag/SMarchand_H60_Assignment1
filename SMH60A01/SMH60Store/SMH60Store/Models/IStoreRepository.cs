using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models
{
    public interface IStoreRepository<T>
    {
        public Task<List<T>> GetList();

        public void Add( T item);

        public void Update( T item);

        public void Delete( T item);

        public Task<T?> GetById( int? id);

    }
}
