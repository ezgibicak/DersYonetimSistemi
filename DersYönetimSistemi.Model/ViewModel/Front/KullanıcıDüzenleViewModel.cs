using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Model.ViewModel.Front
{
   public class KullanıcıDüzenleViewModel
    {
      
      
        public int? AktifMi { get; set; }
        public List<Role> Rolleri { get; set; }

    }
}
