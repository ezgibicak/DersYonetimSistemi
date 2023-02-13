using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class KullanıcıDers: IBaseDomain
    {
        public int DersID { get; set; }
        public int KullanıcıID { get; set; }
    }
}
