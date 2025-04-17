using System.Linq.Expressions;
using Bookstore.Infrastructure;
using BookStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{    

    private readonly BookStoreDbContext _context;
    private readonly DbSet<T> _dbSet; //reference to appropriate dbSet
    public GenericRepository(BookStoreDbContext context)
    {
        _context=context;
        _dbSet=_context.Set<T>(); 
        
    }
    public async  Task<T> AddAsync(T entity)
    {
       await _dbSet.AddAsync(entity);
       await _context.SaveChangesAsync();
       return entity;
    }

    /// <summary>
    /// Function for deleting entity in DB
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns bool value</returns>
    public async Task<int> DeleteAsync(T entity, bool hardDelete)
    {
        if (hardDelete)
        {
            _dbSet.Remove(entity);
        }
        else
        {
            _dbSet.Update(entity);
        }

        var entriesAffected= await _context.SaveChangesAsync();
        if ( entriesAffected is 0)
            return 0; 
        return entriesAffected;
    }
       

        
    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return await  _dbSet.ToListAsync();
    }
    //TODO , change it to be generic with expression
    public async Task<List<Book>> GetAllBooksForAuthor(int authorId)
    {
        return await _context.Books.Where( book=> book.Author.Id==authorId && book.Author.IsDeleted==false).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetByIdWithIncludesAsync<To>(int id, Expression<Func<T, To>> includeExpression)
    {
        return await _dbSet
            .Include(includeExpression)
            .FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id") == id);
    }
   public async  Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    

  
}

