using DersYönetimSistemi.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersYönetimSistemi.WebUI.MvcHelper
{
    public class CapthcaImageResult:ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            CapthcaGen gen = new CapthcaGen(6,"Verdana",12);
            Bitmap b=gen.GuvenlikResmiUret();
            HttpContext.Current.Session["DogrulamaKodu"] = gen.Olusturulanstring;
            b.Save(response.OutputStream, ImageFormat.Png);
            b.Dispose();
        }
    }
}