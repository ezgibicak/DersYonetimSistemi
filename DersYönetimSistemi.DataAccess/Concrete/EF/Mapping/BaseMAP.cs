using DersYönetimSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
   public class BaseMAP<T>:EntityTypeConfiguration<T>
        where T: AuditableEntity
    {

        public BaseMAP()
        {
            Property(x => x.ID).HasColumnName("ID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IP).HasColumnName("IP")
                .HasColumnType("varchar").HasMaxLength(50).
                IsOptional();
            Property(x => x.AktifMi).HasColumnName("AktifMİ")
                .HasColumnType("int").IsOptional();
            Property(x => x.OlusturulmaTarihi).HasColumnName("OlusturulmaTarihi").HasColumnType("datetime").IsOptional();
            Property(x=>x.GüncellemeTarihi).HasColumnName("GüncellemeTarihi").HasColumnType("datetime").IsOptional();

        }
    }
}
