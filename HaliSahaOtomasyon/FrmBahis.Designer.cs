namespace HaliSahaOtomasyon
{
    partial class FrmBahis
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
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.grpAnaliz = new DevExpress.XtraEditors.GroupControl();
            this.ratingDep = new DevExpress.XtraEditors.RatingControl();
            this.ratingEv = new DevExpress.XtraEditors.RatingControl();
            this.lblDeplasmanAd = new DevExpress.XtraEditors.LabelControl();
            this.lblEvSahibiAd = new DevExpress.XtraEditors.LabelControl();
            this.btnDeplasman = new DevExpress.XtraEditors.SimpleButton();
            this.btnEvSahibi = new DevExpress.XtraEditors.SimpleButton();
            this.grpKupon = new DevExpress.XtraEditors.GroupControl();
            this.btnOnayla = new DevExpress.XtraEditors.SimpleButton();
            this.lblOlasıKazanc = new DevExpress.XtraEditors.LabelControl();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.lblBakiye = new DevExpress.XtraEditors.LabelControl();
            this.lblSecim = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpAnaliz)).BeginInit();
            this.grpAnaliz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingEv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKupon)).BeginInit();
            this.grpKupon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(800, 125);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            // 
            // grpAnaliz
            // 
            this.grpAnaliz.Controls.Add(this.ratingDep);
            this.grpAnaliz.Controls.Add(this.ratingEv);
            this.grpAnaliz.Controls.Add(this.lblDeplasmanAd);
            this.grpAnaliz.Controls.Add(this.lblEvSahibiAd);
            this.grpAnaliz.Controls.Add(this.btnDeplasman);
            this.grpAnaliz.Controls.Add(this.btnEvSahibi);
            this.grpAnaliz.Location = new System.Drawing.Point(0, 131);
            this.grpAnaliz.Name = "grpAnaliz";
            this.grpAnaliz.Size = new System.Drawing.Size(611, 319);
            this.grpAnaliz.TabIndex = 1;
            this.grpAnaliz.Text = "Maç Analizi";
            // 
            // ratingDep
            // 
            this.ratingDep.Location = new System.Drawing.Point(384, 70);
            this.ratingDep.Name = "ratingDep";
            this.ratingDep.Size = new System.Drawing.Size(92, 16);
            this.ratingDep.TabIndex = 5;
            this.ratingDep.Text = "ratingControl2";
            // 
            // ratingEv
            // 
            this.ratingEv.Location = new System.Drawing.Point(135, 70);
            this.ratingEv.Name = "ratingEv";
            this.ratingEv.Size = new System.Drawing.Size(92, 16);
            this.ratingEv.TabIndex = 4;
            this.ratingEv.Text = "ratingControl1";
            // 
            // lblDeplasmanAd
            // 
            this.lblDeplasmanAd.Location = new System.Drawing.Point(384, 47);
            this.lblDeplasmanAd.Name = "lblDeplasmanAd";
            this.lblDeplasmanAd.Size = new System.Drawing.Size(63, 13);
            this.lblDeplasmanAd.TabIndex = 3;
            this.lblDeplasmanAd.Text = "labelControl2";
            // 
            // lblEvSahibiAd
            // 
            this.lblEvSahibiAd.Location = new System.Drawing.Point(135, 47);
            this.lblEvSahibiAd.Name = "lblEvSahibiAd";
            this.lblEvSahibiAd.Size = new System.Drawing.Size(63, 13);
            this.lblEvSahibiAd.TabIndex = 2;
            this.lblEvSahibiAd.Text = "labelControl1";
            // 
            // btnDeplasman
            // 
            this.btnDeplasman.Location = new System.Drawing.Point(384, 106);
            this.btnDeplasman.Name = "btnDeplasman";
            this.btnDeplasman.Size = new System.Drawing.Size(75, 23);
            this.btnDeplasman.TabIndex = 1;
            this.btnDeplasman.Text = "Deplasman";
            this.btnDeplasman.Click += new System.EventHandler(this.BahisSec_Click);
            // 
            // btnEvSahibi
            // 
            this.btnEvSahibi.Location = new System.Drawing.Point(135, 106);
            this.btnEvSahibi.Name = "btnEvSahibi";
            this.btnEvSahibi.Size = new System.Drawing.Size(75, 23);
            this.btnEvSahibi.TabIndex = 0;
            this.btnEvSahibi.Text = "Ev Sahibi";
            this.btnEvSahibi.Click += new System.EventHandler(this.BahisSec_Click);
            // 
            // grpKupon
            // 
            this.grpKupon.Controls.Add(this.btnOnayla);
            this.grpKupon.Controls.Add(this.lblOlasıKazanc);
            this.grpKupon.Controls.Add(this.txtTutar);
            this.grpKupon.Controls.Add(this.lblBakiye);
            this.grpKupon.Controls.Add(this.lblSecim);
            this.grpKupon.Location = new System.Drawing.Point(617, 131);
            this.grpKupon.Name = "grpKupon";
            this.grpKupon.Size = new System.Drawing.Size(183, 319);
            this.grpKupon.TabIndex = 2;
            this.grpKupon.Text = "Kuponum";
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(42, 203);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(75, 23);
            this.btnOnayla.TabIndex = 8;
            this.btnOnayla.Text = "Bahis Yap";
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // lblOlasıKazanc
            // 
            this.lblOlasıKazanc.Location = new System.Drawing.Point(17, 144);
            this.lblOlasıKazanc.Name = "lblOlasıKazanc";
            this.lblOlasıKazanc.Size = new System.Drawing.Size(63, 13);
            this.lblOlasıKazanc.TabIndex = 7;
            this.lblOlasıKazanc.Text = "labelControl2";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(32, 44);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(100, 20);
            this.txtTutar.TabIndex = 6;
            this.txtTutar.EditValueChanged += new System.EventHandler(this.txtTutar_EditValueChanged);
            // 
            // lblBakiye
            // 
            this.lblBakiye.Location = new System.Drawing.Point(17, 116);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(38, 13);
            this.lblBakiye.TabIndex = 5;
            this.lblBakiye.Text = "Bakiye :";
            // 
            // lblSecim
            // 
            this.lblSecim.Location = new System.Drawing.Point(17, 85);
            this.lblSecim.Name = "lblSecim";
            this.lblSecim.Size = new System.Drawing.Size(47, 13);
            this.lblSecim.TabIndex = 4;
            this.lblSecim.Text = "Seçim Yok";
            // 
            // FrmBahis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpKupon);
            this.Controls.Add(this.grpAnaliz);
            this.Controls.Add(this.tileControl1);
            this.Name = "FrmBahis";
            this.Text = "w";
            ((System.ComponentModel.ISupportInitialize)(this.grpAnaliz)).EndInit();
            this.grpAnaliz.ResumeLayout(false);
            this.grpAnaliz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingEv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKupon)).EndInit();
            this.grpKupon.ResumeLayout(false);
            this.grpKupon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.GroupControl grpAnaliz;
        private DevExpress.XtraEditors.GroupControl grpKupon;
        private DevExpress.XtraEditors.LabelControl lblEvSahibiAd;
        private DevExpress.XtraEditors.SimpleButton btnDeplasman;
        private DevExpress.XtraEditors.SimpleButton btnEvSahibi;
        private DevExpress.XtraEditors.LabelControl lblDeplasmanAd;
        private DevExpress.XtraEditors.RatingControl ratingDep;
        private DevExpress.XtraEditors.RatingControl ratingEv;
        private DevExpress.XtraEditors.SimpleButton btnOnayla;
        private DevExpress.XtraEditors.LabelControl lblOlasıKazanc;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.LabelControl lblBakiye;
        private DevExpress.XtraEditors.LabelControl lblSecim;
    }
}