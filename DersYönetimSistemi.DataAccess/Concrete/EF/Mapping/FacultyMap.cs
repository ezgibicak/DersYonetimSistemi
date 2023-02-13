using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
   public class FacultyMap : BaseMAP<Faculty>
    {
        public FacultyMap()
        {
            ToTable("FakülteBölümDers").Property(x => x.KategoriAdi).HasColumnName("KategoriAdi").IsOptional().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.UstKategoriID).HasColumnName("UstKategoriID").HasColumnType("int").IsOptional();
        }
    }
}
