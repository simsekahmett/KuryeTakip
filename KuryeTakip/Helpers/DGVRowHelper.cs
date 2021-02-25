using KuryeTakip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip.Helpers
{
    public static class DGVRowHelper
    {
        public static void DGVSatirlariOlustur(DataGridView dgv, BindingSource restoranlar, BindingSource kuryeler, BindingSource bolgeler, BindingSource odemeYontemleri, int count)
        {
           try
            {
                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow satir = new DataGridViewRow();
                    DataGridViewComboBoxCell restoranSecme = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell bolgeSecme = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell odemeYontemiSecme = new DataGridViewComboBoxCell();
                    DataGridViewTextBoxCell siparisDurum = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell urunAlinmaSuresi = new DataGridViewTextBoxCell();
                    DataGridViewComboBoxCell kuryeSecme = new DataGridViewComboBoxCell();
                    DataGridViewCheckBoxCell urunTeslimAlindi = new DataGridViewCheckBoxCell();
                    DataGridViewTextBoxCell urunDagitimSuresi = new DataGridViewTextBoxCell();
                    DataGridViewCheckBoxCell urunTeslimEdildi = new DataGridViewCheckBoxCell();

                    restoranSecme.DataSource = restoranlar;
                    restoranSecme.DisplayMember = "Isim";
                    restoranSecme.ValueMember = "Id";

                    kuryeSecme.DataSource = kuryeler;
                    kuryeSecme.DisplayMember = "Isim";
                    kuryeSecme.ValueMember = "Id";

                    bolgeSecme.DataSource = bolgeler;
                    bolgeSecme.DisplayMember = "Isim";
                    bolgeSecme.ValueMember = "Id";

                    odemeYontemiSecme.DataSource = odemeYontemleri;
                    odemeYontemiSecme.DisplayMember = "YontemIsim";
                    odemeYontemiSecme.ValueMember = "Id";

                    //eklenecek satırın sütunları sıralı olarak eklenmeli
                    satir.Cells.Add(restoranSecme);
                    satir.Cells.Add(bolgeSecme);
                    satir.Cells.Add(odemeYontemiSecme);
                    satir.Cells.Add(siparisDurum);
                    satir.Cells.Add(urunAlinmaSuresi);
                    satir.Cells.Add(kuryeSecme);
                    satir.Cells.Add(urunTeslimAlindi);
                    satir.Cells.Add(urunDagitimSuresi);
                    satir.Cells.Add(urunTeslimEdildi);

                    dgv.Rows.Add(satir);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
