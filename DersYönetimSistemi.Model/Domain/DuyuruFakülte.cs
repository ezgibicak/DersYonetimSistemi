using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
   public class DuyuruFakülte: IBaseDomain
    {
        public int FakülteID { get; set; }
        public int DuyuruID { get; set; }
    }
}
