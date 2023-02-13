using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
   public class DuyuruİcerikMap : BaseMAP<Duyuruİcerik>
    {
        public DuyuruİcerikMap()
        {
            ToTable("Duyuruİcerik").Property(x => x.icerik).HasColumnName("İçerik")
            .IsOptional().HasMaxLength(250).HasColumnType("varchar");
            Property(x => x.DuyuruID).HasColumnName("DuyuruID")
            .HasColumnType("int");
        }
    }
}
