using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
    public interface IDuyuruBS
    {
        List<Duyurular> GetAll(Expression<Func<Duyurular, bool>> filter = null, params string[] includeList);
        Duyurular Get(Expression<Func<Duyurular, bool>> filter = null, params string[] includeList);
        Duyurular Insert(Duyurular Entity);
        Duyurular Update(Duyurular Entity);
        void Delete(Duyurular Entity);


    }
}
