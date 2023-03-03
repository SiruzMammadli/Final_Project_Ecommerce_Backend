using finalProject.Common.Entities.Abstracts;
using System.Linq.Expressions;

namespace finalProject.Common.Repositories.Abstracts
{
    public interface IMongoRepository<TDocument> where TDocument : class, IMongoEntity
    {
        #region Writing Methods
        void Insert(TDocument data);
        Task InsertAsync(TDocument data);
        void Update(TDocument data);
        Task UpdateAsync(TDocument data);
        #endregion

        #region Reading Methods
        IEnumerable<TDocument> GetAll();
        IEnumerable<TDocument> GetWhere(Expression<Func<TDocument,bool>> filter);
        #endregion
    }
}
