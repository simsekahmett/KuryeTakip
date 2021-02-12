using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip.Utils
{
    public class Logger : Form1
    {
        private Form1 form;

        public Logger(Form1 _form)
        {
            form = _form;
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        public void LogEkle(string log)
        {
            string formattedLog = logFormatla(log) + Environment.NewLine;
            this.form.logTextBox.Text += formattedLog;
            this.form.kayitLogTextBox.Text += formattedLog;
        }

        public string logFormatla(string log)
        {
            string tarihSaat = "[" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            return tarihSaat + "] ---- " + log;
        }
    }
}
