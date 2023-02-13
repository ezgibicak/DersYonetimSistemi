using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class UserRole:IBaseDomain
    {
        public int KullaniciID { get; set; }
        public int RolID { get; set; }
    }
}
