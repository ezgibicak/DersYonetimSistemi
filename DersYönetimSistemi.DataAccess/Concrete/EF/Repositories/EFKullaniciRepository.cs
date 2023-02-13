using DersYönetimSistemi.Core.Data_Access.Concrete.Ef;
using DersYönetimSistemi.DataAccess.Abstract;
using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Repositories
{
   public class EFKullaniciRepository: EfRepository<DersYönetimSistemiDbContext,User>, IKullaniciRepository
    {
    }
}
