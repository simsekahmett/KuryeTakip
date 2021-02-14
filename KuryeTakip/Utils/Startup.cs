using KuryeTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Utils
{
    public static class Startup
    {
        public static bool DBKur()
        {
            try
            {
                using(var context = new KuryeTakipEntityContainer())
                {
                    if(!context.Database.Exists())
                    {
                        DBInitializer initializer = new DBInitializer();
                        initializer.InitializeDatabase(context);
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
