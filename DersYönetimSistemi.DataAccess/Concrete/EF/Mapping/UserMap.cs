using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF.Mapping
{
    public class UserMap : BaseMAP<User>
    {

        public UserMap()
        {
            ToTable("Kullanıcı")
                .Property(x => x.Adi)
                .HasColumnName("Adi")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Soyadi)
                .HasColumnName("Soyadi")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Sifre)
               .HasColumnName("Sifre")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsOptional();

            Property(x => x.Email)
               .HasColumnName("Email")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsOptional();

            Property(x => x.Adres)
               .HasColumnName("Adres")
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsOptional();

            Property(x => x.TC)
              .HasColumnName("TC")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsOptional();

            Property(x => x.SehirID)
             .HasColumnName("SehirID")
             .HasColumnType("int")
             .IsOptional();

            Property(x => x.Resim)
           .HasColumnName("Resim")
           .HasColumnType("varchar")
           .HasMaxLength(250)
           .IsOptional();

            Property(x => x.UniqueID)
            .HasColumnName("UniqueID")
            .HasColumnType("uniqueidentifier")
            .IsOptional();

             Property(x => x.DogumTarihi)
            .HasColumnName("DogumTarihi")
            .HasColumnType("datetime")
            .IsOptional();

            Property(x => x.Telno)
            .HasColumnName("TelefonNo")
            .HasColumnType("varchar")
            .IsOptional();

            HasMany<Role>(s => s.Rolleri)
               .WithMany(c => c.Kullanici)
               .Map(cs =>
               {
                   cs.MapLeftKey("KullanıcıID");
                   cs.MapRightKey("RolID");
                   cs.ToTable("KullanıcıRol");
               });


            HasMany<Faculty>(s => s.FakülteBolumDers)
             .WithMany(c => c.Kullanıcılar)
             .Map(cs =>
             {
                 cs.MapLeftKey("KullanıcıID");
                 cs.MapRightKey("DersID");
                 cs.ToTable("KullanıcıDers");
             });



        }
    }
}
