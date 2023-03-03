using finalProject.Common.Entities.Abstracts;
using System.Linq.Expressions;

namespace finalProject.Common.Repositories.Abstracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Writing Methods
        void Insert(TEntity data);
        Task InsertAsync(TEntity data);
        void Update(TEntity data);
        #endregion

        #region Reading Methods
        IEnumerable<TEntity> GetAll(bool noTrack = true);
        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity,bool>> filter, bool noTrack = true);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity,bool>> filter, bool noTrack = true);
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter, bool noTrack = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool noTrack = true);
        TEntity GetById(Guid id, bool noTrack = true);
        Task<TEntity> GetByIdAsync(Guid id, bool noTrack = true);
        #endregion
    }
}
