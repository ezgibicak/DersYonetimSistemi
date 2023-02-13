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
    public class KullaniciBS : IKullaniciBS
    {
        private IKullaniciRepository _repo;
        public KullaniciBS(IKullaniciRepository repo)
        {
            _repo = repo;
        }
        public void Delete(User Entity)
        {
            _repo.Delete(Entity);
        }
        
        public User Get(Expression<Func<User, bool>> filter = null, params string[] includeList)
        {
           return  _repo.Get(filter, includeList);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList);
        }

        public User GetByEmailAndPassword(string email, string password, params string[] includeList)
        {
            return _repo.Get(x => x.Email == email && x.Sifre == password, includeList);
        }

        public User GetByID(int id, params string[] includeList)
        {
            return _repo.Get(x => x.ID==id, includeList);
        }

        public User Insert(User Entity)
        {
           return  _repo.Insert(Entity);
        }

        public void Remove(User Entity)
        {
            
            _repo.Delete(Entity);
        }

        public void Save()
        {
            _repo.Save();
        }

        public User Update(User Entity)
        {
            return _repo.Update(Entity);
        }
    }
}
