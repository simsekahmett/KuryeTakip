using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.DataAccessLayer
{
    public static class KullaniciService
    {
        public static bool AdminParolaDegistir(string parola)
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    Kullanici user = context.KullaniciSet.FirstOrDefault();
                    user.Password = parola;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Kullanici AdminKullaniciGetir()
        {
            try
            {
                using (var context = new KuryeTakipEntityContainer())
                {
                    return context.KullaniciSet.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
