
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
            this.tabRaporlama = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabAyar = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabKayit = new System.Windows.Forms.TabPage();
            this.kuryeTakipMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCikar = new System.Windows.Forms.ToolStripMenuItem();
            this.siparisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restoran = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kurye = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunSure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuryeYolda = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dagitimSuresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teslimEdildi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabKuryeTakip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.kuryeTakipMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKuryeTakip);
            this.tabControl1.Controls.Add(this.tabRaporlama);
            this.tabControl1.Controls.Add(this.tabKayit);
            this.tabControl1.Controls.Add(this.tabAyar);
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1174, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgilendirme:";
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
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.siparisNo,
            this.restoran,
            this.kurye,
            this.durum,
            this.urunSure,
            this.kuryeYolda,
            this.dagitimSuresi,
            this.teslimEdildi});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowTemplate.Height = 150;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 485);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // tabKayit
            // 
            this.tabKayit.Location = new System.Drawing.Point(4, 22);
            this.tabKayit.Name = "tabKayit";
            this.tabKayit.Padding = new System.Windows.Forms.Padding(3);
            this.tabKayit.Size = new System.Drawing.Size(1157, 497);
            this.tabKayit.TabIndex = 3;
            this.tabKayit.Text = "Kayıt";
            this.tabKayit.UseVisualStyleBackColor = true;
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
            // siparisNo
            // 
            this.siparisNo.FillWeight = 150F;
            this.siparisNo.HeaderText = "Sipariş No";
            this.siparisNo.Name = "siparisNo";
            this.siparisNo.ReadOnly = true;
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
            // 
            // urunSure
            // 
            this.urunSure.FillWeight = 460F;
            this.urunSure.HeaderText = "Ürün Alınma Süresi";
            this.urunSure.Name = "urunSure";
            // 
            // kuryeYolda
            // 
            this.kuryeYolda.FillWeight = 460F;
            this.kuryeYolda.HeaderText = "Ürün Teslim Alındı";
            this.kuryeYolda.Name = "kuryeYolda";
            // 
            // dagitimSuresi
            // 
            this.dagitimSuresi.FillWeight = 460F;
            this.dagitimSuresi.HeaderText = "Urun Dağıtım Süresi";
            this.dagitimSuresi.Name = "dagitimSuresi";
            // 
            // teslimEdildi
            // 
            this.teslimEdildi.FillWeight = 460F;
            this.teslimEdildi.HeaderText = "Teslim Edildi";
            this.teslimEdildi.Name = "teslimEdildi";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn siparisNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn restoran;
        private System.Windows.Forms.DataGridViewComboBoxColumn kurye;
        private System.Windows.Forms.DataGridViewTextBoxColumn durum;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunSure;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kuryeYolda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dagitimSuresi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn teslimEdildi;
    }
}

