﻿namespace VWMACDV2.WinForms
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button_Baslat = new System.Windows.Forms.Button();
            this.listBox_SinyalAlinanlar = new System.Windows.Forms.ListBox();
            this.listBox_Ortalamalar = new System.Windows.Forms.ListBox();
            this.label_Vwmacd = new System.Windows.Forms.Label();
            this.label_Signal = new System.Windows.Forms.Label();
            this.checkBox_Aktif = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_BinanceClientCoinAdet = new System.Windows.Forms.Label();
            this.listBox_Diger = new System.Windows.Forms.ListBox();
            this.listBox_Hatalar = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1348, 492);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // button_Baslat
            // 
            this.button_Baslat.Location = new System.Drawing.Point(35, 15);
            this.button_Baslat.Name = "button_Baslat";
            this.button_Baslat.Size = new System.Drawing.Size(75, 23);
            this.button_Baslat.TabIndex = 1;
            this.button_Baslat.Text = "Başlat";
            this.button_Baslat.UseVisualStyleBackColor = true;
            this.button_Baslat.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_SinyalAlinanlar
            // 
            this.listBox_SinyalAlinanlar.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_SinyalAlinanlar.FormattingEnabled = true;
            this.listBox_SinyalAlinanlar.Location = new System.Drawing.Point(1157, 492);
            this.listBox_SinyalAlinanlar.Name = "listBox_SinyalAlinanlar";
            this.listBox_SinyalAlinanlar.Size = new System.Drawing.Size(191, 307);
            this.listBox_SinyalAlinanlar.TabIndex = 3;
            this.listBox_SinyalAlinanlar.SelectedIndexChanged += new System.EventHandler(this.listBox_SinyalAlinanlarHepsi_SelectedIndexChanged);
            this.listBox_SinyalAlinanlar.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox_Ortalamalar
            // 
            this.listBox_Ortalamalar.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_Ortalamalar.FormattingEnabled = true;
            this.listBox_Ortalamalar.Location = new System.Drawing.Point(932, 492);
            this.listBox_Ortalamalar.Name = "listBox_Ortalamalar";
            this.listBox_Ortalamalar.Size = new System.Drawing.Size(225, 307);
            this.listBox_Ortalamalar.TabIndex = 4;
            this.listBox_Ortalamalar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_AnlikSinyalAlinanlar_MouseDoubleClick);
            // 
            // label_Vwmacd
            // 
            this.label_Vwmacd.AutoSize = true;
            this.label_Vwmacd.Location = new System.Drawing.Point(32, 97);
            this.label_Vwmacd.Name = "label_Vwmacd";
            this.label_Vwmacd.Size = new System.Drawing.Size(47, 13);
            this.label_Vwmacd.TabIndex = 5;
            this.label_Vwmacd.Text = "vwmacd";
            // 
            // label_Signal
            // 
            this.label_Signal.AutoSize = true;
            this.label_Signal.Location = new System.Drawing.Point(32, 64);
            this.label_Signal.Name = "label_Signal";
            this.label_Signal.Size = new System.Drawing.Size(34, 13);
            this.label_Signal.TabIndex = 5;
            this.label_Signal.Text = "signal";
            // 
            // checkBox_Aktif
            // 
            this.checkBox_Aktif.AutoSize = true;
            this.checkBox_Aktif.Location = new System.Drawing.Point(140, 21);
            this.checkBox_Aktif.Name = "checkBox_Aktif";
            this.checkBox_Aktif.Size = new System.Drawing.Size(47, 17);
            this.checkBox_Aktif.TabIndex = 6;
            this.checkBox_Aktif.Text = "Aktif";
            this.checkBox_Aktif.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Baslat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_BinanceClientCoinAdet);
            this.panel1.Controls.Add(this.label_Signal);
            this.panel1.Controls.Add(this.label_Vwmacd);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.checkBox_Aktif);
            this.panel1.Location = new System.Drawing.Point(12, 510);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 129);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Binance Client Coin Adet:";
            // 
            // label_BinanceClientCoinAdet
            // 
            this.label_BinanceClientCoinAdet.AutoSize = true;
            this.label_BinanceClientCoinAdet.Location = new System.Drawing.Point(137, 64);
            this.label_BinanceClientCoinAdet.Name = "label_BinanceClientCoinAdet";
            this.label_BinanceClientCoinAdet.Size = new System.Drawing.Size(127, 13);
            this.label_BinanceClientCoinAdet.TabIndex = 5;
            this.label_BinanceClientCoinAdet.Text = "Binance Client Coin Adet:";
            // 
            // listBox_Diger
            // 
            this.listBox_Diger.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_Diger.FormattingEnabled = true;
            this.listBox_Diger.Location = new System.Drawing.Point(704, 492);
            this.listBox_Diger.Name = "listBox_Diger";
            this.listBox_Diger.Size = new System.Drawing.Size(228, 307);
            this.listBox_Diger.TabIndex = 9;
            // 
            // listBox_Hatalar
            // 
            this.listBox_Hatalar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox_Hatalar.FormattingEnabled = true;
            this.listBox_Hatalar.Location = new System.Drawing.Point(0, 652);
            this.listBox_Hatalar.Name = "listBox_Hatalar";
            this.listBox_Hatalar.Size = new System.Drawing.Size(704, 147);
            this.listBox_Hatalar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 799);
            this.Controls.Add(this.listBox_Hatalar);
            this.Controls.Add(this.listBox_Diger);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox_Ortalamalar);
            this.Controls.Add(this.listBox_SinyalAlinanlar);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button_Baslat;
        private System.Windows.Forms.ListBox listBox_SinyalAlinanlar;
        private System.Windows.Forms.ListBox listBox_Ortalamalar;
        private System.Windows.Forms.Label label_Vwmacd;
        private System.Windows.Forms.Label label_Signal;
        private System.Windows.Forms.CheckBox checkBox_Aktif;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox_Diger;
        private System.Windows.Forms.Label label_BinanceClientCoinAdet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Hatalar;
    }
}

