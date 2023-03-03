using finalProject.Common.Entities.Abstracts;
using finalProject.Common.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace finalProject.Common.Repositories.EntityFramework
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext, new()
    {

        #region Writing Methods
        public void Insert(TEntity data)
        {
            using TContext db = new();
            db.Add(data);
            db.SaveChanges();
        }
        public async Task InsertAsync(TEntity data)
        {
            using TContext db = new();
            await db.AddAsync(data);
            db.SaveChanges();
        }
        public void Update(TEntity data)
        {
            using TContext db = new();
            db.Update(data);
            db.SaveChanges();
        }
        #endregion

        #region Reading Methods
        public IEnumerable<TEntity> GetAll(bool noTrack = true)
        {
            using TContext db = new();
            return noTrack ? db.Set<TEntity>().AsNoTracking().ToList() : db.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool noTrack = true)
        {
            using TContext db = new();
            return noTrack ?
                db.Set<TEntity>().AsNoTracking().Where(filter).ToList()
                : db.Set<TEntity>().Where(filter).ToList();
        }
        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> filter, bool noTrack = true)
        {
            using TContext db = new();
            return noTrack ? 
                await db.Set<TEntity>().AsNoTracking().Where(filter).ToListAsync()
                : await db.Set<TEntity>().Where(filter).ToListAsync();
        }
        public TEntity GetById(Guid id, bool noTrack = true)
        {
            using TContext db = new();
            TEntity query = db.Set<TEntity>().Find(id);
            if (noTrack) db.Entry(query).State = EntityState.Detached;
            return query;
        }
        public async Task<TEntity> GetByIdAsync(Guid id, bool noTrack = true)
        {
            using TContext db = new();
            TEntity query = await db.Set<TEntity>().FindAsync(id);
            if (noTrack) db.Entry(query).State = EntityState.Detached;
            return query;
        }
        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter, bool noTrack = true)
        {
            using TContext db = new();
            return noTrack ? db.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefault() 
                : db.Set<TEntity>().AsNoTracking().FirstOrDefault();
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool noTrack = true)
        {
            using TContext db = new();
            return noTrack ? await
                db.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefaultAsync()
                : await db.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
        }
        #endregion
    }
}
