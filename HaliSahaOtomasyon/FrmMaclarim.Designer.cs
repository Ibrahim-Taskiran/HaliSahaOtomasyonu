namespace HaliSahaOtomasyon
{
    partial class FrmMaclarim
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileSiradakiMac = new DevExpress.XtraEditors.TileItem();
            this.tileHavaDurumu = new DevExpress.XtraEditors.TileItem();
            this.tileToplamMac = new DevExpress.XtraEditors.TileItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeniEkle = new DevExpress.XtraEditors.SimpleButton();
            this.gridMaclarim = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.linkEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaclarim)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tileControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1426, 130);
            this.panelControl1.TabIndex = 0;
            // 
            // tileControl1
            // 
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.MaxId = 10;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(1426, 170);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileSiradakiMac);
            this.tileGroup2.Items.Add(this.tileHavaDurumu);
            this.tileGroup2.Items.Add(this.tileToplamMac);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileSiradakiMac
            // 
            this.tileSiradakiMac.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tileSiradakiMac.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileSiradakiMac.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileSiradakiMac.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement1.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            tileItemElement1.Appearance.Normal.BorderColor = System.Drawing.Color.Transparent;
            tileItemElement1.Appearance.Normal.Options.UseBackColor = true;
            tileItemElement1.Appearance.Normal.Options.UseBorderColor = true;
            tileItemElement1.Appearance.Selected.BackColor = System.Drawing.Color.Transparent;
            tileItemElement1.Appearance.Selected.Options.UseBackColor = true;
            tileItemElement1.Text = "Gelecek Maç";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tileSiradakiMac.Elements.Add(tileItemElement1);
            this.tileSiradakiMac.Id = 7;
            this.tileSiradakiMac.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileSiradakiMac.Name = "tileSiradakiMac";
            // 
            // tileHavaDurumu
            // 
            this.tileHavaDurumu.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkCyan;
            this.tileHavaDurumu.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileHavaDurumu.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileHavaDurumu.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement2.Text = "Hava Durumu";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tileHavaDurumu.Elements.Add(tileItemElement2);
            this.tileHavaDurumu.Id = 8;
            this.tileHavaDurumu.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileHavaDurumu.Name = "tileHavaDurumu";
            // 
            // tileToplamMac
            // 
            this.tileToplamMac.AppearanceItem.Normal.BackColor = System.Drawing.Color.Green;
            this.tileToplamMac.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileToplamMac.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileToplamMac.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement3.Text = "Toplam Maç";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tileToplamMac.Elements.Add(tileItemElement3);
            this.tileToplamMac.Id = 9;
            this.tileToplamMac.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileToplamMac.Name = "tileToplamMac";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnYenile);
            this.panelControl2.Controls.Add(this.btnYeniEkle);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 601);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1426, 60);
            this.panelControl2.TabIndex = 1;
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(786, 16);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(75, 23);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYeniEkle
            // 
            this.btnYeniEkle.Location = new System.Drawing.Point(565, 16);
            this.btnYeniEkle.Name = "btnYeniEkle";
            this.btnYeniEkle.Size = new System.Drawing.Size(75, 23);
            this.btnYeniEkle.TabIndex = 0;
            this.btnYeniEkle.Text = "Ekle";
            this.btnYeniEkle.Click += new System.EventHandler(this.btnYeniEkle_Click);
            // 
            // gridMaclarim
            // 
            this.gridMaclarim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaclarim.EmbeddedNavigator.ContextMenuStrip = this.contextMenuStrip1;
            this.gridMaclarim.Location = new System.Drawing.Point(0, 130);
            this.gridMaclarim.MainView = this.gridView1;
            this.gridMaclarim.Name = "gridMaclarim";
            this.gridMaclarim.Size = new System.Drawing.Size(1426, 471);
            this.gridMaclarim.TabIndex = 2;
            this.gridMaclarim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkEkleToolStripMenuItem,
            this.kaydıSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // linkEkleToolStripMenuItem
            // 
            this.linkEkleToolStripMenuItem.Name = "linkEkleToolStripMenuItem";
            this.linkEkleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.linkEkleToolStripMenuItem.Text = "Link Ekle";
            this.linkEkleToolStripMenuItem.Click += new System.EventHandler(this.mnuLinkEkle_Click);
            // 
            // kaydıSilToolStripMenuItem
            // 
            this.kaydıSilToolStripMenuItem.Name = "kaydıSilToolStripMenuItem";
            this.kaydıSilToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.kaydıSilToolStripMenuItem.Text = "Kaydı Sil";
            this.kaydıSilToolStripMenuItem.Click += new System.EventHandler(this.mnuSil_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridMaclarim;
            this.gridView1.Name = "gridView1";
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // FrmMaclarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 661);
            this.Controls.Add(this.gridMaclarim);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmMaclarim";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maçlarım";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMaclarim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaclarim)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridMaclarim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileSiradakiMac;
        private DevExpress.XtraEditors.TileItem tileHavaDurumu;
        private DevExpress.XtraEditors.TileItem tileToplamMac;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnYeniEkle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linkEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydıSilToolStripMenuItem;
    }
}