using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Core.Domain
{
    public abstract class AuditableEntity
    {

        public virtual int ID { get; set; }
        public virtual DateTime? OlusturulmaTarihi { get; set; }
        public virtual DateTime? GüncellemeTarihi { get; set; }
        public virtual int? AktifMi { get; set; }
        public virtual string IP { get; set; }
    }
}
