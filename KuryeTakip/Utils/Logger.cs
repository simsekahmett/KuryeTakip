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

            enAltaScroll(this.form.logTextBox);
            enAltaScroll(this.form.kayitLogTextBox);
        }

        public void HataLogEkle(string log)
        {
            string formattedLog = hataLogFormatla(log) + Environment.NewLine;
            this.form.logTextBox.Text += formattedLog;
            this.form.kayitLogTextBox.Text += formattedLog;

            enAltaScroll(this.form.logTextBox);
            enAltaScroll(this.form.kayitLogTextBox);
        }

        public void RaporLogEkle(string log)
        {
            string formattedLog = logFormatla(log) + Environment.NewLine;
            this.form.logTextBox.Text += formattedLog;
            this.form.raporlamaLogTextBox.Text += formattedLog;

            enAltaScroll(this.form.logTextBox);
            enAltaScroll(this.form.raporlamaLogTextBox);
        }

        public void RaporHataLogEkle(string log)
        {
            string formattedLog = hataLogFormatla(log) + Environment.NewLine;
            this.form.logTextBox.Text += formattedLog;
            this.form.raporlamaLogTextBox.Text += formattedLog;

            enAltaScroll(this.form.logTextBox);
            enAltaScroll(this.form.raporlamaLogTextBox);
        }

        public void SiparisTamamlandiLogEkle(DataAccessLayer.Siparis siparis)
        {
            string mesaj = "### Sipariş Tamamlandı ###";
            mesaj += " Sipariş Num: " + siparis.Id;
            mesaj += " Sipariş Tarih: " + siparis.Tarih;
            mesaj += " Restoran: " + siparis.RestoranIsim;
            mesaj += " Kurye: " + siparis.KuryeIsim;
            mesaj += " Bölge: " + siparis.BolgeIsim;
            mesaj += " Ödeme Yöntemi: " + siparis.OdemeYontem;
            mesaj += " Ürün Hazırlanma Süresi: " + siparis.HazirlanmaSuresi;
            mesaj += " Ürün Teslimat Süresi: " + siparis.TeslimatSuresi;

            string formattedLog = logFormatla(mesaj) + Environment.NewLine;
            this.form.logTextBox.Text += formattedLog;
            this.form.kayitLogTextBox.Text += formattedLog;
        }

        public string logFormatla(string log)
        {
            string tarihSaat = "[" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            return tarihSaat + "] ---- " + log;
        }

        public string hataLogFormatla(string log)
        {
            return  "[**HATA**] ---- " + log;
        }

        private void enAltaScroll(RichTextBox richTextBox)
        {
            richTextBox.SelectionStart = richTextBox.Text.Length;
            richTextBox.ScrollToCaret();
        }
    }
}
