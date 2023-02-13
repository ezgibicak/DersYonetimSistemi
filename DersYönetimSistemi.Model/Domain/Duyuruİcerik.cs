using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
   public class Duyuruİcerik: AuditableEntity,IBaseDomain
    {
        public int DuyuruID { get; set; }
        public string icerik { get; set; }
    }
}
