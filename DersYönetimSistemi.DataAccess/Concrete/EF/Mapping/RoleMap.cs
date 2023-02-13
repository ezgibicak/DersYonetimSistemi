using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
    public class RoleMap:BaseMAP<Role>
    {
        public RoleMap()
        {
            ToTable("Rol").Property(x => x.RolAdi).HasColumnName("RolAdi").IsOptional().HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
