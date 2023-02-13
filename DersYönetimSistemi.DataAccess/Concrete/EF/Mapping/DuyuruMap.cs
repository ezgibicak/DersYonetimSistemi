using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
    public class DuyuruMap:BaseMAP<Duyurular>
    {
        public DuyuruMap()
        {

            ToTable("Duyurular").Property(x => x.Duyuru).HasColumnName("Duyuru")
            .IsOptional().HasMaxLength(250).HasColumnType("varchar");

            HasMany<Faculty>(s => s.Fakülteler)
                .WithMany(c => c.FakülteDuyuruları)
                .Map(cs =>
                {
                    cs.MapLeftKey("FakülteID");
                    cs.MapRightKey("DuyuruID");
                    cs.ToTable("FakülteDuyuru");
                });

        }


    }
}
