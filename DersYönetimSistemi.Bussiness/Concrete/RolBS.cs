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
    public class RolBS : IRolBS
    {
        private IRolRepository _repo;
        public RolBS(IRolRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Role Entity)
        {
            _repo.Delete(Entity);
        }

        public Role Get(Expression<Func<Role, bool>> filter = null, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public List<Role> GetAll(Expression<Func<Role, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public Role Insert(Role Entity)
        {
            return _repo.Insert(Entity);
        }

        public Role Update(Role Entity)
        {
            return _repo.Update(Entity);
        }
    }
}
