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
                    Isim = "Dummy Kurye"
                };

                Restoran restoran = new Restoran()
                {
                    Isim = "Dummy Restoran",
                    Tel = "05514474441"
                };

                Bolge bolge = new Bolge()
                {
                    Isim = "Dummy Bölge"
                };

                OdemeYontemi odemeYontemi = new OdemeYontemi()
                {
                    YontemIsim = "Dummy Ödeme"
                };

                Kullanici kullanici = new Kullanici()
                {
                    Username = "admin",
                    Password = Helpers.PasswordHelper.CreateMD5("Admin1213!")
                };

                context.KuryeSet.Add(kurye);
                context.RestoranSet.Add(restoran);
                context.BolgeSet.Add(bolge);
                context.OdemeYontemiSet.Add(odemeYontemi);
                context.KullaniciSet.Add(kullanici);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
