using Aniventi.BLL.Repositories.Interfaces;
using Aniventi.DAL.ORM.Context;
using Aniventi.DAL.ORM.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.BLL.Services.Repositories.General
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        internal AniventiECommerceContext context;

        internal DbSet<T> dbSet;

        public GenericRepository(AniventiECommerceContext aniventiECommerceContext)
        {
            this.context = aniventiECommerceContext;
            this.dbSet = context.Set<T>();
        }


        public virtual void Add(T entity)
        {
            entity.AddDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.IsDeleted = false;

            dbSet.Add(entity);
        }

        public virtual List<T> GetAll()
        {
            return dbSet.Where(x => x.IsDeleted == false).OrderByDescending(x => x.AddDate).ToList();
        }

        public virtual T GetById(Guid id)
        {
            T entity = dbSet.FirstOrDefault(q => q.Id == id && q.IsDeleted == false);
            return entity;
        }

        public virtual void HardDelete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Remove(Guid id)
        {
            T entity = dbSet.FirstOrDefault(q => q.Id == id);

            if (entity != null)
            {
                entity.IsDeleted = false;
            }
        }

        public List<T> GetListByQueries(Expression<Func<T, bool>> filter)
        {
            var entities = dbSet.Where(q => q.IsDeleted == false).Where(filter).ToList();
            return entities;
        }

        public T GetByQuery(Expression<Func<T, bool>> filter)
        {
            var entity = dbSet.Where(q => q.IsDeleted == false).FirstOrDefault(filter);
            return entity;
        }
    }
}
