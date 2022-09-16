using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract.Repository
{
    public class EfDalBase<TEntity, TContext> 
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        TContext chatAppContext = new TContext();

        public int Add(TEntity entity)
        {
            chatAppContext.Add(entity!);
             int add = chatAppContext.SaveChanges();
            return add;
        }

        public int Delete(TEntity entity)
        {
            chatAppContext.Remove(entity!);
            int delete = chatAppContext.SaveChanges();
            return delete;
        }
        public int Update(TEntity entity)
        {
            chatAppContext.Update(entity!);
            int update = chatAppContext.SaveChanges();
            return update;
        }
        public List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                     ? chatAppContext.Set<TEntity>().ToList()
                     : chatAppContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity? GetById(Expression<Func<TEntity, bool>> filter)
        {
            return chatAppContext.
                Set<TEntity>().
                SingleOrDefault(filter);
        }

    }
}
