namespace HaliSahaOtomasyon
{
    partial class FrmRandevuAl
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbSahalar = new System.Windows.Forms.ComboBox();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlSahaDetay = new System.Windows.Forms.Panel();
            this.pnlSahaBilgi = new DevExpress.XtraEditors.PanelControl();
            this.lblOrtalama = new DevExpress.XtraEditors.LabelControl();
            this.ratingOrtalama = new DevExpress.XtraEditors.RatingControl();
            this.btnYorumYap = new DevExpress.XtraEditors.SimpleButton();
            this.gridYorumlar = new System.Windows.Forms.DataGridView();
            this.pbSahaResim = new DevExpress.XtraEditors.PictureEdit();
            this.wbHarita = new System.Windows.Forms.WebBrowser();
            this.cmsYorumIslemleri = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yorumuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yorumuDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnlSahaDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSahaBilgi)).BeginInit();
            this.pnlSahaBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingOrtalama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridYorumlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSahaResim.Properties)).BeginInit();
            this.cmsYorumIslemleri.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.flowLayoutPanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(527, 732);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Randevu Saatleri";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbSahalar);
            this.panelControl1.Controls.Add(this.dtTarih);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(523, 34);
            this.panelControl1.TabIndex = 3;
            // 
            // cmbSahalar
            // 
            this.cmbSahalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSahalar.FormattingEnabled = true;
            this.cmbSahalar.Location = new System.Drawing.Point(5, 5);
            this.cmbSahalar.Name = "cmbSahalar";
            this.cmbSahalar.Size = new System.Drawing.Size(251, 21);
            this.cmbSahalar.TabIndex = 2;
            this.cmbSahalar.SelectedIndexChanged += new System.EventHandler(this.cmbSahalar_SelectedIndexChanged);
            // 
            // dtTarih
            // 
            this.dtTarih.Location = new System.Drawing.Point(273, 5);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(247, 21);
            this.dtTarih.TabIndex = 0;
            this.dtTarih.ValueChanged += new System.EventHandler(this.dtTarih_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 55);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(524, 677);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(1526, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(274, 732);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Randevularım";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(270, 707);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // pnlSahaDetay
            // 
            this.pnlSahaDetay.Controls.Add(this.pnlSahaBilgi);
            this.pnlSahaDetay.Controls.Add(this.pbSahaResim);
            this.pnlSahaDetay.Controls.Add(this.wbHarita);
            this.pnlSahaDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSahaDetay.Location = new System.Drawing.Point(527, 0);
            this.pnlSahaDetay.Name = "pnlSahaDetay";
            this.pnlSahaDetay.Size = new System.Drawing.Size(999, 732);
            this.pnlSahaDetay.TabIndex = 2;
            // 
            // pnlSahaBilgi
            // 
            this.pnlSahaBilgi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSahaBilgi.Controls.Add(this.lblOrtalama);
            this.pnlSahaBilgi.Controls.Add(this.ratingOrtalama);
            this.pnlSahaBilgi.Controls.Add(this.btnYorumYap);
            this.pnlSahaBilgi.Controls.Add(this.gridYorumlar);
            this.pnlSahaBilgi.Location = new System.Drawing.Point(0, 259);
            this.pnlSahaBilgi.Name = "pnlSahaBilgi";
            this.pnlSahaBilgi.Size = new System.Drawing.Size(992, 575);
            this.pnlSahaBilgi.TabIndex = 0;
            // 
            // lblOrtalama
            // 
            this.lblOrtalama.Location = new System.Drawing.Point(127, 27);
            this.lblOrtalama.Name = "lblOrtalama";
            this.lblOrtalama.Size = new System.Drawing.Size(16, 13);
            this.lblOrtalama.TabIndex = 5;
            this.lblOrtalama.Text = "0.0";
            // 
            // ratingOrtalama
            // 
            this.ratingOrtalama.Location = new System.Drawing.Point(29, 24);
            this.ratingOrtalama.Name = "ratingOrtalama";
            this.ratingOrtalama.Size = new System.Drawing.Size(92, 16);
            this.ratingOrtalama.TabIndex = 4;
            this.ratingOrtalama.Text = "ratingControl1";
            // 
            // btnYorumYap
            // 
            this.btnYorumYap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYorumYap.Appearance.Options.UseFont = true;
            this.btnYorumYap.Location = new System.Drawing.Point(815, 5);
            this.btnYorumYap.Name = "btnYorumYap";
            this.btnYorumYap.Size = new System.Drawing.Size(159, 32);
            this.btnYorumYap.TabIndex = 3;
            this.btnYorumYap.Text = "Yorum Yap";
            this.btnYorumYap.Click += new System.EventHandler(this.btnYorumYap_Click);
            // 
            // gridYorumlar
            // 
            this.gridYorumlar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridYorumlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridYorumlar.Location = new System.Drawing.Point(5, 54);
            this.gridYorumlar.Name = "gridYorumlar";
            this.gridYorumlar.Size = new System.Drawing.Size(981, 477);
            this.gridYorumlar.TabIndex = 2;
            this.gridYorumlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridYorumlar_CellContentClick);
            this.gridYorumlar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridYorumlar_MouseClick);
            // 
            // pbSahaResim
            // 
            this.pbSahaResim.Location = new System.Drawing.Point(4, 12);
            this.pbSahaResim.Name = "pbSahaResim";
            this.pbSahaResim.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbSahaResim.Size = new System.Drawing.Size(553, 241);
            this.pbSahaResim.TabIndex = 0;
            // 
            // wbHarita
            // 
            this.wbHarita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbHarita.Location = new System.Drawing.Point(563, 12);
            this.wbHarita.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHarita.Name = "wbHarita";
            this.wbHarita.Size = new System.Drawing.Size(417, 241);
            this.wbHarita.TabIndex = 1;
            // 
            // cmsYorumIslemleri
            // 
            this.cmsYorumIslemleri.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yorumuSilToolStripMenuItem,
            this.yorumuDüzenleToolStripMenuItem});
            this.cmsYorumIslemleri.Name = "contextMenuStrip1";
            this.cmsYorumIslemleri.Size = new System.Drawing.Size(162, 48);
            this.cmsYorumIslemleri.Opening += new System.ComponentModel.CancelEventHandler(this.cmsYorumIslemleri_Opening);
            // 
            // yorumuSilToolStripMenuItem
            // 
            this.yorumuSilToolStripMenuItem.Name = "yorumuSilToolStripMenuItem";
            this.yorumuSilToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.yorumuSilToolStripMenuItem.Text = "Yorumu Sil";
            this.yorumuSilToolStripMenuItem.Click += new System.EventHandler(this.yorumuSilToolStripMenuItem_Click);
            // 
            // yorumuDüzenleToolStripMenuItem
            // 
            this.yorumuDüzenleToolStripMenuItem.Name = "yorumuDüzenleToolStripMenuItem";
            this.yorumuDüzenleToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.yorumuDüzenleToolStripMenuItem.Text = "Yorumu Düzenle";
            this.yorumuDüzenleToolStripMenuItem.Click += new System.EventHandler(this.yorumuDüzenleToolStripMenuItem_Click);
            // 
            // FrmRandevuAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 732);
            this.Controls.Add(this.pnlSahaDetay);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmRandevuAl";
            this.ShowIcon = false;
            this.Text = "FrmRandevuAl";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRandevuAl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnlSahaDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSahaBilgi)).EndInit();
            this.pnlSahaBilgi.ResumeLayout(false);
            this.pnlSahaBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingOrtalama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridYorumlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSahaResim.Properties)).EndInit();
            this.cmsYorumIslemleri.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cmbSahalar;
        private System.Windows.Forms.Panel pnlSahaDetay;
        private DevExpress.XtraEditors.PanelControl pnlSahaBilgi;
        private DevExpress.XtraEditors.PictureEdit pbSahaResim;
        private System.Windows.Forms.DataGridView gridYorumlar;
        private System.Windows.Forms.WebBrowser wbHarita;
        private DevExpress.XtraEditors.SimpleButton btnYorumYap;
        private System.Windows.Forms.ContextMenuStrip cmsYorumIslemleri;
        private System.Windows.Forms.ToolStripMenuItem yorumuSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yorumuDüzenleToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblOrtalama;
        private DevExpress.XtraEditors.RatingControl ratingOrtalama;
    }
}