using System;
using System.Collections.Generic;
using System.Linq;

namespace KuryeTakip.DataAccessLayer
{
    public static class KuryeService
    {
        public static bool KuryeKaydet(Kurye kurye)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var kayit = new Kurye()
                    {
                        Isim = kurye.Isim
                    };

                    context.KuryeSet.Add(kayit);

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }

            return true;
        }

        public static bool KuryeSil(Kurye kurye)
        {
            using (var context = new KuryeTakipEntityContainer())
            {
                var silinecekKurye = context.KuryeSet.SingleOrDefault(k => k.Id == kurye.Id);

                if (silinecekKurye != null)
                    context.KuryeSet.Remove(silinecekKurye);

                context.SaveChanges();
            }

            return true;
        }

        public static List<Kurye> KuryeleriGetir()
        {
            List<Kurye> kayitliKuryeler = new List<Kurye>();

            using (var context = new KuryeTakipEntityContainer())
            {
                kayitliKuryeler = context.KuryeSet.ToList();
            }

            return kayitliKuryeler;
        }
    }
}
