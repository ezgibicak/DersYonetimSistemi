using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersYönetimSistemi.WebUI.MvcHelper
{
    public class AktifKullaniciSessionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User u = SessionManager.AktifKullanici;
            if (u == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {{"controller","Home" },
                    { "action", "LogIn" } });
            }

        }
    }
}