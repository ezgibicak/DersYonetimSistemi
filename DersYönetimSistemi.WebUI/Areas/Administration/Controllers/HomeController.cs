using DersYönetimSistemi.Core.Data_Access.Abstract;
using DersYönetimSistemi.Core.Data_Access.Concrete.Ef;

using DersYönetimSistemi.Model.ViewModel.Areas.Yönetim.User.LogIn;
using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DersYönetimSistemi.Bussiness.Concrete;
using DersYönetimSistemi.Bussiness.Abstract;
using DersYönetimSistemi.WebUI.MvcHelper;
using DersYönetimSistemi.Utilities.Common;
using DersYönetimSistemi.Model.ViewModel;
using System.IO;
using DersYönetimSistemi.Model.ViewModel.Front;

namespace DersYönetimSistemi.WebUI.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/Home
        IKullaniciBS _bs;
        IFakülteBölümDersBS _fbdbs;
        IRolBS _rbs;
        public HomeController(IKullaniciBS bs, IFakülteBölümDersBS fbdbs, IRolBS rbs)
        {
            _bs = bs;
            _fbdbs = fbdbs;
            _rbs = rbs;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogInViewModel lvm)
        {
           
            string Password = CryptoManager.AESEncrypt(lvm.Password, "mühendis");
            User k = _bs.GetByEmailAndPassword(lvm.Email,Password, "Rolleri");
          
            if (k != null)
            {
                //Session["AktifKullanici"] = k;
                //////COOKIE
                //HttpCookie c = new HttpCookie("Müşteri");
                //c.Value = k.UniqueID.ToString();
                //c.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(c);
                SessionManager.AktifKullanici = k;
                return View("Dashboard");

            }
            else
            {
                LogInViewModel loginModel = new LogInViewModel();
                TempData["Mesaj"] = "Girilen bilgiler hatalı.";
                return View(loginModel);

            }


        }
        [AktifKullaniciSessionFilter]
        public ActionResult Dashboard()
        {
            //User u = SessionManager.AktifKullanici;
            //if (u == null)
            //{
            //    return RedirectToAction("LogIn", "Home");
            //}
            //else {
            //    return View();
            //}

            return View();           
        }
        public ActionResult LogOut()
        {
            SessionManager.AktifKullanici = null;
            return RedirectToAction("LogIn", "Home");
        }

        [AktifKullaniciSessionFilter]
        [RoleFilter("Yönetici")] 
        public ActionResult UserControl()
        {
            List<UserControlViewModel> Kullanıcı=_bs.GetAll(null,"Sehir").Select(x=>new UserControlViewModel() {
                Adi=x.Adi,Soyadi=x.Soyadi,Email=x.Email,SehirID=x.SehirID,SehirAdi=x.Sehir.SehirAdi,AktifMi=x.AktifMi,
                KullanıcıID=x.ID
            }).ToList();
            return View(Kullanıcı);

        }
        public JsonResult KullaniciOnayla(int kid)
        {
            User u = _bs.Get(x => x.ID == kid);
            u.AktifMi = 2;
            _bs.Update(u);
            return Json(new {Result=true,Mesaj="Kullanıcı Onaylandı." });
        }
        public JsonResult KullaniciOnayIptal(int kid)
        {
            User u = _bs.Get(x => x.ID == kid);
            u.AktifMi = 0;
            _bs.Update(u);
            return Json(new { Result = true, Mesaj = "Kullanıcı Onayı İptal Edildi." });
        }
        public ActionResult NotAllowed()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            return View();
        }
        public ActionResult ResimGüncelle()
        {
            HttpFileCollectionBase hfps = Request.Files;
            HttpPostedFileBase hfp = hfps[0];
            if (hfp.ContentLength > 1024000)
            {
                return Json(new { Result = false, Mesaj = "Lütfen 1MB altında dosya yükleniniz" });
            }
            else if (!hfp.ContentType.Contains("image/"))
            {
                return Json(new { Result = false, Mesaj = "Lütfen Sadece Resim Seçiniz." });
            }

            else
            {
                string uzanti = Path.GetExtension(hfp.FileName);

                string dosyaismi = RandomValueGenerator.GetRandomValue(uzanti);

                hfp.SaveAs(Server.MapPath("~/Content/img/" + dosyaismi));

                User k = _bs.GetByID(SessionManager.AktifKullanici.ID);
                // Kullanıcının eski resmi sunucu üzerinden silinmesi gerekir.
                k.Resim = "/Content/img/" + dosyaismi;
                _bs.Update(k);
                SessionManager.AktifKullanici = k;

                return Json(new { Result = true, UserPhoto = "/Content/img/" + dosyaismi, Mesaj = "Resim Başarıyla Güncellendi." });
            }
        }
        public JsonResult SifreDegistir(SifreDegistirViewModel vm)
        {

            if (vm.YeniSifre != vm.YeniSifreTekrar)
            {
                return Json(new { Result = false, Mesaj = "Şifreler eşleşmiyor." });
            }

            else if (vm.Sifre != CryptoManager.AESDecrypt(SessionManager.AktifKullanici.Sifre, "mühendis"))
            {
                return Json(new { Result = false, Mesaj = "Şifreniz Hatalı." });
            }
            else
            {
                User u = _bs.GetByID(SessionManager.AktifKullanici.ID);
                u.Sifre = CryptoManager.AESEncrypt(vm.YeniSifre, "mühendis");
                _bs.Update(u);
                MailManager m = new MailManager(u.Email);
                m.SendMail("Şifreniz Başarıyla Değiştirildi.","Şifre Değişikliği");
                SessionManager.AktifKullanici = u;
                return Json(new { Result = true, Mesaj = "Şifreniz Başarıyla Değiştirildi." });
            }
        }
        public JsonResult ProfilBilgileriGüncelle(ProfilBilgileriViewModel vm)
        {
            User u = _bs.GetByID(SessionManager.AktifKullanici.ID);
            u.Adi = vm.Ad;
            u.Soyadi = vm.Soyad;
            u.Email = vm.Email;
            u.Telno = vm.TelNo;
            u.DogumTarihi = vm.DogumTarihi;
            _bs.Update(u);
            MailManager m = new MailManager(u.Email);
            m.SendMail("Bilgileriniz Başarıyla Değiştirildi.", "Profil Bilgi Güncelleme");
            SessionManager.AktifKullanici = u;
            return Json(new { Result = true, Mesaj = "Bilgileriniz Başarıyla Değiştirildi." });
        }
        public ActionResult Faculty()
        {
            List<Faculty> liste = _fbdbs.GetAll(x => x.UstKategoriID == null);
            return View(liste);
        }
        public ActionResult Dersler()
        {
            User u = _bs.GetByID(SessionManager.AktifKullanici.ID, "FakülteBolumDers");
            return View(u);
        }
        public ActionResult KullaniciSil(int id)
        {
            User u = _bs.GetByID(id);
            _bs.Delete(u);
            //return Json(new { Result = true, Mesaj = "Kullanıcı Silindi." });
            return RedirectToAction("UserControl", "Home");

        }


    }
}