using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tools.Loan.DataAcces.Repositories
{
    class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal AppContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(AppContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters)
        {
            return dbSet.FromSql(query, parameters).ToList();
        }

       

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
           
            dbSet.Remove(entityToDelete);
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
            return entityToUpdate;
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).ToList();

        }
        public int SaveChages()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
