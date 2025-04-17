using System.Linq.Expressions;

namespace BookStore.Domain.Interfaces;
public interface IGenericRepository<T> where T : class
{
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity,bool hardDelete);
        Task<T?> GetByIdWithIncludesAsync<To>(int id, Expression<Func<T, To>> includeExpression);
        Task<List<Book>> GetAllBooksForAuthor(int authorId);
}
