using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.ViewModel.Areas.Yönetim.User.LogIn
{
    public class ProfilBilgileriViewModel
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string TelNo { get; set; }
    }
}
