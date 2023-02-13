using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Bussiness.Abstract
{
   public interface IKullaniciBS
    {

        List<User> GetAll(Expression<Func<User, bool>> filter = null, params string[] includeList);
        User Get(Expression<Func<User, bool>> filter = null, params string[] includeList);
        User Insert(User Entity);
        User Update(User Entity);
        void Delete(User Entity);
        void Save();
        void Remove(User Entity);
        //Kullanıcıya Özel Methodlar
        User GetByID(int id, params string[] includeList);
        User GetByEmailAndPassword(string email, string password, params string[] includeList);

    }
}
