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
        public static void DGVSatirlariOlustur(DataGridView dgv, List<Siparis> siparisler, BindingSource restoranlar, BindingSource kuryeler, BindingSource bolgeler, int count, int lastRowId = 0)
        {
            for (int i = 0; i < count; i++)
            {
                DataGridViewRow satir = new DataGridViewRow();
                DataGridViewTextBoxCell siparisNum = new DataGridViewTextBoxCell();
                DataGridViewComboBoxCell restoranSecme = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell kuryeSecme = new DataGridViewComboBoxCell();
                DataGridViewTextBoxCell siparisDurum = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell urunAlinmaSuresi = new DataGridViewTextBoxCell();
                DataGridViewCheckBoxCell urunTeslimAlindi = new DataGridViewCheckBoxCell();
                DataGridViewComboBoxCell bolgeSecme = new DataGridViewComboBoxCell();
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

                if (siparisler.Count > 0)
                {
                    siparisNum.Value = siparisler.LastOrDefault().Id + (i + 1);
                }
                else
                    siparisNum.Value = i + 1;

                if (lastRowId > 0)
                {
                    siparisNum.Value = lastRowId + 1;
                }

                satir.Cells.Add(siparisNum);
                satir.Cells.Add(restoranSecme);
                satir.Cells.Add(kuryeSecme);
                satir.Cells.Add(siparisDurum);
                satir.Cells.Add(urunAlinmaSuresi);
                satir.Cells.Add(urunTeslimAlindi);
                satir.Cells.Add(bolgeSecme);
                satir.Cells.Add(urunDagitimSuresi);
                satir.Cells.Add(urunTeslimEdildi);
                
                dgv.Rows.Add(satir);
            }
        }
    }
}
