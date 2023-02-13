using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
   public  class CityMap:BaseMAP<City>
    {
        public CityMap()
        {
            ToTable("Sehir").Property(x => x.SehirAdi).HasColumnName("SehirAdi")
            .IsOptional().HasMaxLength(50).HasColumnType("varchar");
            
        }
        
    }
}
