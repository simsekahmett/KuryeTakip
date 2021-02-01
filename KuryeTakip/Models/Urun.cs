using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Models
{
    public class Urun
    {
        public Restoran Restoran { get; set; }
        public Kurye Kurye { get; set; }
        public SiparisDurumu Durum { get; set; }
        
    }

    public enum SiparisDurumu { Aliniyor, Yolda, Tamamlandi }
}
