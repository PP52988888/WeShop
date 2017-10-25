using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeShop.IService
{
    public  interface IBaseService<TEntity> where TEntity : class, new()
    {
        bool  Add(TEntity tEntity);
        bool  Remove(TEntity tEntity);
        bool  Modify(TEntity tEntity);
        TEntity  GetEntity(Func<TEntity,bool> whereLambda );
        int GetCount(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);

        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda);
    }
}
