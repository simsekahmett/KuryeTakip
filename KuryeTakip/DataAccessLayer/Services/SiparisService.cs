using System;
using System.Collections.Generic;
using System.Linq;

namespace KuryeTakip.DataAccessLayer
{
    public static class SiparisService
    {
        public static bool SiparisKaydet(Siparis siparis)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    context.SiparisSet.Add(siparis);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            return true;
        }

        public static List<Siparis> SiparisleriGetir()
        {
            List<Siparis> kayitliSiparisler = new List<Siparis>();

            using (var context = new KuryeTakipEntityContainer())
            {
                kayitliSiparisler = context.SiparisSet.ToList();
            }

            return kayitliSiparisler;
        }
    }
}
