using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.DataAccessLayer
{
    public class DBInitializer : DropCreateDatabaseAlways<KuryeTakipEntityContainer>
    {
        protected override void Seed(KuryeTakipEntityContainer context)
        {
            try
            {
                Kurye kurye = new Kurye()
                {
                    Isim = "Ahmet Şimşek"
                };

                Restoran restoran = new Restoran()
                {
                    Isim = "ABSDev Cafe"
                };

                Bolge bolge = new Bolge()
                {
                    Isim = "A Bölgesi"
                };

                OdemeYontemi odemeYontemi = new OdemeYontemi()
                {
                    YontemIsim = "Nakit"
                };

                context.KuryeSet.Add(kurye);
                context.RestoranSet.Add(restoran);
                context.BolgeSet.Add(bolge);
                context.OdemeYontemiSet.Add(odemeYontemi);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
