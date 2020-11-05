using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Tools.Loan.DataAcces.Repositories
{
    interface IRepository<TEntity>: IDisposable where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entityToUpdate);
        ICollection<TEntity> GetAll(Expression<Func<TEntity,bool>> expression);

       int SaveChages();
  }
}
