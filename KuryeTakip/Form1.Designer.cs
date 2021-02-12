
namespace KuryeTakip
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKuryeTakip = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.siparisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restoran = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kurye = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunSure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuryeYolda = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bolge = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dagitimSuresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teslimEdildi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabRaporlama = new System.Windows.Forms.TabPage();
            this.tabKayit = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bolgeleriGetirButton = new System.Windows.Forms.Button();
            this.bolgelerComboBox = new System.Windows.Forms.ComboBox();
            this.bolgeSilButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.restoranlariGetirButton = new System.Windows.Forms.Button();
            this.restoranlarComboBox = new System.Windows.Forms.ComboBox();
            this.restoranSilButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bolgeKaydetButton = new System.Windows.Forms.Button();
            this.bolgeKayitIsimTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kuryeleriGetirButton = new System.Windows.Forms.Button();
            this.kuryelerComboBox = new System.Windows.Forms.ComboBox();
            this.kuryeSilButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.restoranKaydetButton = new System.Windows.Forms.Button();
            this.restoranKayitIsimTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kuryeKayitButton = new System.Windows.Forms.Button();
            this.kuryeKayitIsimTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAyar = new System.Windows.Forms.TabPage();
            this.tabLoglar = new System.Windows.Forms.TabPage();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kuryeTakipMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCikar = new System.Windows.Forms.ToolStripMenuItem();
            this.kayitLogTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabKuryeTakip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabKayit.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabLoglar.SuspendLayout();
            this.kuryeTakipMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKuryeTakip);
            this.tabControl1.Controls.Add(this.tabRaporlama);
            this.tabControl1.Controls.Add(this.tabKayit);
            this.tabControl1.Controls.Add(this.tabAyar);
            this.tabControl1.Controls.Add(this.tabLoglar);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1165, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabKuryeTakip
            // 
            this.tabKuryeTakip.Controls.Add(this.dataGridView1);
            this.tabKuryeTakip.Location = new System.Drawing.Point(4, 22);
            this.tabKuryeTakip.Name = "tabKuryeTakip";
            this.tabKuryeTakip.Padding = new System.Windows.Forms.Padding(3);
            this.tabKuryeTakip.Size = new System.Drawing.Size(1157, 497);
            this.tabKuryeTakip.TabIndex = 0;
            this.tabKuryeTakip.Text = "Kurye Takip";
            this.tabKuryeTakip.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.siparisNo,
            this.restoran,
            this.kurye,
            this.durum,
            this.urunSure,
            this.kuryeYolda,
            this.bolge,
            this.dagitimSuresi,
            this.teslimEdildi});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 485);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // siparisNo
            // 
            this.siparisNo.FillWeight = 150F;
            this.siparisNo.HeaderText = "Sipariş No";
            this.siparisNo.Name = "siparisNo";
            this.siparisNo.ReadOnly = true;
            this.siparisNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // restoran
            // 
            this.restoran.FillWeight = 460F;
            this.restoran.HeaderText = "Restoran";
            this.restoran.Name = "restoran";
            // 
            // kurye
            // 
            this.kurye.FillWeight = 460F;
            this.kurye.HeaderText = "Kurye";
            this.kurye.Name = "kurye";
            // 
            // durum
            // 
            this.durum.FillWeight = 460F;
            this.durum.HeaderText = "Durum";
            this.durum.Name = "durum";
            this.durum.ReadOnly = true;
            this.durum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // urunSure
            // 
            this.urunSure.FillWeight = 460F;
            this.urunSure.HeaderText = "Ürün Alınma Süresi";
            this.urunSure.Name = "urunSure";
            this.urunSure.ReadOnly = true;
            this.urunSure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // kuryeYolda
            // 
            this.kuryeYolda.FillWeight = 460F;
            this.kuryeYolda.HeaderText = "Ürün Teslim Alındı";
            this.kuryeYolda.Name = "kuryeYolda";
            // 
            // bolge
            // 
            this.bolge.FillWeight = 460F;
            this.bolge.HeaderText = "Dağıtım Bölgesi";
            this.bolge.Name = "bolge";
            // 
            // dagitimSuresi
            // 
            this.dagitimSuresi.FillWeight = 460F;
            this.dagitimSuresi.HeaderText = "Urun Dağıtım Süresi";
            this.dagitimSuresi.Name = "dagitimSuresi";
            this.dagitimSuresi.ReadOnly = true;
            this.dagitimSuresi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // teslimEdildi
            // 
            this.teslimEdildi.FillWeight = 460F;
            this.teslimEdildi.HeaderText = "Teslim Edildi";
            this.teslimEdildi.Name = "teslimEdildi";
            // 
            // tabRaporlama
            // 
            this.tabRaporlama.Location = new System.Drawing.Point(4, 22);
            this.tabRaporlama.Name = "tabRaporlama";
            this.tabRaporlama.Padding = new System.Windows.Forms.Padding(3);
            this.tabRaporlama.Size = new System.Drawing.Size(1157, 497);
            this.tabRaporlama.TabIndex = 1;
            this.tabRaporlama.Text = "Raporlama";
            this.tabRaporlama.UseVisualStyleBackColor = true;
            // 
            // tabKayit
            // 
            this.tabKayit.Controls.Add(this.kayitLogTextBox);
            this.tabKayit.Controls.Add(this.groupBox6);
            this.tabKayit.Controls.Add(this.groupBox4);
            this.tabKayit.Controls.Add(this.groupBox7);
            this.tabKayit.Controls.Add(this.groupBox3);
            this.tabKayit.Controls.Add(this.groupBox5);
            this.tabKayit.Controls.Add(this.groupBox2);
            this.tabKayit.Location = new System.Drawing.Point(4, 22);
            this.tabKayit.Name = "tabKayit";
            this.tabKayit.Padding = new System.Windows.Forms.Padding(3);
            this.tabKayit.Size = new System.Drawing.Size(1157, 497);
            this.tabKayit.TabIndex = 3;
            this.tabKayit.Text = "Kayıt";
            this.tabKayit.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bolgeleriGetirButton);
            this.groupBox6.Controls.Add(this.bolgelerComboBox);
            this.groupBox6.Controls.Add(this.bolgeSilButton);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Location = new System.Drawing.Point(664, 99);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(323, 87);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bölge Sil";
            // 
            // bolgeleriGetirButton
            // 
            this.bolgeleriGetirButton.Location = new System.Drawing.Point(9, 58);
            this.bolgeleriGetirButton.Name = "bolgeleriGetirButton";
            this.bolgeleriGetirButton.Size = new System.Drawing.Size(137, 23);
            this.bolgeleriGetirButton.TabIndex = 4;
            this.bolgeleriGetirButton.Text = "Bölgeleri Getir";
            this.bolgeleriGetirButton.UseVisualStyleBackColor = true;
            this.bolgeleriGetirButton.Click += new System.EventHandler(this.bolgeleriGetirButton_Click);
            // 
            // bolgelerComboBox
            // 
            this.bolgelerComboBox.FormattingEnabled = true;
            this.bolgelerComboBox.Location = new System.Drawing.Point(40, 13);
            this.bolgelerComboBox.Name = "bolgelerComboBox";
            this.bolgelerComboBox.Size = new System.Drawing.Size(277, 21);
            this.bolgelerComboBox.TabIndex = 3;
            // 
            // bolgeSilButton
            // 
            this.bolgeSilButton.Location = new System.Drawing.Point(180, 58);
            this.bolgeSilButton.Name = "bolgeSilButton";
            this.bolgeSilButton.Size = new System.Drawing.Size(137, 23);
            this.bolgeSilButton.TabIndex = 2;
            this.bolgeSilButton.Text = "Bölge Sil";
            this.bolgeSilButton.UseVisualStyleBackColor = true;
            this.bolgeSilButton.Click += new System.EventHandler(this.bolgeSilButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "İsim:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.restoranlariGetirButton);
            this.groupBox4.Controls.Add(this.restoranlarComboBox);
            this.groupBox4.Controls.Add(this.restoranSilButton);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(335, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(323, 87);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Restoran Sil";
            // 
            // restoranlariGetirButton
            // 
            this.restoranlariGetirButton.Location = new System.Drawing.Point(9, 58);
            this.restoranlariGetirButton.Name = "restoranlariGetirButton";
            this.restoranlariGetirButton.Size = new System.Drawing.Size(137, 23);
            this.restoranlariGetirButton.TabIndex = 4;
            this.restoranlariGetirButton.Text = "Restoranları Getir";
            this.restoranlariGetirButton.UseVisualStyleBackColor = true;
            this.restoranlariGetirButton.Click += new System.EventHandler(this.restoranlariGetirButton_Click);
            // 
            // restoranlarComboBox
            // 
            this.restoranlarComboBox.FormattingEnabled = true;
            this.restoranlarComboBox.Location = new System.Drawing.Point(40, 13);
            this.restoranlarComboBox.Name = "restoranlarComboBox";
            this.restoranlarComboBox.Size = new System.Drawing.Size(277, 21);
            this.restoranlarComboBox.TabIndex = 3;
            // 
            // restoranSilButton
            // 
            this.restoranSilButton.Location = new System.Drawing.Point(180, 58);
            this.restoranSilButton.Name = "restoranSilButton";
            this.restoranSilButton.Size = new System.Drawing.Size(137, 23);
            this.restoranSilButton.TabIndex = 2;
            this.restoranSilButton.Text = "Restoran Sil";
            this.restoranSilButton.UseVisualStyleBackColor = true;
            this.restoranSilButton.Click += new System.EventHandler(this.restoranSilButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "İsim:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bolgeKaydetButton);
            this.groupBox7.Controls.Add(this.bolgeKayitIsimTextBox);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(664, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(323, 87);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Bölge Kayıt";
            // 
            // bolgeKaydetButton
            // 
            this.bolgeKaydetButton.Location = new System.Drawing.Point(180, 58);
            this.bolgeKaydetButton.Name = "bolgeKaydetButton";
            this.bolgeKaydetButton.Size = new System.Drawing.Size(137, 23);
            this.bolgeKaydetButton.TabIndex = 2;
            this.bolgeKaydetButton.Text = "Bölge Kaydet";
            this.bolgeKaydetButton.UseVisualStyleBackColor = true;
            this.bolgeKaydetButton.Click += new System.EventHandler(this.bolgeKaydetButton_Click);
            // 
            // bolgeKayitIsimTextBox
            // 
            this.bolgeKayitIsimTextBox.Location = new System.Drawing.Point(40, 13);
            this.bolgeKayitIsimTextBox.Name = "bolgeKayitIsimTextBox";
            this.bolgeKayitIsimTextBox.Size = new System.Drawing.Size(277, 20);
            this.bolgeKayitIsimTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "İsim:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kuryeleriGetirButton);
            this.groupBox3.Controls.Add(this.kuryelerComboBox);
            this.groupBox3.Controls.Add(this.kuryeSilButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 87);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kurye Sil";
            // 
            // kuryeleriGetirButton
            // 
            this.kuryeleriGetirButton.Location = new System.Drawing.Point(9, 58);
            this.kuryeleriGetirButton.Name = "kuryeleriGetirButton";
            this.kuryeleriGetirButton.Size = new System.Drawing.Size(137, 23);
            this.kuryeleriGetirButton.TabIndex = 4;
            this.kuryeleriGetirButton.Text = "Kuryeleri Getir";
            this.kuryeleriGetirButton.UseVisualStyleBackColor = true;
            this.kuryeleriGetirButton.Click += new System.EventHandler(this.kuryeleriGetirButton_Click);
            // 
            // kuryelerComboBox
            // 
            this.kuryelerComboBox.FormattingEnabled = true;
            this.kuryelerComboBox.Location = new System.Drawing.Point(40, 13);
            this.kuryelerComboBox.Name = "kuryelerComboBox";
            this.kuryelerComboBox.Size = new System.Drawing.Size(277, 21);
            this.kuryelerComboBox.TabIndex = 3;
            // 
            // kuryeSilButton
            // 
            this.kuryeSilButton.Location = new System.Drawing.Point(180, 58);
            this.kuryeSilButton.Name = "kuryeSilButton";
            this.kuryeSilButton.Size = new System.Drawing.Size(137, 23);
            this.kuryeSilButton.TabIndex = 2;
            this.kuryeSilButton.Text = "Kurye Sil";
            this.kuryeSilButton.UseVisualStyleBackColor = true;
            this.kuryeSilButton.Click += new System.EventHandler(this.kuryeSilButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "İsim:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.restoranKaydetButton);
            this.groupBox5.Controls.Add(this.restoranKayitIsimTextBox);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(335, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(323, 87);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Restoran Kayıt";
            // 
            // restoranKaydetButton
            // 
            this.restoranKaydetButton.Location = new System.Drawing.Point(180, 58);
            this.restoranKaydetButton.Name = "restoranKaydetButton";
            this.restoranKaydetButton.Size = new System.Drawing.Size(137, 23);
            this.restoranKaydetButton.TabIndex = 2;
            this.restoranKaydetButton.Text = "Restoran Kaydet";
            this.restoranKaydetButton.UseVisualStyleBackColor = true;
            this.restoranKaydetButton.Click += new System.EventHandler(this.restoranKaydetButton_Click);
            // 
            // restoranKayitIsimTextBox
            // 
            this.restoranKayitIsimTextBox.Location = new System.Drawing.Point(40, 13);
            this.restoranKayitIsimTextBox.Name = "restoranKayitIsimTextBox";
            this.restoranKayitIsimTextBox.Size = new System.Drawing.Size(277, 20);
            this.restoranKayitIsimTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "İsim:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kuryeKayitButton);
            this.groupBox2.Controls.Add(this.kuryeKayitIsimTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 87);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kurye Kayıt";
            // 
            // kuryeKayitButton
            // 
            this.kuryeKayitButton.Location = new System.Drawing.Point(180, 58);
            this.kuryeKayitButton.Name = "kuryeKayitButton";
            this.kuryeKayitButton.Size = new System.Drawing.Size(137, 23);
            this.kuryeKayitButton.TabIndex = 2;
            this.kuryeKayitButton.Text = "Kurye Kaydet";
            this.kuryeKayitButton.UseVisualStyleBackColor = true;
            this.kuryeKayitButton.Click += new System.EventHandler(this.kuryeKayitButton_Click);
            // 
            // kuryeKayitIsimTextBox
            // 
            this.kuryeKayitIsimTextBox.Location = new System.Drawing.Point(40, 13);
            this.kuryeKayitIsimTextBox.Name = "kuryeKayitIsimTextBox";
            this.kuryeKayitIsimTextBox.Size = new System.Drawing.Size(277, 20);
            this.kuryeKayitIsimTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "İsim:";
            // 
            // tabAyar
            // 
            this.tabAyar.Location = new System.Drawing.Point(4, 22);
            this.tabAyar.Name = "tabAyar";
            this.tabAyar.Size = new System.Drawing.Size(1157, 497);
            this.tabAyar.TabIndex = 2;
            this.tabAyar.Text = "Ayar";
            this.tabAyar.UseVisualStyleBackColor = true;
            // 
            // tabLoglar
            // 
            this.tabLoglar.Controls.Add(this.logTextBox);
            this.tabLoglar.Location = new System.Drawing.Point(4, 22);
            this.tabLoglar.Name = "tabLoglar";
            this.tabLoglar.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoglar.Size = new System.Drawing.Size(1157, 497);
            this.tabLoglar.TabIndex = 4;
            this.tabLoglar.Text = "Loglar";
            this.tabLoglar.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(1157, 497);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1174, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgilendirme:";
            // 
            // kuryeTakipMenu
            // 
            this.kuryeTakipMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEkle,
            this.menuItemCikar});
            this.kuryeTakipMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.kuryeTakipMenu.Name = "kuryeTakipMenu";
            this.kuryeTakipMenu.Size = new System.Drawing.Size(102, 48);
            this.kuryeTakipMenu.Text = "Ekle/Çıkar";
            // 
            // menuItemEkle
            // 
            this.menuItemEkle.Name = "menuItemEkle";
            this.menuItemEkle.Size = new System.Drawing.Size(101, 22);
            this.menuItemEkle.Text = "Ekle";
            this.menuItemEkle.Click += new System.EventHandler(this.menuItemEkle_Click);
            // 
            // menuItemCikar
            // 
            this.menuItemCikar.Name = "menuItemCikar";
            this.menuItemCikar.Size = new System.Drawing.Size(101, 22);
            this.menuItemCikar.Text = "Çıkar";
            this.menuItemCikar.Click += new System.EventHandler(this.menuItemCikar_Click);
            // 
            // kayitLogTextBox
            // 
            this.kayitLogTextBox.Location = new System.Drawing.Point(6, 192);
            this.kayitLogTextBox.Name = "kayitLogTextBox";
            this.kayitLogTextBox.Size = new System.Drawing.Size(981, 299);
            this.kayitLogTextBox.TabIndex = 9;
            this.kayitLogTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 725);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Kurye Takip v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabKuryeTakip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabKayit.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabLoglar.ResumeLayout(false);
            this.kuryeTakipMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKuryeTakip;
        private System.Windows.Forms.TabPage tabRaporlama;
        private System.Windows.Forms.TabPage tabAyar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabKayit;
        private System.Windows.Forms.ContextMenuStrip kuryeTakipMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemEkle;
        private System.Windows.Forms.ToolStripMenuItem menuItemCikar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox kuryelerComboBox;
        private System.Windows.Forms.Button kuryeSilButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button kuryeKayitButton;
        private System.Windows.Forms.TextBox kuryeKayitIsimTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kuryeleriGetirButton;
        private System.Windows.Forms.TabPage tabLoglar;
        public System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button restoranlariGetirButton;
        private System.Windows.Forms.ComboBox restoranlarComboBox;
        private System.Windows.Forms.Button restoranSilButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button restoranKaydetButton;
        private System.Windows.Forms.TextBox restoranKayitIsimTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bolgeleriGetirButton;
        private System.Windows.Forms.ComboBox bolgelerComboBox;
        private System.Windows.Forms.Button bolgeSilButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bolgeKaydetButton;
        private System.Windows.Forms.TextBox bolgeKayitIsimTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn restoran;
        private System.Windows.Forms.DataGridViewComboBoxColumn kurye;
        private System.Windows.Forms.DataGridViewTextBoxColumn durum;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunSure;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kuryeYolda;
        private System.Windows.Forms.DataGridViewComboBoxColumn bolge;
        private System.Windows.Forms.DataGridViewTextBoxColumn dagitimSuresi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn teslimEdildi;
        public System.Windows.Forms.RichTextBox kayitLogTextBox;
    }
}

