using DersYönetimSistemi.DataAccess.Concrete.EF.Mapping;
using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.DataAccess.Concrete.EF
{
   public class DersYönetimSistemiDbContext:DbContext
    {

        public DersYönetimSistemiDbContext():base("DersYönetimSistemi")
        {
            Database.SetInitializer<DersYönetimSistemiDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Duyurular> Duyurular { get; set; }
        public virtual DbSet<Duyuruİcerik> Duyuruİcerik { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new FacultyMap());
            modelBuilder.Configurations.Add(new DuyuruMap());
            modelBuilder.Configurations.Add(new DuyuruİcerikMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
