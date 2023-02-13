using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DersYönetimSistemi.WebUI.MvcHelper
{
    public static class SessionManager
    {
        public static User AktifKullanici
        {
            get {

                return HttpContext.Current.Session["AktifKullanici"] as User;
            }
            set
            {

                HttpContext.Current.Session["AktifKullanici"] = value;
            }
        }
    }
}