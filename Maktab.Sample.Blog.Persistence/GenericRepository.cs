using System.Linq.Expressions;
using System.Text.Json;
using Maktab.Sample.Blog.Abstraction;
using Maktab.Sample.Blog.Abstraction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly BlogDbContext _dbContext;
    private readonly ILogger<GenericRepository<T>> _logger;

    public GenericRepository(BlogDbContext dbContext, ILogger<GenericRepository<T>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Guid id, bool AsNoTracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool AsNoTracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    { 
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            entity.SoftDeleteEntity();
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task HardDeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}