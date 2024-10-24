using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Maktab.Sample.Blog.Abstraction.Domain;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);

    Task<T?> GetAsync(Guid id, bool AsNoTracking = true,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool AsNoTracking = true,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task UpdateAsync(T entity);
    Task SoftDeleteAsync(Guid id);
    Task HardDeleteAsync(Guid id);
}