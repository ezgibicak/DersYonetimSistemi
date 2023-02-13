using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class User : AuditableEntity, IBaseDomain
    {

        public string Email { get; set; }
        public string Sifre { get; set; }
        public int? SehirID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Adres { get; set; }
        public string TC { get; set; }
        public string Resim { get; set; }
        public Guid? UniqueID { get; set; }
        public string Telno { get; set; }
        public DateTime? DogumTarihi { get; set; }
        //------------------------------------
        public List<Role> Rolleri { get; set; }
        public City Sehir { get; set; }
        public List<Faculty> FakülteBolumDers { get; set; }
    }
}
