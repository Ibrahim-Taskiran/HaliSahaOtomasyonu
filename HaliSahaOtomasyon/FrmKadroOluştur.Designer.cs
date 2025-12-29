namespace HaliSahaOtomasyon
{
    partial class FrmKadroOlustur
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
            this.grpEvSahibi = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblEvSahibiIsim = new DevExpress.XtraEditors.LabelControl();
            this.btnEvSahibiEkle = new DevExpress.XtraEditors.SimpleButton();
            this.listEvSahibi = new DevExpress.XtraEditors.ListBoxControl();
            this.txtEvSahibiID = new DevExpress.XtraEditors.TextEdit();
            this.grpArkadaslar = new DevExpress.XtraEditors.GroupControl();
            this.gridArkadaslar = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpDeplasman = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblDeplasmanIsim = new DevExpress.XtraEditors.LabelControl();
            this.btnDeplasmanEkle = new DevExpress.XtraEditors.SimpleButton();
            this.listDeplasman = new DevExpress.XtraEditors.ListBoxControl();
            this.txtDeplasmanID = new DevExpress.XtraEditors.TextEdit();
            this.btnMaciOnayla = new DevExpress.XtraEditors.SimpleButton();
            this.cmsKadro = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kendiTakımımaEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rakipTakımaEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grpEvSahibi)).BeginInit();
            this.grpEvSahibi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listEvSahibi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvSahibiID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpArkadaslar)).BeginInit();
            this.grpArkadaslar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArkadaslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDeplasman)).BeginInit();
            this.grpDeplasman.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDeplasman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeplasmanID.Properties)).BeginInit();
            this.cmsKadro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEvSahibi
            // 
            this.grpEvSahibi.Appearance.BackColor = System.Drawing.Color.White;
            this.grpEvSahibi.Appearance.Options.UseBackColor = true;
            this.grpEvSahibi.Controls.Add(this.labelControl2);
            this.grpEvSahibi.Controls.Add(this.lblEvSahibiIsim);
            this.grpEvSahibi.Controls.Add(this.btnEvSahibiEkle);
            this.grpEvSahibi.Controls.Add(this.listEvSahibi);
            this.grpEvSahibi.Controls.Add(this.txtEvSahibiID);
            this.grpEvSahibi.Location = new System.Drawing.Point(2, 0);
            this.grpEvSahibi.Name = "grpEvSahibi";
            this.grpEvSahibi.Size = new System.Drawing.Size(250, 379);
            this.grpEvSahibi.TabIndex = 0;
            this.grpEvSahibi.Text = "Kendi Takımım";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "ID Giriniz :";
            // 
            // lblEvSahibiIsim
            // 
            this.lblEvSahibiIsim.Location = new System.Drawing.Point(105, 86);
            this.lblEvSahibiIsim.Name = "lblEvSahibiIsim";
            this.lblEvSahibiIsim.Size = new System.Drawing.Size(12, 13);
            this.lblEvSahibiIsim.TabIndex = 3;
            this.lblEvSahibiIsim.Text = "...";
            // 
            // btnEvSahibiEkle
            // 
            this.btnEvSahibiEkle.Location = new System.Drawing.Point(85, 293);
            this.btnEvSahibiEkle.Name = "btnEvSahibiEkle";
            this.btnEvSahibiEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEvSahibiEkle.TabIndex = 2;
            this.btnEvSahibiEkle.Text = "Takımı Onayla";
            this.btnEvSahibiEkle.Click += new System.EventHandler(this.btnEvSahibiEkle_Click);
            // 
            // listEvSahibi
            // 
            this.listEvSahibi.Location = new System.Drawing.Point(59, 129);
            this.listEvSahibi.Name = "listEvSahibi";
            this.listEvSahibi.Size = new System.Drawing.Size(120, 95);
            this.listEvSahibi.TabIndex = 1;
            // 
            // txtEvSahibiID
            // 
            this.txtEvSahibiID.Location = new System.Drawing.Point(85, 51);
            this.txtEvSahibiID.Name = "txtEvSahibiID";
            this.txtEvSahibiID.Size = new System.Drawing.Size(120, 20);
            this.txtEvSahibiID.TabIndex = 0;
            // 
            // grpArkadaslar
            // 
            this.grpArkadaslar.Controls.Add(this.gridArkadaslar);
            this.grpArkadaslar.Location = new System.Drawing.Point(256, 0);
            this.grpArkadaslar.Name = "grpArkadaslar";
            this.grpArkadaslar.Size = new System.Drawing.Size(288, 379);
            this.grpArkadaslar.TabIndex = 1;
            this.grpArkadaslar.Text = "Hızlı Arkadaş Ekle";
            // 
            // gridArkadaslar
            // 
            this.gridArkadaslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridArkadaslar.Location = new System.Drawing.Point(2, 23);
            this.gridArkadaslar.MainView = this.gridView1;
            this.gridArkadaslar.Name = "gridArkadaslar";
            this.gridArkadaslar.Size = new System.Drawing.Size(284, 354);
            this.gridArkadaslar.TabIndex = 0;
            this.gridArkadaslar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridArkadaslar;
            this.gridView1.Name = "gridView1";
            // 
            // grpDeplasman
            // 
            this.grpDeplasman.Controls.Add(this.labelControl4);
            this.grpDeplasman.Controls.Add(this.lblDeplasmanIsim);
            this.grpDeplasman.Controls.Add(this.btnDeplasmanEkle);
            this.grpDeplasman.Controls.Add(this.listDeplasman);
            this.grpDeplasman.Controls.Add(this.txtDeplasmanID);
            this.grpDeplasman.Location = new System.Drawing.Point(548, 0);
            this.grpDeplasman.Name = "grpDeplasman";
            this.grpDeplasman.Size = new System.Drawing.Size(250, 379);
            this.grpDeplasman.TabIndex = 2;
            this.grpDeplasman.Text = "Rakip Takım";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "ID giriniz :";
            // 
            // lblDeplasmanIsim
            // 
            this.lblDeplasmanIsim.Location = new System.Drawing.Point(93, 86);
            this.lblDeplasmanIsim.Name = "lblDeplasmanIsim";
            this.lblDeplasmanIsim.Size = new System.Drawing.Size(12, 13);
            this.lblDeplasmanIsim.TabIndex = 4;
            this.lblDeplasmanIsim.Text = "...";
            // 
            // btnDeplasmanEkle
            // 
            this.btnDeplasmanEkle.Location = new System.Drawing.Point(76, 293);
            this.btnDeplasmanEkle.Name = "btnDeplasmanEkle";
            this.btnDeplasmanEkle.Size = new System.Drawing.Size(75, 23);
            this.btnDeplasmanEkle.TabIndex = 3;
            this.btnDeplasmanEkle.Text = "Takımı Onayla";
            this.btnDeplasmanEkle.Click += new System.EventHandler(this.btnDeplasmanEkle_Click);
            // 
            // listDeplasman
            // 
            this.listDeplasman.Location = new System.Drawing.Point(49, 129);
            this.listDeplasman.Name = "listDeplasman";
            this.listDeplasman.Size = new System.Drawing.Size(120, 95);
            this.listDeplasman.TabIndex = 2;
            // 
            // txtDeplasmanID
            // 
            this.txtDeplasmanID.Location = new System.Drawing.Point(93, 51);
            this.txtDeplasmanID.Name = "txtDeplasmanID";
            this.txtDeplasmanID.Size = new System.Drawing.Size(120, 20);
            this.txtDeplasmanID.TabIndex = 1;
            // 
            // btnMaciOnayla
            // 
            this.btnMaciOnayla.Location = new System.Drawing.Point(348, 400);
            this.btnMaciOnayla.Name = "btnMaciOnayla";
            this.btnMaciOnayla.Size = new System.Drawing.Size(105, 38);
            this.btnMaciOnayla.TabIndex = 4;
            this.btnMaciOnayla.Text = "Onayla Ve Kaydet";
            this.btnMaciOnayla.Click += new System.EventHandler(this.btnMaciOnayla_Click);
            // 
            // cmsKadro
            // 
            this.cmsKadro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kendiTakımımaEkleToolStripMenuItem,
            this.rakipTakımaEkleToolStripMenuItem});
            this.cmsKadro.Name = "cmsKadro";
            this.cmsKadro.Size = new System.Drawing.Size(181, 70);
            // 
            // kendiTakımımaEkleToolStripMenuItem
            // 
            this.kendiTakımımaEkleToolStripMenuItem.Name = "kendiTakımımaEkleToolStripMenuItem";
            this.kendiTakımımaEkleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kendiTakımımaEkleToolStripMenuItem.Text = "Kendi Takımına Ekle";
            this.kendiTakımımaEkleToolStripMenuItem.Click += new System.EventHandler(this.kendiTakımımaEkleToolStripMenuItem_Click);
            // 
            // rakipTakımaEkleToolStripMenuItem
            // 
            this.rakipTakımaEkleToolStripMenuItem.Name = "rakipTakımaEkleToolStripMenuItem";
            this.rakipTakımaEkleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rakipTakımaEkleToolStripMenuItem.Text = "Rakip Takıma Ekle";
            this.rakipTakımaEkleToolStripMenuItem.Click += new System.EventHandler(this.rakipTakımaEkleToolStripMenuItem_Click);
            // 
            // FrmKadroOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMaciOnayla);
            this.Controls.Add(this.grpDeplasman);
            this.Controls.Add(this.grpArkadaslar);
            this.Controls.Add(this.grpEvSahibi);
            this.Name = "FrmKadroOlustur";
            this.Text = "FrmKadroOluştur";
            ((System.ComponentModel.ISupportInitialize)(this.grpEvSahibi)).EndInit();
            this.grpEvSahibi.ResumeLayout(false);
            this.grpEvSahibi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listEvSahibi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEvSahibiID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpArkadaslar)).EndInit();
            this.grpArkadaslar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArkadaslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDeplasman)).EndInit();
            this.grpDeplasman.ResumeLayout(false);
            this.grpDeplasman.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDeplasman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeplasmanID.Properties)).EndInit();
            this.cmsKadro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpEvSahibi;
        private DevExpress.XtraEditors.GroupControl grpArkadaslar;
        private DevExpress.XtraEditors.GroupControl grpDeplasman;
        private DevExpress.XtraEditors.SimpleButton btnEvSahibiEkle;
        private DevExpress.XtraEditors.ListBoxControl listEvSahibi;
        private DevExpress.XtraEditors.TextEdit txtEvSahibiID;
        private DevExpress.XtraEditors.SimpleButton btnDeplasmanEkle;
        private DevExpress.XtraEditors.ListBoxControl listDeplasman;
        private DevExpress.XtraEditors.TextEdit txtDeplasmanID;
        private DevExpress.XtraEditors.SimpleButton btnMaciOnayla;
        private System.Windows.Forms.ContextMenuStrip cmsKadro;
        private System.Windows.Forms.ToolStripMenuItem kendiTakımımaEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rakipTakımaEkleToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblEvSahibiIsim;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblDeplasmanIsim;
        private DevExpress.XtraGrid.GridControl gridArkadaslar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}