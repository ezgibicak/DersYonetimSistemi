using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.Domain
{
    public class Duyurular : AuditableEntity, IBaseDomain
    {
       
        public string Duyuru { get; set; }
        public List<Faculty> Fakülteler { get; set; }
    }
}
