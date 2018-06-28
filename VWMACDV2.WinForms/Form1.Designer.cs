namespace VWMACDV2.WinForms
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
            this.zedGraphControl_VWMACDV24Saatlik = new ZedGraph.ZedGraphControl();
            this.button_Baslat = new System.Windows.Forms.Button();
            this.listBox_SinyalAlinanlar = new System.Windows.Forms.ListBox();
            this.listBox_Ortalamalar = new System.Windows.Forms.ListBox();
            this.checkBox_Aktif = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Sirala = new System.Windows.Forms.Button();
            this.button_Yukle = new System.Windows.Forms.Button();
            this.button_Temizle = new System.Windows.Forms.Button();
            this.button_Kaydet = new System.Windows.Forms.Button();
            this.label_KayitlarAdet = new System.Windows.Forms.Label();
            this.label_BinanceClientCoinAdet = new System.Windows.Forms.Label();
            this.label_VWMACDV2SinyalAdet = new System.Windows.Forms.Label();
            this.label_DigerAdet = new System.Windows.Forms.Label();
            this.label_IslemeAlinanCoinAdedi = new System.Windows.Forms.Label();
            this.listBox_Diger = new System.Windows.Forms.ListBox();
            this.listBox_Hatalar = new System.Windows.Forms.ListBox();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl_VWMACDV24Saatlik
            // 
            this.zedGraphControl_VWMACDV24Saatlik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl_VWMACDV24Saatlik.IsShowPointValues = true;
            this.zedGraphControl_VWMACDV24Saatlik.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl_VWMACDV24Saatlik.Name = "zedGraphControl_VWMACDV24Saatlik";
            this.zedGraphControl_VWMACDV24Saatlik.ScrollGrace = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMaxX = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMaxY = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMaxY2 = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMinX = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMinY = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.ScrollMinY2 = 0D;
            this.zedGraphControl_VWMACDV24Saatlik.Size = new System.Drawing.Size(1450, 612);
            this.zedGraphControl_VWMACDV24Saatlik.TabIndex = 0;
            this.zedGraphControl_VWMACDV24Saatlik.UseExtendedPrintDialog = true;
            // 
            // button_Baslat
            // 
            this.button_Baslat.Location = new System.Drawing.Point(35, 15);
            this.button_Baslat.Name = "button_Baslat";
            this.button_Baslat.Size = new System.Drawing.Size(75, 23);
            this.button_Baslat.TabIndex = 1;
            this.button_Baslat.Text = "Başlat";
            this.button_Baslat.UseVisualStyleBackColor = true;
            this.button_Baslat.Click += new System.EventHandler(this.button_Baslat_Click);
            // 
            // listBox_SinyalAlinanlar
            // 
            this.listBox_SinyalAlinanlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_SinyalAlinanlar.FormattingEnabled = true;
            this.listBox_SinyalAlinanlar.Location = new System.Drawing.Point(3, 3);
            this.listBox_SinyalAlinanlar.Name = "listBox_SinyalAlinanlar";
            this.listBox_SinyalAlinanlar.Size = new System.Drawing.Size(265, 777);
            this.listBox_SinyalAlinanlar.TabIndex = 3;
            this.listBox_SinyalAlinanlar.SelectedIndexChanged += new System.EventHandler(this.listBox_SinyalAlinanlarHepsi_SelectedIndexChanged);
            this.listBox_SinyalAlinanlar.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox_Ortalamalar
            // 
            this.listBox_Ortalamalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Ortalamalar.FormattingEnabled = true;
            this.listBox_Ortalamalar.Location = new System.Drawing.Point(3, 3);
            this.listBox_Ortalamalar.Name = "listBox_Ortalamalar";
            this.listBox_Ortalamalar.Size = new System.Drawing.Size(265, 777);
            this.listBox_Ortalamalar.TabIndex = 4;
            this.listBox_Ortalamalar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_AnlikSinyalAlinanlar_MouseDoubleClick);
            // 
            // checkBox_Aktif
            // 
            this.checkBox_Aktif.AutoSize = true;
            this.checkBox_Aktif.Location = new System.Drawing.Point(472, 21);
            this.checkBox_Aktif.Name = "checkBox_Aktif";
            this.checkBox_Aktif.Size = new System.Drawing.Size(47, 17);
            this.checkBox_Aktif.TabIndex = 6;
            this.checkBox_Aktif.Text = "Aktif";
            this.checkBox_Aktif.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Sirala);
            this.panel1.Controls.Add(this.button_Yukle);
            this.panel1.Controls.Add(this.button_Temizle);
            this.panel1.Controls.Add(this.button_Kaydet);
            this.panel1.Controls.Add(this.button_Baslat);
            this.panel1.Controls.Add(this.label_KayitlarAdet);
            this.panel1.Controls.Add(this.label_BinanceClientCoinAdet);
            this.panel1.Controls.Add(this.label_VWMACDV2SinyalAdet);
            this.panel1.Controls.Add(this.label_DigerAdet);
            this.panel1.Controls.Add(this.label_IslemeAlinanCoinAdedi);
            this.panel1.Controls.Add(this.checkBox_Aktif);
            this.panel1.Location = new System.Drawing.Point(281, 650);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 159);
            this.panel1.TabIndex = 8;
            // 
            // button_Sirala
            // 
            this.button_Sirala.Location = new System.Drawing.Point(322, 112);
            this.button_Sirala.Name = "button_Sirala";
            this.button_Sirala.Size = new System.Drawing.Size(75, 23);
            this.button_Sirala.TabIndex = 8;
            this.button_Sirala.Text = "Sırala";
            this.button_Sirala.UseVisualStyleBackColor = true;
            this.button_Sirala.Click += new System.EventHandler(this.button_Sirala_Click);
            // 
            // button_Yukle
            // 
            this.button_Yukle.Location = new System.Drawing.Point(35, 112);
            this.button_Yukle.Name = "button_Yukle";
            this.button_Yukle.Size = new System.Drawing.Size(75, 23);
            this.button_Yukle.TabIndex = 8;
            this.button_Yukle.Text = "Yükle";
            this.button_Yukle.UseVisualStyleBackColor = true;
            this.button_Yukle.Click += new System.EventHandler(this.button_Yukle_Click);
            // 
            // button_Temizle
            // 
            this.button_Temizle.Location = new System.Drawing.Point(35, 83);
            this.button_Temizle.Name = "button_Temizle";
            this.button_Temizle.Size = new System.Drawing.Size(75, 23);
            this.button_Temizle.TabIndex = 8;
            this.button_Temizle.Text = "Temizle";
            this.button_Temizle.UseVisualStyleBackColor = true;
            this.button_Temizle.Click += new System.EventHandler(this.button_Temizle_Click);
            // 
            // button_Kaydet
            // 
            this.button_Kaydet.Location = new System.Drawing.Point(35, 54);
            this.button_Kaydet.Name = "button_Kaydet";
            this.button_Kaydet.Size = new System.Drawing.Size(75, 23);
            this.button_Kaydet.TabIndex = 7;
            this.button_Kaydet.Text = "Kaydet";
            this.button_Kaydet.UseVisualStyleBackColor = true;
            this.button_Kaydet.Click += new System.EventHandler(this.button_Kaydet_Click);
            // 
            // label_KayitlarAdet
            // 
            this.label_KayitlarAdet.AutoSize = true;
            this.label_KayitlarAdet.Location = new System.Drawing.Point(319, 64);
            this.label_KayitlarAdet.Name = "label_KayitlarAdet";
            this.label_KayitlarAdet.Size = new System.Drawing.Size(69, 13);
            this.label_KayitlarAdet.TabIndex = 5;
            this.label_KayitlarAdet.Text = "Kayıtlar Adet:";
            // 
            // label_BinanceClientCoinAdet
            // 
            this.label_BinanceClientCoinAdet.AutoSize = true;
            this.label_BinanceClientCoinAdet.Location = new System.Drawing.Point(319, 20);
            this.label_BinanceClientCoinAdet.Name = "label_BinanceClientCoinAdet";
            this.label_BinanceClientCoinAdet.Size = new System.Drawing.Size(127, 13);
            this.label_BinanceClientCoinAdet.TabIndex = 5;
            this.label_BinanceClientCoinAdet.Text = "Binance Client Coin Adet:";
            // 
            // label_VWMACDV2SinyalAdet
            // 
            this.label_VWMACDV2SinyalAdet.AutoSize = true;
            this.label_VWMACDV2SinyalAdet.Location = new System.Drawing.Point(135, 64);
            this.label_VWMACDV2SinyalAdet.Name = "label_VWMACDV2SinyalAdet";
            this.label_VWMACDV2SinyalAdet.Size = new System.Drawing.Size(128, 13);
            this.label_VWMACDV2SinyalAdet.TabIndex = 5;
            this.label_VWMACDV2SinyalAdet.Text = "VWMACDV2 Sinyal Adet:";
            // 
            // label_DigerAdet
            // 
            this.label_DigerAdet.AutoSize = true;
            this.label_DigerAdet.Location = new System.Drawing.Point(137, 100);
            this.label_DigerAdet.Name = "label_DigerAdet";
            this.label_DigerAdet.Size = new System.Drawing.Size(60, 13);
            this.label_DigerAdet.TabIndex = 5;
            this.label_DigerAdet.Text = "Diğer Adet:";
            // 
            // label_IslemeAlinanCoinAdedi
            // 
            this.label_IslemeAlinanCoinAdedi.AutoSize = true;
            this.label_IslemeAlinanCoinAdedi.Location = new System.Drawing.Point(137, 20);
            this.label_IslemeAlinanCoinAdedi.Name = "label_IslemeAlinanCoinAdedi";
            this.label_IslemeAlinanCoinAdedi.Size = new System.Drawing.Size(126, 13);
            this.label_IslemeAlinanCoinAdedi.TabIndex = 5;
            this.label_IslemeAlinanCoinAdedi.Text = "İşleme Alınan Coin Adedi:";
            // 
            // listBox_Diger
            // 
            this.listBox_Diger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Diger.FormattingEnabled = true;
            this.listBox_Diger.Location = new System.Drawing.Point(3, 3);
            this.listBox_Diger.Name = "listBox_Diger";
            this.listBox_Diger.Size = new System.Drawing.Size(265, 777);
            this.listBox_Diger.TabIndex = 9;
            this.listBox_Diger.DoubleClick += new System.EventHandler(this.listBox_Diger_DoubleClick);
            // 
            // listBox_Hatalar
            // 
            this.listBox_Hatalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Hatalar.FormattingEnabled = true;
            this.listBox_Hatalar.Location = new System.Drawing.Point(3, 3);
            this.listBox_Hatalar.Name = "listBox_Hatalar";
            this.listBox_Hatalar.Size = new System.Drawing.Size(265, 777);
            this.listBox_Hatalar.TabIndex = 10;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(1450, 612);
            this.zedGraphControl2.TabIndex = 0;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 809);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox_SinyalAlinanlar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(271, 783);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "VWMACDV2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_Ortalamalar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(271, 783);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ortalamalar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_Diger);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 783);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Diğerleri";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listBox_Hatalar);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(271, 783);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Hatalar";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.Location = new System.Drawing.Point(279, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1464, 644);
            this.tabControl2.TabIndex = 12;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.zedGraphControl_VWMACDV24Saatlik);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1456, 618);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "VWMACDV2 4 Saatlik";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.zedGraphControl2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1456, 618);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Ortalamalar";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.zedGraphControl3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1456, 618);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl3.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(1450, 612);
            this.zedGraphControl3.TabIndex = 0;
            this.zedGraphControl3.UseExtendedPrintDialog = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1456, 618);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1743, 809);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl_VWMACDV24Saatlik;
        private System.Windows.Forms.Button button_Baslat;
        private System.Windows.Forms.ListBox listBox_SinyalAlinanlar;
        private System.Windows.Forms.ListBox listBox_Ortalamalar;
        private System.Windows.Forms.CheckBox checkBox_Aktif;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox_Diger;
        private System.Windows.Forms.Label label_BinanceClientCoinAdet;
        private System.Windows.Forms.Label label_KayitlarAdet;
        private System.Windows.Forms.ListBox listBox_Hatalar;
        private System.Windows.Forms.Label label_VWMACDV2SinyalAdet;
        private System.Windows.Forms.Label label_DigerAdet;
        private System.Windows.Forms.Label label_IslemeAlinanCoinAdedi;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button_Temizle;
        private System.Windows.Forms.Button button_Kaydet;
        private System.Windows.Forms.Button button_Yukle;
        private System.Windows.Forms.TabPage tabPage6;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button button_Sirala;
    }
}

