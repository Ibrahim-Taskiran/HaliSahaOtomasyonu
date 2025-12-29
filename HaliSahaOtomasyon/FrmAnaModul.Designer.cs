namespace HaliSahaOtomasyon
{
    partial class FrmAnaModul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaModul));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAnasayfa = new DevExpress.XtraBars.BarButtonItem();
            this.btnHalisahalar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMesajlar = new DevExpress.XtraBars.BarButtonItem();
            this.btnProfilim = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaclarim = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            this.btnRandevular = new DevExpress.XtraBars.BarButtonItem();
            this.txtKullaniciBilgi = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnBahisformu = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnAnasayfa,
            this.btnHalisahalar,
            this.btnMesajlar,
            this.btnProfilim,
            this.btnMaclarim,
            this.barButtonItem1,
            this.btnCikis,
            this.btnRandevular,
            this.txtKullaniciBilgi,
            this.btnBahisformu});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.txtKullaniciBilgi);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 158);
            // 
            // btnAnasayfa
            // 
            this.btnAnasayfa.Caption = "Anasayfa";
            this.btnAnasayfa.Id = 1;
            this.btnAnasayfa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAnasayfa.ImageOptions.Image")));
            this.btnAnasayfa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAnasayfa.ImageOptions.LargeImage")));
            this.btnAnasayfa.Name = "btnAnasayfa";
            this.btnAnasayfa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAnasayfa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnasayfa_ItemClick);
            // 
            // btnHalisahalar
            // 
            this.btnHalisahalar.Caption = "Sahalar";
            this.btnHalisahalar.Id = 2;
            this.btnHalisahalar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHalisahalar.ImageOptions.Image")));
            this.btnHalisahalar.Name = "btnHalisahalar";
            this.btnHalisahalar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHalisahalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHalisahalar_ItemClick);
            // 
            // btnMesajlar
            // 
            this.btnMesajlar.Caption = "Mesajlar";
            this.btnMesajlar.Id = 3;
            this.btnMesajlar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMesajlar.ImageOptions.SvgImage")));
            this.btnMesajlar.Name = "btnMesajlar";
            this.btnMesajlar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnProfilim
            // 
            this.btnProfilim.Caption = "Profil";
            this.btnProfilim.Id = 4;
            this.btnProfilim.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProfilim.ImageOptions.SvgImage")));
            this.btnProfilim.Name = "btnProfilim";
            this.btnProfilim.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnProfilim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProfilim_ItemClick);
            // 
            // btnMaclarim
            // 
            this.btnMaclarim.Caption = "Maçlarım";
            this.btnMaclarim.Id = 5;
            this.btnMaclarim.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMaclarim.ImageOptions.Image")));
            this.btnMaclarim.Name = "btnMaclarim";
            this.btnMaclarim.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMaclarim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaclarim_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnCikis
            // 
            this.btnCikis.Caption = "Çıkış Yap";
            this.btnCikis.Id = 7;
            this.btnCikis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.ImageOptions.Image")));
            this.btnCikis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCikis.ImageOptions.LargeImage")));
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            // 
            // btnRandevular
            // 
            this.btnRandevular.Caption = "Randevularım";
            this.btnRandevular.Id = 8;
            this.btnRandevular.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRandevular.ImageOptions.Image")));
            this.btnRandevular.Name = "btnRandevular";
            this.btnRandevular.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRandevular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRandevular_ItemClick);
            // 
            // txtKullaniciBilgi
            // 
            this.txtKullaniciBilgi.Caption = "Hoşgeldiniz";
            this.txtKullaniciBilgi.Id = 9;
            this.txtKullaniciBilgi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtKullaniciBilgi.ImageOptions.SvgImage")));
            this.txtKullaniciBilgi.Name = "txtKullaniciBilgi";
            this.txtKullaniciBilgi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menü";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAnasayfa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnHalisahalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProfilim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMaclarim);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRandevular);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBahisformu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCikis);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // btnBahisformu
            // 
            this.btnBahisformu.Caption = "Bahisler";
            this.btnBahisformu.Id = 10;
            this.btnBahisformu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBahisformu.ImageOptions.Image")));
            this.btnBahisformu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBahisformu.ImageOptions.LargeImage")));
            this.btnBahisformu.Name = "btnBahisformu";
            this.btnBahisformu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBahisformu_ItemClick);
            // 
            // FrmAnaModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FrmAnaModul";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Anasayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAnaModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem btnAnasayfa;
        private DevExpress.XtraBars.BarButtonItem btnHalisahalar;
        private DevExpress.XtraBars.BarButtonItem btnMesajlar;
        private DevExpress.XtraBars.BarButtonItem btnProfilim;
        private DevExpress.XtraBars.BarButtonItem btnMaclarim;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.BarButtonItem btnRandevular;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem txtKullaniciBilgi;
        private DevExpress.XtraBars.BarButtonItem btnBahisformu;
    }
}