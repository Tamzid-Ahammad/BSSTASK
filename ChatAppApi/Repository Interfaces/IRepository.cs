using System.Linq.Expressions;

namespace ChatAppApi.Repository_Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter,
           params Expression<Func<TEntity, object>>[] includes);
        TEntity Find(params object[] keyValues);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(params object[] keyValues);
        void Delete(TEntity entityToDelete);
        void DeleteRange(IEnumerable<TEntity> entityToDelete);

    }
}
