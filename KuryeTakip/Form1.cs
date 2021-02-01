using KuryeTakip.DataAccessLayer;
using KuryeTakip.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip
{
    public partial class Form1 : Form
    {

        Logger logger;
        public Form1()
        {
            InitializeComponent();
        }

        //seçili row
        DataGridViewRow seciliRow = null;

        //data source'lar
        BindingSource kuryelerDataSource = new BindingSource();
        BindingSource restoranlarDataSource = new BindingSource();


        //kurye takip tab, sağ click event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                seciliRow = row;
                dataGrid.Focus();
                kuryeTakipMenu.Show(Cursor.Position);
            }
        }

        private void menuItemCikar_Click(object sender, EventArgs e)
        {
            if (seciliRow != null)
                dataGridView1.Rows.Remove(seciliRow);
        }

        private void menuItemEkle_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new DataGridViewRow());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo: check if no db
            //Utils.Startup.DBKur();
            logger = new Logger(this);
            logger.LogEkle("KuryeTakip programı başlatıldı");
            
            //veritabanından restoran ve kurye bilgileri getiriliyor
            kuryeleriGetir();
            restoranlariGetir();
            
            bosSiparisSatirlariEkle();


        }

        private void kuryeKayitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kuryeKayitIsimTextBox.Text))
            {
                KuryeService.KuryeKaydet(new Kurye()
                {
                    Isim = kuryeKayitIsimTextBox.Text
                });
            }
        }

        private void kuryeleriGetirButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("KuryeGetir butonu tıklandı");

            kuryeleriGetir();

            kuryelerComboBox.DataSource = kuryelerDataSource;
            kuryelerComboBox.DisplayMember = "Isim";
            kuryelerComboBox.ValueMember = "Id";
        }

        private void kuryeSilButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("KuryeSil butonu tıklandı");

            if (!string.IsNullOrEmpty(kuryelerComboBox.Text))
            {
                KuryeService.KuryeSil((Kurye)kuryelerComboBox.SelectedItem);
            }

            kuryeleriGetir();
        }

        private void restoranKaydetButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(restoranKayitIsimTextBox.Text))
            {
                RestoranService.RestoranKaydet(new Restoran()
                {
                    Isim = restoranKayitIsimTextBox.Text
                });
            }
        }

        private void restoranlariGetirButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("RestoranGetir butonu tıklandı");

            restoranlariGetir();

            restoranlarComboBox.DataSource = restoranlarDataSource;
            restoranlarComboBox.DisplayMember = "Isim";
            restoranlarComboBox.ValueMember = "Id";
        }

        private void restoranSilButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("RestoranSil butonu tıklandı");

            if (!string.IsNullOrEmpty(restoranlarComboBox.Text))
            {
                RestoranService.RestoranSil((Restoran)restoranlarComboBox.SelectedItem);
            }

            restoranlariGetir();
        }

        private void kuryeleriGetir()
        {
            logger.LogEkle("Kurye bilgileri veritabanından getiriliyor");

            List<Kurye> kuryeler = KuryeService.KuryeleriGetir();

            kuryelerDataSource.DataSource = kuryeler;

            logger.LogEkle("Kurye bilgileri getirildi");
        }

        private void restoranlariGetir()
        {
            logger.LogEkle("Restoran bilgileri veritabanından getiriliyor");

            List<Restoran> restoranlar = RestoranService.RestoranlariGetir();

            restoranlarDataSource.DataSource = restoranlar;

            logger.LogEkle("Restoran bilgileri getirildi");
        }

        private void bosSiparisSatirlariEkle()
        {
            dataGridView1.Rows.Add(5);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(restoranlarDataSource.Count > 0)
            {
                DataGridViewComboBoxColumn restoranlarColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
                restoranlarColumn.DataSource = restoranlarDataSource;
                restoranlarColumn.DisplayMember = "Isim";
                restoranlarColumn.ValueMember = "Id";
            }

            if(kuryelerDataSource.Count > 0)
            {
                DataGridViewComboBoxColumn kuryelerColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
                kuryelerColumn.DataSource = kuryelerDataSource;
                kuryelerColumn.DisplayMember = "Isim";
                kuryelerColumn.ValueMember = "Id";
            }
        }
    }
}
