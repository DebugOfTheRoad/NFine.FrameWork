using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private NFineDbContext context = new NFineDbContext();

        public int Delete(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges();
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entityList = context.Set<TEntity>().Where(predicate).ToList();
            entityList.ForEach(m => context.Entry(m).State = System.Data.Entity.EntityState.Deleted);
            return context.SaveChanges();
        }

        public TEntity FindEntity(object keyValue)
        {
            return context.Set<TEntity>().Find(keyValue);
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Find(predicate);
        }

        public List<TEntity> FindList(string strSql)
        {
            return context.Database.SqlQuery<TEntity>(strSql).ToList();
        }

        public List<TEntity> FindList(string strSql, DbParameter[] dbParameters)
        {
            return context.Database.SqlQuery<TEntity>(strSql, dbParameters).ToList();
        }

        public int Insert(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return context.SaveChanges();
        }

        public int Insert(List<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            return context.SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public int Update(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    if (prop.GetValue(entity, null).ToString() == "&nbsp;")
                    {
                        context.Entry(entity).Property(prop.Name).CurrentValue = null;
                    }
                    context.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }
            return context.SaveChanges();
        }
    }
}
