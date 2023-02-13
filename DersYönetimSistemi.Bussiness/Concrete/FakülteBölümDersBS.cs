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
    public class FakülteBölümDersBS : IFakülteBölümDersBS
    {
        private IFakülteBölümDersRepository _repo;
        public FakülteBölümDersBS(IFakülteBölümDersRepository repo)
        {
            _repo=repo;

        }
        public void Delete(Faculty Entity)
        {
            _repo.Delete(Entity);
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter = null, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public List<Faculty> GetAll(Expression<Func<Faculty, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public Faculty Insert(Faculty Entity)
        {
            return _repo.Insert(Entity);
        }

        public Faculty Update(Faculty Entity)
        {
            return _repo.Update(Entity);
        }

       

    }
}
