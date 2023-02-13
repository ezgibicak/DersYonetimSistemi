using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DersYönetimSistemi.Utilities.MVC
{
   public class CaptchaValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string kod = HttpContext.Current.Session["DogrulamaKodu"].ToString();
            string girilenkod = value.ToString();
            if (girilenkod != kod)
            {
                return new ValidationResult("Doğrulama Kodunu Yanlış Girdiniz.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
