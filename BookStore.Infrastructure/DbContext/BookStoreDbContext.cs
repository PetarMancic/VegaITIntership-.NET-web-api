
using System.Reflection;
using Bookstore.Domain.Entities;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure;
public class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<PurchaseItem> PurchaseItem { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
   // public DbSet<User> User { get; set; }

    //public BookStoreDbContext(){}
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(BookStoreDbContext)
                        .GetMethod(nameof(ApplySoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, [modelBuilder]);
                }
            }
           // Purchases.Include(p=> p.Items); 

    }

    private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseEntity
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        foreach ( var entry in ChangeTracker.Entries())
        {
            if( entry.Entity is BaseEntity baseEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        baseEntity.CreatedAt= DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        if(!baseEntity.IsDeleted)
                        {
                            baseEntity.UpdatedAt=DateTime.UtcNow;
                        }
                        else
                        {
                            baseEntity.DeletedAt= DateTime.UtcNow;
                        }
                        break;
                   case EntityState.Deleted:
                        baseEntity.DeletedAt= DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
