using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.ViewModel.Front
{
    public class DuyurularViewModel:IBaseDomain
    {
        public string FakülteAdi { get; set; }
        public string Duyuru { get; set; }
        public int DuyuruID { get; set; }
    }
}
