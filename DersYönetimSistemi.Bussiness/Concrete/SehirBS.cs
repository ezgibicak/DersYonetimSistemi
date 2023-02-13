using DersYönetimSistemi.Bussiness.Abstract;
using DersYönetimSistemi.DataAccess.Abstract;
using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Concrete
{
   public class SehirBS : ISehirBS
    {
        private ISehirRepository _repo;
        public SehirBS(ISehirRepository repo)
        {
            _repo = repo;
        }
        public void Delete(City Entity)
        {
            _repo.Delete(Entity);
        }

        public City Get(Expression<Func<City, bool>> filter = null, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public List<City> GetAll(Expression<Func<City, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public City Insert(City Entity)
        {
            return _repo.Insert(Entity);
        }

        public City Update(City Entity)
        {
            return _repo.Update(Entity);
        }
    }
}
