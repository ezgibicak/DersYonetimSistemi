using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class Faculty:AuditableEntity,IBaseDomain 
    {
        public int? UstKategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public List<Duyurular> FakülteDuyuruları { get; set; }
        public List<User> Kullanıcılar { get; set; }
    }
}
