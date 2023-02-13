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
    public class DuyuruBS : IDuyuruBS
    {
        private IDuyuruRepository _repo;
        public DuyuruBS(IDuyuruRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Duyurular Entity)
        {
            _repo.Delete(Entity);
        }

        public Duyurular Get(Expression<Func<Duyurular, bool>> filter = null, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public List<Duyurular> GetAll(Expression<Func<Duyurular, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public Duyurular Insert(Duyurular Entity)
        {
            return _repo.Insert(Entity);
        }

        public Duyurular Update(Duyurular Entity)
        {
            return _repo.Update(Entity);
        }

    }
}
