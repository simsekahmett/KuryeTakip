using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Models
{
    public class Siparis
    {
        public int UrunId { get; set; }
        public Restoran Restoran { get; set; }
        public Kurye Kurye { get; set; }
        public SiparisDurumu Durum { get; set; }
        
    }

    public enum SiparisDurumu { Aliniyor, Yolda, Tamamlandi }
}
