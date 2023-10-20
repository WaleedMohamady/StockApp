namespace Stock.DBAL.Repositories.Generic_Repo;

public interface IGenericRepo<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(Guid id);
    Task Add(TEntity entity);
    void Update(TEntity entity);
    Task DeleteById(Guid id);
    Task SaveChanges();
}
