using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                string message = "**** HATA ****" + Environment.NewLine;
                message += "Kurtarılamayan bir hata meydana geldi, program kapatılıyor." + Environment.NewLine;
                message += "Hata: " + Environment.NewLine + ex.Message;
                MessageBox.Show(message, "KURTARILAMAYAN HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
