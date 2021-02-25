using KuryeTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KuryeTakip.Helpers
{
    public class SMSHelper
    {
        public static string SMSGonder(Siparis siparis, string aliciTelNo)
        {
            try
            {
                Ayar smsAyarlari = AyarService.SMSAyarlariGetir();

                if (smsAyarlari != null)
                {
                    string result = "";
                    string userCode = "usercode=" + smsAyarlari.SMSUserCode + "&";
                    string password = "password=" + smsAyarlari.SMSPassword + "&";
                    string gsmno = "gsmno=" + aliciTelNo + "&";
                    string message = "message=" + smsMesajiHazirla(smsAyarlari.SMSMessageTemplate, siparis) + "&";
                    string msgheader = "msgheader=" + smsAyarlari.SMSMessageHeader;

                    string url = @"https://api.netgsm.com.tr/sms/send/get/?" + userCode + password + gsmno + message + msgheader;


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }

                    return smsGonderimCevap(result);
                }
                else
                    return "SMS ayarları yapılı değil, gönderim yapılmadı.";
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static string smsMesajiHazirla(string smsMesajSablon, Siparis siparis)
        {
            try
            {
                StringBuilder builder = new StringBuilder(smsMesajSablon);

                builder.Replace("%siparisno%", siparis.Id.ToString());
                builder.Replace("%restoranisim%", siparis.RestoranIsim);
                builder.Replace("%kuryeisim%", siparis.KuryeIsim);
                builder.Replace("%bolgeisim%", siparis.BolgeIsim);
                builder.Replace("%odemeyontemi%", siparis.OdemeYontem);
                builder.Replace("%tarihsaat%", siparis.Tarih);

                return builder.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static string smsGonderimCevap(string response)
        {
            try
            {
                string[] responseSeperated = response.Split(' ');

                if (responseSeperated.Length > 1)
                {
                    switch (responseSeperated[0])
                    {
                        case "00":
                        case "01":
                        case "02":
                            return "SMS gönderim talebi başarıyla işleme alınmıştır, sistemden kontrol edebilmeniz için sorgu ID\'si: " + responseSeperated[1];
                        case "20":
                            return "Mesaj metni hatalı ya da maksimum karakter sayısını aşmış.";
                        case "30":
                            return "Geçersiz kullanıcı adı veya şifre. Kullanıcı bilgileri doğru ise API izni olup olmadığını kontrol edin.";
                        case "40":
                            return "Mesaj başlığı ya da gönderici adı sistemde tanımlı değil. Bu hatayı alıyorsanız mesaj başlığınızı kullanıcı kodunuz olarak giriniz.";
                        case "70":
                            return "SMS Gönderim isteği parametrelerinde hata.";
                        default:
                            return response;
                    }
                }
                else
                    return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
