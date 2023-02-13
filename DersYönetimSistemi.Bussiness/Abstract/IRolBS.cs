using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
    public interface IRolBS
    {

        List<Role> GetAll(Expression<Func<Role, bool>> filter = null, params string[] includeList);
        Role Get(Expression<Func<Role, bool>> filter = null, params string[] includeList);
        Role Insert(Role Entity);
        Role Update(Role Entity);
        void Delete(Role Entity);

       
    }
}
