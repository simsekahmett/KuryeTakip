using KuryeTakip.DataAccessLayer;
using KuryeTakip.Helpers;
using KuryeTakip.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace KuryeTakip
{
    public partial class Form1 : Form
    {
        #region GLOBAL PROPERTYLER
        //log işlerini yapan obje
        Logger logger;

        //seçili row
        DataGridViewRow seciliRow = null;

        //data source'lar
        BindingSource kuryelerDataSource = new BindingSource();
        BindingSource restoranlarDataSource = new BindingSource();
        BindingSource bolgelerDataSource = new BindingSource();
        BindingSource odemeYontemiDataSource = new BindingSource();

        //timerlar (stopwatch)
        private Dictionary<DataGridViewRow, Stopwatch> urunTimerlar = new Dictionary<DataGridViewRow, Stopwatch>();
        private Dictionary<DataGridViewRow, Stopwatch> teslimatTimerlar = new Dictionary<DataGridViewRow, Stopwatch>();

        //bilgilendirme labellarındaki değerler
        public int aktifUrunTimerSayisi = 0;
        public int aktifTeslimatTimerSayisi = 0;
        public int kayitliSiparislerSayisi = 0;
        public int oturumdaTamamlananSiparisSayisi = 0;
        public string dagitimdakiKuryeler = "";
        #endregion

        #region FORM1 CONSTRUCTOR & LOAD & PAINT & RESIZE HANDLERS
        public Form1()
        {
            InitializeComponent();

            //form flickering önleme
            this.DoubleBuffered = true;

            //anlık bilgi kısmı  labellar
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label21.Text = "";

            //kurye isimlerinin labellarına word-wrap özelliği
            label21.MaximumSize = new Size(350, 0);
            label21.AutoSize = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger = new Logger(this);
            logger.LogEkle("KuryeTakip programı başlatıldı");

            bool dbVar = false;

            //database var mı yok mu kontrol
            try
            {
                logger.LogEkle("Database var mı yok mu kontrol ediliyor");

                dbVar = Startup.DBVarMi();

                if (dbVar)
                    logger.LogEkle("Database bulundu");
                else
                    logger.LogEkle("Database bulunamadı");


            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Database var mı yok mu kontrolü yapılamadı: " + ex);
            }

            //database yoksa kur
            try
            {
                if (!dbVar)
                {
                    logger.LogEkle("Database kurulumu yapılıyor");

                    Startup.DBKur();
                    dbVar = true;

                    logger.LogEkle("Database kurulumu yapıldı");
                }
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Database kurulumu yapılamadı: " + ex.ToString());
            }

            //veritabanından kurye, restoran, bölgeler ve ödeme yöntemleri bilgileri getiriliyor
            try
            {
                if (dbVar)
                {
                    kuryeleriGetir();
                    restoranlariGetir();
                    bolgeleriGetir();
                    odemeYontemleriGetir();
                }
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Database veri çekim işlemi yapılamadı: " + ex.ToString());
            }

            //ürün teslimat stopwatch'larının ekranda değerini gösterecek timer
            var teslimatTimer = new System.Timers.Timer();
            teslimatTimer.Interval = 1000;
            teslimatTimer.Elapsed += new ElapsedEventHandler(TeslimatTimer_Tick);
            teslimatTimer.Enabled = true;

            //ürün hazırlanma stopwatch'larının ekranda değerini gösterecek timer
            var urunTimer = new System.Timers.Timer();
            teslimatTimer.Interval = 1000;
            teslimatTimer.Elapsed += new ElapsedEventHandler(UrunTimer_Tick);
            teslimatTimer.Enabled = true;

            //bilgilendirme ekranı label yenileme timer
            var bilgilendirmeLabellarTimer = new System.Timers.Timer();
            teslimatTimer.Interval = 1000;
            teslimatTimer.Elapsed += new ElapsedEventHandler(BilgilendirmeLabellarTimer_Tick);
            teslimatTimer.Enabled = true;

            List<Siparis> tumKayitliSiparisler = siparisleriGetir();
            kayitliSiparislerSayisi = tumKayitliSiparisler.Count();

            //form açılışında datagridview'a boş sipariş satırları oluşturuyor
            DGVRowHelper.DGVSatirlariOlustur(dataGridView1, restoranlarDataSource, kuryelerDataSource, bolgelerDataSource, odemeYontemiDataSource, 5);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        #region DATAGRIDVIEW FONKSİYONLARI
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Stopwatch urunStopwatch = new Stopwatch();
            urunTimerlar.Add(dataGridView1.Rows[e.RowIndex], urunStopwatch);

            Stopwatch teslimatStopWatch = new Stopwatch();
            teslimatTimerlar.Add(dataGridView1.Rows[e.RowIndex], teslimatStopWatch);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dataGrid = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    seciliRow = dataGrid.Rows[e.RowIndex];

                    if (e.RowIndex != -1)
                    {
                        //ürün teslim alındı checkbox
                        if (e.ColumnIndex == 6)
                        {
                            if ((bool)seciliRow.Cells[6].Value)
                            {
                                var urunStopwatch = urunTimerlar[dataGridView1.Rows[e.RowIndex]];
                                var teslimStopWatch = teslimatTimerlar[dataGridView1.Rows[e.RowIndex]];

                                urunStopwatch.Stop();
                                teslimStopWatch.Start();
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Yolda.Durum;
                            }
                        }

                        //urun teslim edildi checkbox
                        if (e.ColumnIndex == 8)
                        {
                            //checkbox checked
                            if ((bool)seciliRow.Cells[8].Value)
                            {
                                if (dataGridView1.Rows[e.RowIndex].Cells[8].Value == null)
                                {
                                    dataGridView1[8, e.RowIndex].Value = false;
                                    dataGridView1.RefreshEdit();
                                    logger.HataLogEkle("Seçili siipariş için ödeme yöntemi seçilmeden tamamlandıya basıldı");
                                    return;
                                }

                                dataGrid.EndEdit();

                                var teslimStopwatch = teslimatTimerlar[dataGrid.Rows[e.RowIndex]];
                                teslimStopwatch.Stop();

                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Tamamlandi.Durum;

                                Restoran restoran = restoranlarDataSource.List.OfType<Restoran>().Where(k => k.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault();
                                Kurye kurye = kuryelerDataSource.List.OfType<Kurye>().Where(k => k.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[5].Value).FirstOrDefault();
                                Bolge bolge = bolgelerDataSource.List.OfType<Bolge>().Where(b => b.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value).FirstOrDefault();
                                OdemeYontemi odemeYontemi = odemeYontemiDataSource.List.OfType<OdemeYontemi>().Where(y => y.Id == (int)dataGridView1.Rows[e.RowIndex].Cells[2].Value).FirstOrDefault();

                                Siparis tamamlananSiparis = new Siparis()
                                {
                                    KuryeIsim = kurye.Isim,
                                    RestoranIsim = restoran.Isim,
                                    OdemeYontem = odemeYontemi.YontemIsim,
                                    BolgeIsim = bolge.Isim,
                                    HazirlanmaSuresi = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(),
                                    TeslimatSuresi = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(),
                                    Tarih = DateTime.Now.ToString()
                                };

                                SiparisService.SiparisKaydet(tamamlananSiparis);

                                logger.SiparisTamamlandiLogEkle(tamamlananSiparis);

                                kayitliSiparislerSayisi++;
                                oturumdaTamamlananSiparisSayisi++;

                                dataGridView1.Rows.Remove(seciliRow);
                                DGVRowHelper.DGVSatirlariOlustur(dataGridView1, restoranlarDataSource, kuryelerDataSource, bolgelerDataSource, odemeYontemiDataSource, 1);

                                logger.LogEkle(tamamlananSiparis.Id + " numaralı siparişin tamamlandı sms\'i " + restoran.Tel + " numarasına gönderiliyor");
                                logger.LogEkle("SMS Gönderim işlemi sonucu: " + SMSHelper.SMSGonder(tamamlananSiparis, restoran.Tel));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Sipariş tamamlama işlemi esnasında hata: " + ex.ToString());
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //ödeme yöntemi seçildi
                if (e.ColumnIndex == 2 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    var urunStopwatch = urunTimerlar[dataGridView1.Rows[e.RowIndex]];
                    urunStopwatch.Start();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = Models.SiparisDurumu.Aliniyor.Durum;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
        }

        //sağ click menü "çıkar"
        private void menuItemCikar_Click(object sender, EventArgs e)
        {
            if (seciliRow != null)
                dataGridView1.Rows.Remove(seciliRow);
        }

        //sağ click menü "ekle"
        private void menuItemEkle_Click(object sender, EventArgs e)
        {
            DGVRowHelper.DGVSatirlariOlustur(dataGridView1, restoranlarDataSource, kuryelerDataSource, bolgelerDataSource, odemeYontemiDataSource, 1);
        }
        #endregion

        #region KAYIT TAB
        private void kuryeKayitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kuryeKayitIsimTextBox.Text))
            {
                KuryeService.KuryeKaydet(new Kurye()
                {
                    Isim = kuryeKayitIsimTextBox.Text
                });

                logger.LogEkle(kuryeKayitIsimTextBox.Text + " kurye eklendi");

                kuryeleriGetir();
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
            if (!Regex.Match(restoranKayitTelTextBox.Text, @"^([0-9]{11})$").Success)
            {
                MessageBox.Show("Lütfen geçerli bir telefon numarası girin" + Environment.NewLine + "Örnek: 05123456789", "❎ Geçersiz Telefon Numarası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(restoranKayitIsimTextBox.Text) && !string.IsNullOrEmpty(restoranKayitTelTextBox.Text))
            {
                RestoranService.RestoranKaydet(new Restoran()
                {
                    Isim = restoranKayitIsimTextBox.Text,
                    Tel = restoranKayitTelTextBox.Text
                });

                logger.LogEkle(restoranKayitIsimTextBox.Text + " restoran eklendi");

                restoranlariGetir();
            }
            else
                logger.LogEkle("Restoran ismi ya da telefon numarası girilmediği için kayıt yapılamadı");
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

        private void bolgeKaydetButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bolgeKayitIsimTextBox.Text))
            {
                BolgeService.BolgeKaydet(new Bolge()
                {
                    Isim = bolgeKayitIsimTextBox.Text
                });

                logger.LogEkle(bolgeKayitIsimTextBox.Text + " bölge eklendi");

                bolgeleriGetir();
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

        private void odemeYontemiKaydetButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(odemeYontemiKayitTextBox.Text))
            {
                OdemeYontemiService.OdemeYontemiKaydet(new OdemeYontemi()
                {
                    YontemIsim = odemeYontemiKayitTextBox.Text
                });

                logger.LogEkle(odemeYontemiKayitTextBox.Text + " ödeme yöntemi eklendi");

                odemeYontemleriGetir();
            }
            else
                logger.LogEkle("Ödeme yöntemi girilmediği için kayıt yapılamadı");
        }

        private void odemeYontemleriGetirButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("ÖdemeYötemleriGetir butonu tıklandı");

            odemeYontemleriGetir();

            odemeYontemiComboBox.DataSource = odemeYontemiDataSource;
            odemeYontemiComboBox.DisplayMember = "YontemIsim";
            odemeYontemiComboBox.ValueMember = "Id";
        }

        private void odemeYontemiSilButton_Click(object sender, EventArgs e)
        {
            logger.LogEkle("ÖdemeYöntemiSil butonu tıklandı");

            if (!string.IsNullOrEmpty(odemeYontemiComboBox.Text))
            {
                OdemeYontemiService.OdemeYontemiSil((OdemeYontemi)odemeYontemiComboBox.SelectedItem);

                logger.LogEkle(odemeYontemiComboBox.Text + " ödeme yöntemi silindi");
            }

            odemeYontemleriGetir();
        }
        #endregion

        #region KURYE, RESTORAN, SİPARİŞ, BÖLGE ve ÖDEME YÖNTEMLERİ GETİRME FONKSİYONLARI
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

        private void odemeYontemleriGetir()
        {
            logger.LogEkle("Ödeme yöntemleri veritabanından getiriliyor");

            List<OdemeYontemi> odemeYontemleri = OdemeYontemiService.OdemeYontemleriGetir();

            odemeYontemiDataSource.DataSource = odemeYontemleri;

            logger.LogEkle("Ödeme yöntemleri getirildi");
        }
        #endregion

        #region TIMER TICK FONKSİYONLARI
        private void UrunTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                aktifUrunTimerSayisi = 0;

                foreach (var timer in urunTimerlar)
                {
                    if (timer.Value.IsRunning)
                    {
                        timer.Key.Cells[4].Value = timer.Value.Elapsed.ToString("hh\\:mm\\:ss");
                        aktifUrunTimerSayisi++;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Ürün timer tick methodunda hata: " + ex.ToString());
            }
        }
        private void TeslimatTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                aktifTeslimatTimerSayisi = 0;
                dagitimdakiKuryeler = "";

                foreach (var timer in teslimatTimerlar)
                {
                    if (timer.Value.IsRunning)
                    {
                        timer.Key.Cells[7].Value = timer.Value.Elapsed.ToString("hh\\:mm\\:ss");
                        aktifTeslimatTimerSayisi++;
                        if (!dagitimdakiKuryeler.Contains(timer.Key.Cells[5].FormattedValue.ToString()))
                            dagitimdakiKuryeler += timer.Key.Cells[5].FormattedValue + ", ";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("Teslimat timer tick methodunda hata: " + ex.ToString());
            }
        }

        private void BilgilendirmeLabellarTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.UIThread(() => FillLabels());
            }
            catch(Exception ex)
            {
                logger.HataLogEkle("Bilgilendirme timer tick methodunda hata: " + ex.ToString());
            }
        }

        private void FillLabels()
        {
            label15.Text = DateTime.Now.ToString();
            label16.Text = "Ürünü alma aşamasındaki sipariş sayısı: " + aktifUrunTimerSayisi;
            label17.Text = "Teslimat aşamasındaki sipariş sayısı: " + aktifTeslimatTimerSayisi;
            label18.Text = "Oturumda tamamlanan sipariş sayısı: " + oturumdaTamamlananSiparisSayisi;
            label19.Text = "Toplam tamamlanan sipariş sayısı: " + kayitliSiparislerSayisi;
            label21.Text = "Dağıtımda olan kuryeler: " + Environment.NewLine + dagitimdakiKuryeler;
        }
        #endregion

        #region TAB CONTROL FONKSİYONLARI
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabRaporlama"])
            {
                tabControl1.TabPages["tabRaporlama"].Hide();

                AdminLoginPopup popup = new AdminLoginPopup();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    tabControl1.TabPages["tabRaporlama"].Show();

                    kuryeRaporlamaComboBox.DataSource = kuryelerDataSource;
                    kuryeRaporlamaComboBox.DisplayMember = "Isim";
                    kuryeRaporlamaComboBox.ValueMember = "Id";

                    restoranRaporlamaComboBox.DataSource = restoranlarDataSource;
                    restoranRaporlamaComboBox.DisplayMember = "Isim";
                    restoranRaporlamaComboBox.ValueMember = "Id";

                    bolgeRaporlamaComboBox.DataSource = bolgelerDataSource;
                    bolgeRaporlamaComboBox.DisplayMember = "Isim";
                    bolgeRaporlamaComboBox.ValueMember = "Id";

                    odemeRaporlamaComboBox.DataSource = odemeYontemiDataSource;
                    odemeRaporlamaComboBox.DisplayMember = "YontemIsim";
                    odemeRaporlamaComboBox.ValueMember = "Id";
                }
                else
                    tabControl1.SelectedTab = tabControl1.TabPages["tabKuryeTakip"];
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabKayit"])
            {
                tabControl1.TabPages["tabKayit"].Hide();

                AdminLoginPopup popup = new AdminLoginPopup();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    tabControl1.TabPages["tabKayit"].Show();

                    kuryelerComboBox.DataSource = kuryelerDataSource;
                    kuryelerComboBox.DisplayMember = "Isim";
                    kuryelerComboBox.ValueMember = "Id";

                    restoranlarComboBox.DataSource = restoranlarDataSource;
                    restoranlarComboBox.DisplayMember = "Isim";
                    restoranlarComboBox.ValueMember = "Id";

                    bolgelerComboBox.DataSource = bolgelerDataSource;
                    bolgelerComboBox.DisplayMember = "Isim";
                    bolgelerComboBox.ValueMember = "Id";

                    odemeYontemiComboBox.DataSource = odemeYontemiDataSource;
                    odemeYontemiComboBox.DisplayMember = "YontemIsim";
                    odemeYontemiComboBox.ValueMember = "Id";
                }
                else
                    tabControl1.SelectedTab = tabControl1.TabPages["tabKuryeTakip"];
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAyar"])
            {
                tabControl1.TabPages["tabAyar"].Hide();

                AdminLoginPopup popup = new AdminLoginPopup();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    tabControl1.TabPages["tabAyar"].Show();

                    Ayar smsAyarlari = AyarService.SMSAyarlariGetir();

                    if (smsAyarlari != null)
                    {
                        if (smsAyarlari.SMSUserCode != null)
                            smsUsedCodeTextBox.Text = smsAyarlari.SMSUserCode;

                        if (smsAyarlari.SMSPassword != null)
                            smsPasswordTextBox.Text = smsAyarlari.SMSPassword;

                        if (smsAyarlari.SMSMessageHeader != null)
                            smsHeaderTextBox.Text = smsAyarlari.SMSMessageHeader;

                        if (smsAyarlari.SMSMessageTemplate != null)
                            smsMessageTemplateTextBox.Text = smsAyarlari.SMSMessageTemplate;
                    }
                }
                else
                    tabControl1.SelectedTab = tabControl1.TabPages["tabKuryeTakip"];
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabLoglar"])
            {
                tabControl1.TabPages["tabLoglar"].Hide();
                AdminLoginPopup popup = new AdminLoginPopup();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    tabControl1.TabPages["tabLoglar"].Show();

                }
                else
                    tabControl1.SelectedTab = tabControl1.TabPages["tabKuryeTakip"];
            }
        }
        #endregion

        #region RAPORLAMA TAB
        private void kuryeTumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Kurye raporlaması için tüm siparişler çekiliyor");
                List<Siparis> kuryeTumSiparisler = siparisleriGetir().Where(s => s.KuryeIsim == kuryeRaporlamaComboBox.Text).ToList();

                logger.RaporLogEkle(kuryeRaporlamaComboBox.Text + " kurye için tüm siparişler çekildi");

                raporTabDataGridView.DataSource = kuryeTumSiparisler.ToDataTable();

                kuryeRaporlamaTextBox.Text = "Kayıtlı kurye sayısı: " + kuryelerDataSource.Count + Environment.NewLine;
                kuryeRaporlamaTextBox.Text += kuryeRaporlamaComboBox.Text + " sipariş sayısı: " + kuryeTumSiparisler.Count + Environment.NewLine;
                kuryeRaporlamaTextBox.Text += kuryeRaporlamaComboBox.Text + " ortalama teslimat süresi: " + ortalamaSureHesaplama(kuryeTumSiparisler, "teslimat");

                logger.RaporLogEkle(kuryeRaporlamaComboBox.Text + " kurye için raporlama hazırlandı, ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Kurye raporlamasında hata: " + ex.Message);
            }
        }

        private void restoranTumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Restoran raporlaması için tüm siparişler çekiliyor");

                List<Siparis> restoranTumSiparisler = siparisleriGetir().Where(s => s.RestoranIsim == restoranRaporlamaComboBox.Text).ToList();

                logger.RaporLogEkle(restoranRaporlamaComboBox.Text + " restoran için tüm siparişler çekildi");

                raporTabDataGridView.DataSource = restoranTumSiparisler.ToDataTable();

                restoranRaporlamaTextBox.Text = "Kayıtlı restoran sayısı: " + restoranlarDataSource.Count + Environment.NewLine;
                restoranRaporlamaTextBox.Text += restoranRaporlamaComboBox.Text + " toplam sipariş sayısı: " + restoranTumSiparisler.Count + Environment.NewLine;
                restoranRaporlamaTextBox.Text += restoranRaporlamaComboBox.Text + " ortalama hazırlama süresi: " + ortalamaSureHesaplama(restoranTumSiparisler, "hazırlama");

                logger.RaporLogEkle(restoranRaporlamaComboBox.Text + " restoran için raporlama hazırlandı, ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Restoran raporlamasında hata: " + ex.Message);
            }
        }

        private void bolgeTumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Bölge raporlaması için tüm siparişler çekiliyor");

                List<Siparis> bolgeTumSiparisler = siparisleriGetir().Where(s => s.BolgeIsim == bolgeRaporlamaComboBox.Text).ToList();

                logger.RaporLogEkle(bolgeRaporlamaComboBox.Text + " bölgesi için tüm siparişler çekildi");

                raporTabDataGridView.DataSource = bolgeTumSiparisler.ToDataTable();

                bolgeRaporlamaTextBox.Text = "Kayıtlı bölge sayısı: " + bolgeTumSiparisler.Count + Environment.NewLine;
                bolgeRaporlamaTextBox.Text += bolgeRaporlamaComboBox.Text + " toplam sipariş sayısı: " + bolgeTumSiparisler.Count + Environment.NewLine;
                bolgeRaporlamaTextBox.Text += bolgeRaporlamaComboBox.Text + " ortalama hazırlama süresi: " + ortalamaSureHesaplama(bolgeTumSiparisler, "hazırlama");
                bolgeRaporlamaTextBox.Text += Environment.NewLine;
                bolgeRaporlamaTextBox.Text += bolgeRaporlamaComboBox.Text + " ortalama teslimat süresi: " + ortalamaSureHesaplama(bolgeTumSiparisler, "teslimat");

                logger.RaporLogEkle(bolgeRaporlamaComboBox.Text + " bölge için raporlama hazırlandı, ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Bölge raporlamasında hata: " + ex.Message);
            }
        }

        private void odemeTumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Ödeme Yöntemi raporlaması için tüm siparişler çekiliyor");

                List<Siparis> odemeTumSiparisler = siparisleriGetir().Where(s => s.OdemeYontem == odemeRaporlamaComboBox.Text).ToList();

                logger.RaporLogEkle(odemeRaporlamaComboBox.Text + " ödeme yöntemi için tüm siparişler çekildi");

                raporTabDataGridView.DataSource = odemeTumSiparisler.ToDataTable();

                odemeRaporlamaTextBox.Text = "Kayıtlı ödeme yöntemi sayısı: " + odemeTumSiparisler.Count + Environment.NewLine;
                odemeRaporlamaTextBox.Text += odemeRaporlamaComboBox.Text + " ile ödenen toplam sipariş sayısı: " + odemeTumSiparisler.Count;

                logger.RaporLogEkle(odemeRaporlamaComboBox.Text + " ödeme yöntemi için raporlama hazırlandı, ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Ödeme Yöntemi raporlamasında hata: " + ex.Message);
            }
        }

        private void tarihTumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Tarih aralığı raporlaması için tüm siparişler çekiliyor");

                List<Siparis> tarihAraligindakiSiparisler = siparisleriGetir().Where(s => DateTime.Parse(s.Tarih) >= DateTime.Parse(baslangicTarihDateTimePicker.Value.ToShortDateString()) &&
                                                                                      DateTime.Parse(s.Tarih) <= bitisTarihDateTimePicker.Value).ToList();

                logger.RaporLogEkle(baslangicTarihDateTimePicker.Value.ToShortDateString() + " ile " + bitisTarihDateTimePicker.Value + " aralığındaki için tüm siparişler çekildi");

                raporTabDataGridView.DataSource = tarihAraligindakiSiparisler.ToDataTable();

                tarihRaporlamaTextBox.Text = baslangicTarihDateTimePicker.Value.ToShortDateString() + " ile " + bitisTarihDateTimePicker.Value + " tarihleri arasındaki siparişler listelendi" + Environment.NewLine;
                if (tarihAraligindakiSiparisler.Count > 0)
                    tarihRaporlamaTextBox.Text += tarihAraligindakiSiparisler.Count + " adet sipariş bulundu";
                else
                    tarihRaporlamaTextBox.Text += "Girilen tarih aralığında hiç sipariş bulunamadı";

                logger.RaporLogEkle("Girilen tarih aralığındaki siparişler için raporlama hazırlandı, ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Tarih aralığındaki siparişler raporlamasında hata: " + ex.Message);
            }
        }

        private void tumSiparisleriGetirButton_Click(object sender, EventArgs e)
        {
            try
            {
                logger.RaporLogEkle("Tüm siparişler çekiliyor");

                raporTabDataGridView.DataSource = siparisleriGetir().ToDataTable();

                logger.RaporLogEkle("Tüm siparişler ekrana verildi");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Tüm siparişlerin raporlamasında hata: " + ex.Message);
            }
        }

        private string ortalamaSureHesaplama(List<Siparis> siparisler, string sureTipi)
        {
            try
            {
                logger.RaporLogEkle("Siparişler için ortalama süre hesaplaması yapılıyor");

                TimeSpan toplamTeslimatSuresi = new TimeSpan();
                TimeSpan parsed = new TimeSpan();

                foreach (var siparis in siparisler)
                {

                    switch (sureTipi)
                    {
                        case "hazırlama":
                            parsed = TimeSpan.Parse(siparis.HazirlanmaSuresi);
                            break;

                        case "teslimat":
                            parsed = TimeSpan.Parse(siparis.TeslimatSuresi);
                            break;
                    }

                    toplamTeslimatSuresi += parsed;
                }

                TimeSpan ortalama = new TimeSpan(toplamTeslimatSuresi.Ticks / siparisler.Count);

                logger.RaporLogEkle("Ortalama süre hesaplaması yapıldı");

                return ortalama.ToString("hh\\:mm\\:ss");
            }
            catch (Exception ex)
            {
                logger.RaporHataLogEkle("Tüm siparişlerin raporlamasında hata: " + ex.Message);
                return "##Hesaplanamadı##";
            }
        }
        #endregion

        #region AYAR TAB
        private void elementsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (elementsListBox.SelectedItem != null)
            {
                switch (elementsListBox.SelectedIndex)
                {
                    case 0:
                        smsMessageTemplateTextBox.Text += "%siparisno% ";
                        break;
                    case 1:
                        smsMessageTemplateTextBox.Text += "%restoranisim% ";
                        break;
                    case 2:
                        smsMessageTemplateTextBox.Text += "%kuryeisim% ";
                        break;
                    case 3:
                        smsMessageTemplateTextBox.Text += "%bolgeisim% ";
                        break;
                    case 4:
                        smsMessageTemplateTextBox.Text += "%odemeyontemi% ";
                        break;
                    case 5:
                        smsMessageTemplateTextBox.Text += "%tarihsaat% ";
                        break;
                }
            }
        }

        private void smsAyarKaydetButton_Click(object sender, EventArgs e)
        {
            try
            {
                Ayar smsAyarlari = new Ayar()
                {
                    SMSUserCode = smsUsedCodeTextBox.Text,
                    SMSPassword = smsPasswordTextBox.Text,
                    SMSMessageHeader = smsHeaderTextBox.Text,
                    SMSMessageTemplate = smsMessageTemplateTextBox.Text
                };

                if (AyarService.SMSAyarlariKaydet(smsAyarlari))
                    MessageBox.Show("SMS Ayarlarınız başarıyla kayıt edilmiştir.", "✅ Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.HataLogEkle("SMS Ayarları kaydedilirken hata: " + ex.ToString());
                MessageBox.Show("SMS Ayarlarınız kayıt edilememiştir." + Environment.NewLine + "Sebebi: " + ex.ToString(), "❎ Kayıt Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showSampleMessageButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            List<Restoran> restoranlar = restoranlarDataSource.List.OfType<Restoran>().ToList();
            List<Kurye> kuryeler = kuryelerDataSource.List.OfType<Kurye>().ToList();
            List<Bolge> bolgeler = bolgelerDataSource.List.OfType<Bolge>().ToList();
            List<OdemeYontemi> odemeYontemleri = odemeYontemiDataSource.List.OfType<OdemeYontemi>().ToList();

            string ornekSiparisNum = random.Next(0, 100).ToString();
            string ornekRestoranIsim = restoranlar[random.Next(0, restoranlar.Count())].Isim;
            string ornekKuryeIsim = kuryeler[random.Next(0, kuryeler.Count())].Isim;
            string ornekBolgeIsim = bolgeler[random.Next(0, bolgeler.Count())].Isim;
            string ornekOdemeYontemi = odemeYontemleri[random.Next(0, odemeYontemleri.Count())].YontemIsim;
            string ornekTarihSaat = DateTime.Now.ToString();

            StringBuilder builder = new StringBuilder(smsMessageTemplateTextBox.Text);

            builder.Replace("%siparisno%", ornekSiparisNum);
            builder.Replace("%restoranisim%", ornekRestoranIsim);
            builder.Replace("%kuryeisim%", ornekKuryeIsim);
            builder.Replace("%bolgeisim%", ornekBolgeIsim);
            builder.Replace("%odemeyontemi%", ornekOdemeYontemi);
            builder.Replace("%tarihsaat%", ornekTarihSaat);

            MessageBox.Show(builder.ToString(), "Örnek SMS Çıktısı", MessageBoxButtons.OK);
        }

        private void adminPasswordRenewButton_Click(object sender, EventArgs e)
        {
           try
            {
                Kullanici admin = KullaniciService.AdminKullaniciGetir();

                if (PasswordHelper.CreateMD5(adminOldPasswordTextBox.Text) == admin.Password)
                {
                    if (adminNewPasswordTextBox.Text == adminNewPasswordAgainTextBox.Text)
                    {
                        KullaniciService.AdminParolaDegistir(PasswordHelper.CreateMD5(adminNewPasswordTextBox.Text));
                        adminSifreDegistirmeLabel.Text = "Yetkili şifresi değiştirildi ✅";
                    }
                    else
                        adminSifreDegistirmeLabel.Text = "Yeni şifreler uyuşmuyor! ❎";
                }
                else
                    adminSifreDegistirmeLabel.Text = "Eski şifre doğru değil! ❎";
            }
            catch(Exception ex)
            {
                adminSifreDegistirmeLabel.Text = "Hata meydana geldi, log\'a bakın!";
                logger.HataLogEkle("Yetkili şifre değişikliği esnasında hata: " + ex.ToString());
            }
        }
        #endregion
    }
}
