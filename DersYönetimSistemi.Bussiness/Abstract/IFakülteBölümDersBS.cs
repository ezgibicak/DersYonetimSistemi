using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
    public interface IFakülteBölümDersBS
    {

        List<Faculty> GetAll(Expression<Func<Faculty, bool>> filter = null, params string[] includeList);
        Faculty Get(Expression<Func<Faculty, bool>> filter = null, params string[] includeList);
        Faculty Insert(Faculty Entity);
        Faculty Update(Faculty Entity);
        void Delete(Faculty Entity);
    }
}
