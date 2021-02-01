using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Utils
{
    public class Logger : Form1
    {
        Form1 form;
        public Logger(Form1 _form)
        {
            form = _form;
        }

        public void LogEkle(string log)
        {
            this.form.logTextBox.Text += logFormatla(log);
            this.form.logTextBox.Text += Environment.NewLine;
        }

        public string logFormatla(string log)
        {
            string tarihSaat = "[" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            return tarihSaat + "] ---- " + log; 
        }
    }
}
