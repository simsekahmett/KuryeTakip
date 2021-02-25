using System;
using System.Collections.Generic;
using System.Linq;

namespace KuryeTakip.DataAccessLayer
{
    public static class RestoranService
    {
        public static bool RestoranKaydet(Restoran restoran)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var kayit = new Restoran()
                    {
                        Isim = restoran.Isim,
                        Tel = restoran.Tel
                    };

                    context.RestoranSet.Add(kayit);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool RestoranSil(Restoran restoran)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var silinecekRestoran = context.RestoranSet.SingleOrDefault(r => r.Id == restoran.Id);

                    if (silinecekRestoran != null)
                        context.RestoranSet.Remove(silinecekRestoran);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Restoran> RestoranlariGetir()
        {
            List<Restoran> kayitliRestoranlar = new List<Restoran>();

            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    kayitliRestoranlar = context.RestoranSet.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return kayitliRestoranlar;
        }
    }
}
