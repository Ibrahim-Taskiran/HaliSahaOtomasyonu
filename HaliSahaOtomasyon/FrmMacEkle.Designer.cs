namespace HaliSahaOtomasyon
{
    partial class FrmMacEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMacEkle));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSaat = new DevExpress.XtraEditors.TextEdit();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.txtSaha = new DevExpress.XtraEditors.TextEdit();
            this.btnBul = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.asdad = new DevExpress.XtraEditors.LabelControl();
            this.txtBaslik = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtLink = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSaat);
            this.panelControl1.Controls.Add(this.dtTarih);
            this.panelControl1.Controls.Add(this.txtSaha);
            this.panelControl1.Controls.Add(this.btnBul);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // txtSaat
            // 
            this.txtSaat.Location = new System.Drawing.Point(568, 15);
            this.txtSaat.Name = "txtSaat";
            this.txtSaat.Size = new System.Drawing.Size(100, 20);
            this.txtSaat.TabIndex = 6;
            // 
            // dtTarih
            // 
            this.dtTarih.Location = new System.Drawing.Point(286, 15);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(200, 21);
            this.dtTarih.TabIndex = 5;
            // 
            // txtSaha
            // 
            this.txtSaha.Location = new System.Drawing.Point(95, 16);
            this.txtSaha.Name = "txtSaha";
            this.txtSaha.Size = new System.Drawing.Size(100, 20);
            this.txtSaha.TabIndex = 4;
            // 
            // btnBul
            // 
            this.btnBul.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBul.ImageOptions.SvgImage")));
            this.btnBul.Location = new System.Drawing.Point(699, 12);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(89, 30);
            this.btnBul.TabIndex = 3;
            this.btnBul.Text = "Maçı Bul";
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(509, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 19);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Saat : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(226, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tarih :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Saha Adı :";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Location = new System.Drawing.Point(286, 211);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(121, 39);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Listeme Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // asdad
            // 
            this.asdad.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.asdad.Appearance.Options.UseFont = true;
            this.asdad.Location = new System.Drawing.Point(95, 119);
            this.asdad.Name = "asdad";
            this.asdad.Size = new System.Drawing.Size(102, 19);
            this.asdad.TabIndex = 3;
            this.asdad.Text = "Maç Başlığı :";
            // 
            // txtBaslik
            // 
            this.txtBaslik.Location = new System.Drawing.Point(203, 121);
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(100, 20);
            this.txtBaslik.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(95, 160);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(101, 19);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Video Linki :";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(203, 162);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(325, 20);
            this.txtLink.TabIndex = 6;
            // 
            // FrmMacEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtBaslik);
            this.Controls.Add(this.asdad);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmMacEkle";
            this.Text = "FrmMacEkle";
            this.Load += new System.EventHandler(this.FrmMacEkle_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaslik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBul;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private DevExpress.XtraEditors.TextEdit txtSaha;
        private DevExpress.XtraEditors.TextEdit txtSaat;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl asdad;
        private DevExpress.XtraEditors.TextEdit txtBaslik;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtLink;
    }
}