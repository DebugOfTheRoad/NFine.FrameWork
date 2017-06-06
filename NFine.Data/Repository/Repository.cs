using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NFine.Data.Repository
{
    public class Repository : IRepository
    {
        #region 私有变量

        private NFineDbContext context = new NFineDbContext();
        private DbTransaction trans;

        #endregion

        #region 公有方法

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public IRepository BeginTrans()
        {
            DbConnection conn = ((IObjectContextAdapter)context).ObjectContext.Connection;
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            trans = conn.BeginTransaction();
            return this;
        }

        /// <summary>
        /// 基于事务提交修改操作
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            try
            {
                var ret = context.SaveChanges();
                if (trans != null)
                {
                    trans.Commit();
                }
                return ret;
            }
            catch (Exception)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw;
            }
            finally
            {
                this.Dispose();
            }
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
            return trans == null ? this.Commit() : 0;
        }

        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entityList = context.Set<TEntity>().Where(predicate).ToList();
            entityList.ForEach(m => context.Entry<TEntity>(m).State = System.Data.Entity.EntityState.Deleted);
            return trans == null ? this.Commit() : 0;
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
            }
            context.Dispose();
        }

        public TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return context.Set<TEntity>().Find(keyValue);
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> FindList<TEntity>(string strSql) where TEntity : class
        {
            return context.Database.SqlQuery<TEntity>(strSql).ToList();
        }

        public List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameters) where TEntity : class
        {
            return context.Database.SqlQuery<TEntity>(strSql, dbParameters).ToList();
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return trans == null ? this.Commit() : 0;
        }

        public int Insert<TEntity>(List<TEntity> entityList) where TEntity : class
        {
            foreach (var entity in entityList)
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            return trans == null ? this.Commit() : 0;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null).ToString() == "&nbsp;")
                {
                    context.Entry(entity).Property(prop.Name).CurrentValue = null;
                }
                context.Entry(entity).Property(prop.Name).IsModified = true;
            }
            return trans == null ? this.Commit() : 0;
        }

        #endregion
    }
}
