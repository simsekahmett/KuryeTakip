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

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool KuryeSil(Kurye kurye)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Kurye> KuryeleriGetir()
        {
            List<Kurye> kayitliKuryeler = new List<Kurye>();

            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    kayitliKuryeler = context.KuryeSet.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return kayitliKuryeler;
        }
    }
}
