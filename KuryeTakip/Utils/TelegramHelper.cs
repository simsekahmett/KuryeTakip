using KuryeTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Utils
{
    public static class TelegramHelper
    {
        private static string token = "1625055352:AAGijivzUWt4nk7xT8Oi51NhqdVI_7BqiZU";
        //private static string destID = "243737864";

        public static async Task SiparisMesajiGonder(Siparis siparis, string destID)
        {
            try
            {
                string mesaj = TamamlananSiparisMesajiHazirla(siparis);
                
                var bot = new Telegram.Bot.TelegramBotClient(token);
                await bot.SendTextMessageAsync(destID, mesaj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string TamamlananSiparisMesajiHazirla(Siparis siparis)
        {
            string mesaj = "### Sipariş Tamamlandı ###";
            mesaj += Environment.NewLine;
            mesaj += "Sipariş Num: " + siparis.Id;
            mesaj += Environment.NewLine;
            mesaj += "Sipariş Tarih: " + siparis.Tarih;
            mesaj += Environment.NewLine;
            mesaj += "Restoran: " + siparis.RestoranIsim;
            mesaj += Environment.NewLine;
            mesaj += "Kurye: " + siparis.KuryeIsim;
            mesaj += Environment.NewLine;
            mesaj += "Bölge: " + siparis.BolgeIsim;
            mesaj += Environment.NewLine;
            mesaj += "Ödeme Yöntemi: " + siparis.OdemeYontem;
            mesaj += Environment.NewLine;
            mesaj += "Ürün Hazırlanma Süresi: " + siparis.HazirlanmaSuresi;
            mesaj += Environment.NewLine;
            mesaj += "Ürün Teslimat Süresi: " + siparis.TeslimatSuresi;

            return mesaj;
        }
    }
}
