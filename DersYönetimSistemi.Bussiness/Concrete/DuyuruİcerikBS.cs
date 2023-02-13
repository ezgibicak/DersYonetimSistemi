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
    public class DuyuruİcerikBS : IDuyuruİcerikBS
    {
        private IDuyuruİcerikRepository _repo;
        public DuyuruİcerikBS(IDuyuruİcerikRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Duyuruİcerik Entity)
        {
            _repo.Delete(Entity);
        }

        public Duyuruİcerik Get(Expression<Func<Duyuruİcerik, bool>> filter = null, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public List<Duyuruİcerik> GetAll(Expression<Func<Duyuruİcerik, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public Duyuruİcerik Insert(Duyuruİcerik Entity)
        {
            return _repo.Insert(Entity);
        }

        public Duyuruİcerik Update(Duyuruİcerik Entity)
        {

            return _repo.Update(Entity); ;
        }
    }
}
