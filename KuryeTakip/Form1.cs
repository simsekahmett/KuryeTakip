using KuryeTakip.DataAccessLayer;
using KuryeTakip.Helpers;
using KuryeTakip.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        BindingSource bolgelerDataSource = new BindingSource();

        //timerlar
        private Dictionary<DataGridViewRow, Stopwatch> urunTimerlar = new Dictionary<DataGridViewRow, Stopwatch>();
        private Dictionary<DataGridViewRow, Stopwatch> teslimatTimerlar = new Dictionary<DataGridViewRow, Stopwatch>();

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
            int lastRowId = (int)dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value;
            DGVRowHelper.DGVSatirlariOlustur(dataGridView1, siparisleriGetir(), restoranlarDataSource, kuryelerDataSource, bolgelerDataSource, 1, lastRowId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo: check if no db
            //Startup.DBKur();
            logger = new Logger(this);
            logger.LogEkle("KuryeTakip programı başlatıldı");

            //veritabanından restoran ve kurye bilgileri getiriliyor
            kuryeleriGetir();
            restoranlariGetir();
            bolgeleriGetir();

            var teslimatTimer = new System.Timers.Timer();
            teslimatTimer.Interval = 1000;
            teslimatTimer.Elapsed += new ElapsedEventHandler(TeslimatTimer_Tick);
            teslimatTimer.Enabled = true;

            var urunTimer = new System.Timers.Timer();
            teslimatTimer.Interval = 1000;
            teslimatTimer.Elapsed += new ElapsedEventHandler(UrunTimer_Tick);
            teslimatTimer.Enabled = true;

            DGVRowHelper.DGVSatirlariOlustur(dataGridView1, siparisleriGetir(), restoranlarDataSource, kuryelerDataSource, bolgelerDataSource, 5);

            //bosSiparisSatirlariEkle();


        }

        private void kuryeKayitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kuryeKayitIsimTextBox.Text))
            {
                KuryeService.KuryeKaydet(new Kurye()
                {
                    Isim = kuryeKayitIsimTextBox.Text
                });

                logger.LogEkle(kuryeKayitIsimTextBox.Text + " kurye eklendi");
            }
            else
                logger.LogEkle("Kurye ismi girilmediği için kayıt yapılamadı");
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

                logger.LogEkle(restoranKayitIsimTextBox.Text + " restoran eklendi");
            }
            else
                logger.LogEkle("Restoran ismi girilmediği için kayıt yapılamadı");
        }

        private void restoranlariGetirButton_Click(object sender, EventArgs e)
        {

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

        private void bolgeKaydetButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bolgeKayitIsimTextBox.Text))
            {
                BolgeService.BolgeKaydet(new Bolge()
                {
                    Isim = bolgeKayitIsimTextBox.Text
                });

                logger.LogEkle(bolgeKayitIsimTextBox.Text + " bölge eklendi");
            }
            else
                logger.LogEkle("Bölge ismi girilmediği için kayıt yapılamadı");

        }

        private void bolgeleriGetirButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("BölgeleriGetir butonu tıklandı");

            bolgeleriGetir();

            bolgelerComboBox.DataSource = bolgelerDataSource;
            bolgelerComboBox.DisplayMember = "Isim";
            bolgelerComboBox.ValueMember = "Id";
        }

        private void bolgeSilButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("BölgeSil butonu tıklandı");

            if (!string.IsNullOrEmpty(bolgelerComboBox.Text))
            {
                BolgeService.BolgeSil((Bolge)bolgelerComboBox.SelectedItem);

                logger.LogEkle(bolgelerComboBox.Text + " bölgesi silindi");
            }

            bolgeleriGetir();
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

        private List<Siparis> siparisleriGetir()
        {
            logger.LogEkle("Siparis bilgileri veritabanından getiriliyor");

            List<Siparis> siparisler = SiparisService.SiparisleriGetir();

            logger.LogEkle("Restoran bilgileri getirildi");

            return siparisler;
        }

        private void bolgeleriGetir()
        {
            logger.LogEkle("Bölge bilgileri veritabanından getiriliyor");

            List<Bolge> bolgeler = BolgeService.BolgeleriGetir();

            bolgelerDataSource.DataSource = bolgeler;

            logger.LogEkle("Bölge bilgileri getirildi");
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (restoranlarDataSource.Count > 0)
            //{
            //    DataGridViewComboBoxColumn restoranlarColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
            //    restoranlarColumn.DataSource = restoranlarDataSource;
            //    restoranlarColumn.DisplayMember = "Isim";
            //    restoranlarColumn.ValueMember = "Id";
            //}

            //if (kuryelerDataSource.Count > 0)
            //{
            //    DataGridViewComboBoxColumn kuryelerColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
            //    kuryelerColumn.DataSource = kuryelerDataSource;
            //    kuryelerColumn.DisplayMember = "Isim";
            //    kuryelerColumn.ValueMember = "Id";
            //}

            //urun timer
            //var urunTimer = new KuryeTakipTimer();
            //urunTimer.Interval = 1000;
            //urunTimer.Elapsed += new ElapsedEventHandler(UrunTimer_Tick);
            //urunTimer.Enabled = false;

            Stopwatch urunStopwatch = new Stopwatch();
            urunTimerlar.Add(dataGridView1.Rows[e.RowIndex], urunStopwatch);

            Stopwatch teslimatStopWatch = new Stopwatch();
            teslimatTimerlar.Add(dataGridView1.Rows[e.RowIndex], teslimatStopWatch);
        }

        private void UrunTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach (var timer in urunTimerlar)
                {
                    if (timer.Value.IsRunning)
                    {
                        timer.Key.Cells[4].Value = timer.Value.Elapsed.ToString("mm\\:ss");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogEkle("**HATA**: " + ex.Message);
            }
        }
        private void TeslimatTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach (var timer in teslimatTimerlar)
                {
                    if (timer.Value.IsRunning)
                    {
                        timer.Key.Cells[7].Value = timer.Value.Elapsed.ToString("mm\\:ss");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogEkle("**HATA**: " + ex.Message);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                var row = dataGrid.Rows[e.RowIndex];
                seciliRow = row;

                dataGrid.EndEdit();

                if (e.RowIndex != -1)
                {
                    var teslimatStopwatch = teslimatTimerlar[dataGrid.Rows[e.RowIndex]];

                    //urun teslim alındı checkbox
                    if (e.ColumnIndex == 5)
                    {
                        if ((bool)row.Cells[5].Value)
                        {

                            //var urunStopwatch = urunTimerlar[dataGrid.Rows[e.RowIndex]];
                            //urunStopwatch.Stop();

                            //teslimatStopwatch.Start();
                        }
                    }
                    //urun teslim edildi checkbox
                    else if (e.ColumnIndex == 8)
                    {
                        if ((bool)row.Cells[8].Value)
                        {
                            var teslimStopwatch = teslimatTimerlar[dataGrid.Rows[e.RowIndex]];
                            teslimStopwatch.Stop();

                            dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Tamamlandi.Durum;

                            var kuryelerList = kuryelerDataSource.List.OfType<Kurye>();
                            Kurye kurye = kuryelerList.Where(k => k.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[2].Value).FirstOrDefault();

                            var restoranlarList = restoranlarDataSource.List.OfType<Restoran>();
                            Restoran restoran = restoranlarList.Where(k => k.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[6].Value).FirstOrDefault();

                            Siparis tamamlananSiparis = new Siparis()
                            {
                                Kurye = kurye,
                                Restoran = restoran,
                                HazirlanmaSuresi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                                TeslimatSuresi = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()
                            };

                            SiparisService.SiparisKaydet(tamamlananSiparis);


                        }
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var urunStopwatch = urunTimerlar[dataGridView1.Rows[e.RowIndex]];
                var teslimStopWatch = teslimatTimerlar[dataGridView1.Rows[e.RowIndex]];

                //kurye seçildi
                if (e.ColumnIndex == 2 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    urunStopwatch.Start();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Aliniyor.Durum;
                }

                //bölge seçildi
                if (e.ColumnIndex == 6 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    urunStopwatch.Stop();
                    teslimStopWatch.Start();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Yolda.Durum;
                }
            }
        }
    }
}
