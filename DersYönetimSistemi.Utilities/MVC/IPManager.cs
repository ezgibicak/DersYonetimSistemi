using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DersYönetimSistemi.Utilities.MVC
{
    public class IPManager
    {

        public static string GetClientIPAddress()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
