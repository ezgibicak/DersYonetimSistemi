using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Utilities.Common
{
    public class CapthcaGen
    {

        private int karakterSayisi;
        private string fonttipi;
        private float fontbuyuklugu;


        private string olusturulanstring;

        public string Olusturulanstring
        {
            get
            {
                return olusturulanstring;
            }
        }

        public CapthcaGen(int KarakterSayisi, string FontTipi, float FontBuyuklugu)
        {
            this.karakterSayisi = KarakterSayisi;
            this.fontbuyuklugu = FontBuyuklugu;
            this.fonttipi = FontTipi;
        }

        private char KarakterUret()
        {
            // 65-90 arası büyük harfler
            // 97-122 arası küçük harfler
            Random rnd = new Random();
            char karakter = ' ';
            bool kontrol = false;
            while (!kontrol)
            {
                int sayi = rnd.Next(65, 122);
                if (!(sayi > 90 && sayi < 97))
                {
                    karakter = (char)sayi;
                    kontrol = true;
                }
            }

            return karakter;
        }

        private string KarakterDizisiOlustur()
        {

            string karakterdizisi = "";
            for (int i = 0; i < karakterSayisi; i++)
            {
                karakterdizisi += KarakterUret();
                Thread.Sleep(50);

            }
            return karakterdizisi;
        }

        public Bitmap GuvenlikResmiUret()
        {
            Bitmap b = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(b);

            this.olusturulanstring = KarakterDizisiOlustur();


            Bitmap resim = new Bitmap(

             (int)(g.MeasureString(this.olusturulanstring, new Font(this.fonttipi, fontbuyuklugu)).Width),

             (int)(g.MeasureString(this.olusturulanstring, new Font(this.fonttipi, fontbuyuklugu)).Height)

             );

            Graphics graph = Graphics.FromImage(resim);

            graph.DrawLine(new Pen(Brushes.Red), 0, 0, 60, 60);

            HatchBrush firca = new HatchBrush(HatchStyle.ZigZag, Color.Yellow);
            graph.DrawString(this.olusturulanstring, new Font(this.fonttipi, fontbuyuklugu), firca, 0, 0);
            return resim;
        }
    }
}
