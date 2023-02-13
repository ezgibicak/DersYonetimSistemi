using DersYönetimSistemi.Core.Data_Access.Abstract;
using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Core.Data_Access.Concrete.Ef
{
    public class EfRepository<MyContext, T> : IRepository<T>
    where T : AuditableEntity, IBaseDomain, new()
        where MyContext : DbContext, new()
    {
        public void Delete(T Entity)
        {
            MyContext ctx = new MyContext();
            T attcahed = ctx.Set<T>().Attach(Entity);
            T deleted = ctx.Set<T>().Remove(Entity);
            ctx.SaveChanges();

        }

        public void Save()
        {
            MyContext ctx = new MyContext();
            ctx.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter = null, params string[] includeList)
        {

            MyContext ctx = new MyContext();
            IQueryable<T> query = ctx.Set<T>();
            if (includeList != null && includeList.Length > 0)
            {

                foreach (string item in includeList)
                {
                    query = query.Include(item);
                }

            }
            return query.SingleOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeList)
        {
            MyContext ctx = new MyContext();
            IQueryable<T> query = ctx.Set<T>();

            if (filter != null)
            {
                query.Where(filter);
            }
            if (includeList != null && includeList.Length > 0)
            {
                foreach (string item in includeList)
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();


        }

        public T Insert(T Entity)
        {
            MyContext ctx = new MyContext();
            T added = ctx.Set<T>().Add(Entity);
            ctx.SaveChanges();
            return added;
        }

        public T Update(T Entity)
        {
            MyContext ctx = new MyContext();
            T attachentity = ctx.Set<T>().Attach(Entity);
            ctx.Entry(Entity).State = EntityState.Modified;
            ctx.SaveChanges();
            return attachentity;
        }
    }
}
