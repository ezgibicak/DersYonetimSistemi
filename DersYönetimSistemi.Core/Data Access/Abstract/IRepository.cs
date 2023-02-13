using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Core.Data_Access.Abstract
{
   public interface IRepository<T>
    {

        List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeList);
        T Get(Expression<Func<T, bool>> filter = null, params string[] includeList);
        T Insert(T Entity);
        T Update(T Entity);
        void Delete(T Entity);
        void Save();
    }
}
