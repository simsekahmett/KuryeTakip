using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Models
{
    public class SiparisDurumu
    {
        public string Durum { get; set; }
        private SiparisDurumu(string durum)
        {
            Durum = durum;
        }

        public static SiparisDurumu Aliniyor
        {
            get
            {
                return new SiparisDurumu("Alınıyor");
            }
        }

        public static SiparisDurumu Yolda
        {
            get
            {
                return new SiparisDurumu("Yolda");
            }
        }

        public static SiparisDurumu Tamamlandi
        {
            get
            {
                return new SiparisDurumu("Tamamlandı");
            }
        }
    }
}
