using System.Linq.Expressions;
using Application.Abstractions.Database;
using Application.Domains.Entities;
using Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class AdminRespository : IRepository<AdminEntity>
{
    private readonly DbSet<AdminEntity> _dbSet;
    private readonly OsuVtziContext _context;

    public AdminRespository(OsuVtziContext context)
    {
        _context = context;
        _dbSet = context.Set<AdminEntity>();
    }

    public IEnumerable<AdminEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<AdminEntity> Get(Func<AdminEntity, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    public AdminEntity FindById(int id)
    {
        return _dbSet.Find(id);
    }

    public int Create(AdminEntity item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    public int Update(AdminEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove(AdminEntity item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    public IEnumerable<AdminEntity> GetWithInclude(params Expression<Func<AdminEntity, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<AdminEntity> GetWithInclude(Func<AdminEntity, bool> predicate,
        params Expression<Func<AdminEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    public AdminEntity GetWithIncludeWithoutRelatedEntities(Guid Id)
    {
        throw new NotImplementedException();
    }

    private IQueryable<AdminEntity> Include(params Expression<Func<AdminEntity, object>>[] includeProperties)
    {
        IQueryable<AdminEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}
