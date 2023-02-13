using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
    public interface ISehirBS
    {
        List<City> GetAll(Expression<Func<City, bool>> filter = null, params string[] includeList);
        City Get(Expression<Func<City, bool>> filter = null, params string[] includeList);
        City Insert(City Entity);
        City Update(City Entity);
        void Delete(City Entity);

        
    }
}
