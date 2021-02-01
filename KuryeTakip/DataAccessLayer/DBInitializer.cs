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
            Kurye kurye = new Kurye()
            { 
                Isim = "Ahmet Şimşek"
            };

            Restoran restoran = new Restoran()
            {
                Isim = "ABSDev Cafe"
            };

            context.KuryeSet.Add(kurye);
            context.RestoranSet.Add(restoran);
        }
    }
}
