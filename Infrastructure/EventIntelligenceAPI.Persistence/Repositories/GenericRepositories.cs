using System.Linq.Expressions;
using EventIntelligenceAPI.Application.Extensions;
using EventIntelligenceAPI.Application.Interfaces;
using EventIntelligenceAPI.Application.Interfaces.Repositories;
using EventIntelligenceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EventIntelligenceAPI.Persistence.Repositories;


public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
{
    private readonly TContext _context;

    public GenericRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
                                                            object>> include = null,
                                                        int index = 0, int size = 10)
    {
        IQueryable<TEntity> queryable = Query().AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0);

        return await queryable.ToPaginateAsync(index, size, 0);
    }

    public IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}