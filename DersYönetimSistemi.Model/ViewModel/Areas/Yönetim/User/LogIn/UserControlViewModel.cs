using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.ViewModel.Areas.Yönetim.User.LogIn
{
   public class UserControlViewModel
    {
        public int KullanıcıID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public int? SehirID { get; set; }
        public string SehirAdi { get; set; }
        public int? AktifMi { get; set; }
    }
}
