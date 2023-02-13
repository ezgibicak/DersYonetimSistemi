using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class Role : AuditableEntity, IBaseDomain
    {
        public string RolAdi { get; set; }
        public List<User> Kullanici { get; set; }
    }
}
