using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
   public interface IDuyuruİcerikBS
    {

        List<Duyuruİcerik> GetAll(Expression<Func<Duyuruİcerik, bool>> filter = null, params string[] includeList);
        Duyuruİcerik Get(Expression<Func<Duyuruİcerik, bool>> filter = null, params string[] includeList);
        Duyuruİcerik Insert(Duyuruİcerik Entity);
        Duyuruİcerik Update(Duyuruİcerik Entity);
        void Delete(Duyuruİcerik Entity);
    }
}
