using DersYönetimSistemi.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersYönetimSistemi.WebUI.MvcHelper
{
    public class RoleFilter : FilterAttribute, IActionFilter
    {
        string[] allowesRoles;
        public RoleFilter(params string[] AllowedRole)
        {
            allowesRoles = AllowedRole;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<Role> kulaniciRolleri = SessionManager.AktifKullanici.Rolleri;
            bool allowed = false;
            foreach (Role role in kulaniciRolleri)
            {
                foreach (string allowRole in allowesRoles)
                {
                    if (role.RolAdi == allowRole)
                    {
                        allowed = true;
                        break;

                    }
                  
                }
            }

           if(!allowed)
                    {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {{"controller","Home" },
                    { "action", "NotAllowed" } });
            }
        }
    }
}