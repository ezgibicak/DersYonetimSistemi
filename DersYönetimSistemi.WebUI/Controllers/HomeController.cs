using DersYönetimSistemi.Bussiness.Abstract;
using DersYönetimSistemi.Model.Domain;
using DersYönetimSistemi.Model.ViewModel.Front;
using DersYönetimSistemi.Utilities.Common;
using DersYönetimSistemi.Utilities.MVC;
using DersYönetimSistemi.WebUI.MvcHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersYönetimSistemi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ISehirBS _bs;
        IKullaniciBS _kbs;
        IFakülteBölümDersBS _fbdbs;
        IDuyuruBS _dbs;
        IDuyuruİcerikBS _dibs;
        public HomeController(ISehirBS bs, IKullaniciBS ks, IFakülteBölümDersBS fbdbs, IDuyuruBS dbs, IDuyuruİcerikBS dibs)
        {
            _bs = bs;
            _kbs = ks;
            _fbdbs = fbdbs;
            _dbs = dbs;
            _dibs = dibs;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {

            List<City> sehirlistesi = _bs.GetAll();
            RegisterViewModel vm = new RegisterViewModel();
            vm.Sehir = sehirlistesi;
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel vm)
        {
            List<City> sehirlistesi = _bs.GetAll();
            vm.Sehir = sehirlistesi;
            if (ModelState.IsValid)
            {
                User u = new User();
                u.Adi = vm.Adi;
                u.Soyadi = vm.Soyadi;
                u.Sifre = CryptoManager.AESEncrypt(vm.Sifre, "mühendis");
                u.SehirID = vm.SehirID;
                u.Email = vm.Email;
                u.AktifMi = 0;
                u.IP = IPManager.GetClientIPAddress();
                u.GüncellemeTarihi = DateTime.Now;
                u.OlusturulmaTarihi = DateTime.Now;
                u.UniqueID = Guid.NewGuid();
                var sonucKullanici = _kbs.Insert(u);
                if (sonucKullanici != null)
                {
                    TempData["Mesaj"] = "Başarıyla Kayıt Oldunuz.";
                    MailManager mg = new MailManager(vm.Email);
                    string mesaj = " Sayın: " + u.Adi + " " + u.Soyadi + "<br/> Ders Yönetim Sistemine Başarıyla Kayıt Oldunuz. Giriş Yapabilmek için <a href ='http://localhost:11226/Home/EmailOnay/" + u.UniqueID + "'> Lütfen Tıklayınız.</a>";
                    bool mailSonuc = mg.SendMail(mesaj, "Ders Yönetim Sistemi Kayıt Onayı");
                    if (mailSonuc)
                    {
                        TempData["Mesaj"] += "Lütfen Emailinizi Kontrol Ediniz.";
                    }
                    else
                    {
                        TempData["Mesaj"] += "Mail gönderilirken bir hata oluştu.";
                    }
                }
                else
                {
                    TempData["Mesaj"] = "Bir Hata oluştu.";
                }
            }
            else
            {
                TempData["Mesaj"] = "Bir Hata oluştu.";
            }

            return View(vm);
        }
        public JsonResult EmailKontrol(string Email)
        {
            User kullanici = _kbs.Get(x => x.Email == Email);
            if (kullanici != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EmailOnay(string id)
        {
            User u = _kbs.Get(x => x.UniqueID.ToString() == id);
            if (u != null)
            {
                u.AktifMi = 1;
                u.UniqueID = Guid.NewGuid();
                _kbs.Update(u);
                return View("EmailOnay");
            }
            else
            {
                return View("EmailError");
            }

        }
        public ActionResult Captcha()
        {

            return new CapthcaImageResult();

        }
        public ActionResult Fakülteler()
        {
            List<Faculty> liste = _fbdbs.GetAll(x => x.UstKategoriID == null);
            return View(liste);
        }
        public ActionResult Hakkımızda()
        {
            return View();
        }
        public ActionResult Duyurular()
        {
            List<Duyurular> duyurular = _dbs.GetAll();
            return View(duyurular);
        }
        public ActionResult Duyuru(int id)
        {
            Duyuruİcerik duyuruicerik = _dibs.Get(x => x.DuyuruID == id);
            return View(duyuruicerik);
        }
        public ActionResult ÖneriSikayet()
        {
            return View();
        }
        public ActionResult iletişim()
        {
            return View();
        }

    }
}