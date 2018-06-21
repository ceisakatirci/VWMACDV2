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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button_Baslat = new System.Windows.Forms.Button();
            this.listBox_SinyalAlinanlarHepsi = new System.Windows.Forms.ListBox();
            this.listBox_EMA144 = new System.Windows.Forms.ListBox();
            this.label_Vwmacd = new System.Windows.Forms.Label();
            this.label_Signal = new System.Windows.Forms.Label();
            this.checkBox_Aktif = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.zedGraphControl1.Size = new System.Drawing.Size(1597, 492);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // button_Baslat
            // 
            this.button_Baslat.Location = new System.Drawing.Point(40, 517);
            this.button_Baslat.Name = "button_Baslat";
            this.button_Baslat.Size = new System.Drawing.Size(75, 23);
            this.button_Baslat.TabIndex = 1;
            this.button_Baslat.Text = "Başlat";
            this.button_Baslat.UseVisualStyleBackColor = true;
            this.button_Baslat.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_SinyalAlinanlarHepsi
            // 
            this.listBox_SinyalAlinanlarHepsi.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_SinyalAlinanlarHepsi.FormattingEnabled = true;
            this.listBox_SinyalAlinanlarHepsi.Location = new System.Drawing.Point(1271, 492);
            this.listBox_SinyalAlinanlarHepsi.Name = "listBox_SinyalAlinanlarHepsi";
            this.listBox_SinyalAlinanlarHepsi.Size = new System.Drawing.Size(326, 307);
            this.listBox_SinyalAlinanlarHepsi.TabIndex = 3;
            this.listBox_SinyalAlinanlarHepsi.SelectedIndexChanged += new System.EventHandler(this.listBox_SinyalAlinanlarHepsi_SelectedIndexChanged);
            this.listBox_SinyalAlinanlarHepsi.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox_EMA144
            // 
            this.listBox_EMA144.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_EMA144.FormattingEnabled = true;
            this.listBox_EMA144.Location = new System.Drawing.Point(918, 492);
            this.listBox_EMA144.Name = "listBox_EMA144";
            this.listBox_EMA144.Size = new System.Drawing.Size(353, 307);
            this.listBox_EMA144.TabIndex = 4;
            this.listBox_EMA144.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_AnlikSinyalAlinanlar_MouseDoubleClick);
            // 
            // label_Vwmacd
            // 
            this.label_Vwmacd.AutoSize = true;
            this.label_Vwmacd.Location = new System.Drawing.Point(51, 608);
            this.label_Vwmacd.Name = "label_Vwmacd";
            this.label_Vwmacd.Size = new System.Drawing.Size(47, 13);
            this.label_Vwmacd.TabIndex = 5;
            this.label_Vwmacd.Text = "vwmacd";
            // 
            // label_Signal
            // 
            this.label_Signal.AutoSize = true;
            this.label_Signal.Location = new System.Drawing.Point(51, 575);
            this.label_Signal.Name = "label_Signal";
            this.label_Signal.Size = new System.Drawing.Size(34, 13);
            this.label_Signal.TabIndex = 5;
            this.label_Signal.Text = "signal";
            // 
            // checkBox_Aktif
            // 
            this.checkBox_Aktif.AutoSize = true;
            this.checkBox_Aktif.Location = new System.Drawing.Point(193, 521);
            this.checkBox_Aktif.Name = "checkBox_Aktif";
            this.checkBox_Aktif.Size = new System.Drawing.Size(47, 17);
            this.checkBox_Aktif.TabIndex = 6;
            this.checkBox_Aktif.Text = "Aktif";
            this.checkBox_Aktif.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 799);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Aktif);
            this.Controls.Add(this.label_Signal);
            this.Controls.Add(this.label_Vwmacd);
            this.Controls.Add(this.listBox_EMA144);
            this.Controls.Add(this.listBox_SinyalAlinanlarHepsi);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.button_Baslat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button_Baslat;
        private System.Windows.Forms.ListBox listBox_SinyalAlinanlarHepsi;
        private System.Windows.Forms.ListBox listBox_EMA144;
        private System.Windows.Forms.Label label_Vwmacd;
        private System.Windows.Forms.Label label_Signal;
        private System.Windows.Forms.CheckBox checkBox_Aktif;
        private System.Windows.Forms.Button button1;
    }
}

