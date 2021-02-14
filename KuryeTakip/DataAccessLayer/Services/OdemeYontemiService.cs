using System;
using System.Collections.Generic;
using System.Linq;

namespace KuryeTakip.DataAccessLayer
{
    public static class OdemeYontemiService
    {
        public static bool OdemeYontemiKaydet(OdemeYontemi odemeYontemi)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var kayit = new OdemeYontemi()
                    {
                        YontemIsim = odemeYontemi.YontemIsim
                    };

                    context.OdemeYontemiSet.Add(kayit);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool OdemeYontemiSil(OdemeYontemi odemeYontemi)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var silinecekOdemeYontemi = context.OdemeYontemiSet.SingleOrDefault(y => y.Id == odemeYontemi.Id);

                    if (silinecekOdemeYontemi != null)
                        context.OdemeYontemiSet.Remove(silinecekOdemeYontemi);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OdemeYontemi> OdemeYontemleriGetir()
        {
            List<OdemeYontemi> kayitliOdemeYontemleri = new List<OdemeYontemi>();

            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    kayitliOdemeYontemleri = context.OdemeYontemiSet.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return kayitliOdemeYontemleri;
        }
    }
}
