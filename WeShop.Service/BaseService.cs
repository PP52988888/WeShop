using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.IService;
using WeShop.IRepository;
using System.Linq.Expressions;

namespace WeShop.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baserepository)
        {
            _baseRepository = baserepository;
        }
        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.Savechanges();
        }

        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return  _baseRepository.QueryCount(whereLambda);
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }

        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            return _baseRepository.QueryEntitiesByPage(pageSize, pageIndex, isAsc, whereLambda, orderByLambda);
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
           return  _baseRepository.QueryEntity(whereLambda);
        }

        public bool Modify(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.Savechanges();
        }

        public bool Remove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.Savechanges();
        }
    }
}
