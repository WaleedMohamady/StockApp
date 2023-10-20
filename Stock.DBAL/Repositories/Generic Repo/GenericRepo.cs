using Microsoft.EntityFrameworkCore;
using Stock.DBAL.Context;
using Stock.DBAL.Repositories.Generic_Repo;

namespace Stock.DBAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    #region Fields
    private readonly StockDbContext _context;
    #endregion

    #region Ctor
    public GenericRepo(StockDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public  async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
    public async Task Add(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {

    }

    public async Task DeleteById(Guid id)
    {
        var deletedEntity = await GetById(id);
        if (deletedEntity is not null)
        {
            _context.Set<TEntity>().Remove(deletedEntity);
        }
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
    #endregion
}
