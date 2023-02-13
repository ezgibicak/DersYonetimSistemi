using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DersYönetimSistemi.Utilities.MVC;

namespace DersYönetimSistemi.Model.ViewModel.Front
{
   public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adını Boş Bırakmayınız.")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadını Boş Bırakmayınız.")]
        public string Soyadi { get; set; }
        [Display(Name ="E-MAIL")]
        [EmailAddress(ErrorMessage ="E-mail adresi uygun değil.")]
        [Required(ErrorMessage ="Lütfen Emaili Boş Bırakmayınız.")]
        [System.Web.Mvc.Remote("EmailKontrol","Home",ErrorMessage="Bu Email Kullanılıyor.")]
        public string Email { get; set; }

        [StringLength(10,ErrorMessage ="Şifreniz 3 ila 10 karakter olmalıdır.",MinimumLength =3)]
        [Required(ErrorMessage = "Lütfen Şifreyi Boş Bırakmayınız.")]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$%\\^&\\*])(?=.{8,})",ErrorMessage ="Şifre uygun değil")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Tekrarı Boş Bırakmayınız.")]
        [System.ComponentModel.DataAnnotations.Compare("Sifre",ErrorMessage ="Şifreler eşleşmiyor.")]
        public string SifreTekrar { get; set; }
        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız.")]
        public int SehirID { get; set; }
        public List<City> Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Doğrulama Kodunu Boş Bırakmayınız.")]
        [CaptchaValidation]
        public string DogrulamaKodu { get; set; }
    }
}
