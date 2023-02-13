using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersYönetimSistemi.Bussiness.Abstract;
using DersYönetimSistemi.Bussiness.Concrete;
using DersYönetimSistemi.DataAccess.Abstract;
using DersYönetimSistemi.DataAccess.Concrete.EF.Repositories;
using Ninject.Modules;

namespace DersYönetimSistemi.Bussiness.DependencyResolver
{
   public class NinjectBussinessModule:NinjectModule
    {

        public override void Load()
        {
            Bind<IKullaniciRepository>().To<EFKullaniciRepository>().InSingletonScope();
            Bind<IKullaniciBS>().To<KullaniciBS>().InSingletonScope();

            Bind<ISehirRepository>().To<EFSehirRepository>().InSingletonScope();
            Bind<ISehirBS>().To<SehirBS>().InSingletonScope();

            Bind<IFakülteBölümDersRepository>().To<EFFakülteBölümDersRepository>().InSingletonScope();
            Bind<IFakülteBölümDersBS>().To<FakülteBölümDersBS>().InSingletonScope();

            Bind<IDuyuruRepository>().To<EFDuyuruRepository>().InSingletonScope();
            Bind<IDuyuruBS>().To<DuyuruBS>().InSingletonScope();

            Bind<IRolRepository>().To<EFRolRepository>().InSingletonScope();
            Bind<IRolBS>().To<RolBS>().InSingletonScope();

            Bind<IDuyuruİcerikRepository>().To<EFDuyuruİcerikRepository>().InSingletonScope();
            Bind<IDuyuruİcerikBS>().To<DuyuruİcerikBS>().InSingletonScope();
        }
    }
}
