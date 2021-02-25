using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.DataAccessLayer
{
    public static class AyarService
    {

        public static bool SMSAyarlariKaydet(Ayar ayar)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    context.AyarSet.Add(ayar);

                    context.SaveChanges();
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Ayar SMSAyarlariGetir()
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    return context.AyarSet.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
