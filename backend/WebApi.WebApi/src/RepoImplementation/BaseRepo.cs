using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Shared;

namespace WebApi.WebApi.src.RepoImplementation
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        
        public Task<T> CreateOne(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> UpdateOneById(T updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}