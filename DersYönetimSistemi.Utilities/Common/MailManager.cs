using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DersYönetimSistemi.Utilities.Common
{
   public class MailManager
    {
        private string gonderilecekAdres;

        public MailManager(string GonderilecekAdres)
        {
            this.gonderilecekAdres = GonderilecekAdres;
        }

        public bool SendMail(string Mesaj, string baslik)
        {
            try
            {
                MailMessage msg = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["KullaniciAdi"], "Ders Yönetim Sistemi"), new MailAddress(this.gonderilecekAdres));

                msg.Subject = baslik;
                msg.Body = Mesaj;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                NetworkCredential cr = new NetworkCredential(ConfigurationManager.AppSettings["KullaniciAdi"], ConfigurationManager.AppSettings["Sifre"]);
                client.Credentials = cr;

                client.EnableSsl = true;
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
