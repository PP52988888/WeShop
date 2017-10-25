using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;

namespace WeShop.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private WeShopDb _dbContent = DbContextFactory.GetIntance();
        private DbSet<TEntity> _dbSet;
        public BaseRepository()
        {
            _dbSet = _dbContent.Set<TEntity>();
        }
        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
             return    _dbSet.Count(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,    Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            var result = _dbSet.Where(whereLambda);
            result = isAsc ? result.OrderBy(orderByLambda) : result.OrderByDescending(orderByLambda);
            var offset = (pageIndex - 1) * pageSize;
            result = result.Skip(offset).Take(pageSize);
            return result;
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public bool Savechanges()
        {
           return  _dbContent.SaveChanges()>0;
        }

        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbContent.Entry(tEntity).State = EntityState.Modified;
        }
    }
}
