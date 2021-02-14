using System;
using System.Collections.Generic;
using System.Linq;

namespace KuryeTakip.DataAccessLayer
{
    public static class BolgeService
    {
        public static bool BolgeKaydet(Bolge bolge)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var kayit = new Bolge()
                    {
                        Isim = bolge.Isim
                    };

                    context.BolgeSet.Add(kayit);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool BolgeSil(Bolge bolge)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    var silinecekBolge = context.BolgeSet.SingleOrDefault(b => b.Id == bolge.Id);

                    if (silinecekBolge != null)
                        context.BolgeSet.Remove(silinecekBolge);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Bolge> BolgeleriGetir()
        {
            List<Bolge> kayitliBolgeler = new List<Bolge>();

            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    kayitliBolgeler = context.BolgeSet.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return kayitliBolgeler;
        }
    }
}
