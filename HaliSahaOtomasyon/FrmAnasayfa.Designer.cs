namespace HaliSahaOtomasyon
{
    partial class FrmAnasayfa
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
            this.gridArkadaslar = new DevExpress.XtraGrid.GridControl();
            this.gridViewArkadaslar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRatingControl2 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.gridIstekler = new DevExpress.XtraGrid.GridControl();
            this.gridViewIstekler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridFikstur = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.cmsArkadas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.arkadaşlıktanÇıkarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbArama = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridAramaSonuclari = new DevExpress.XtraGrid.GridControl();
            this.gridViewAramaSonuclari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sehir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Mevki = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrtalamaPuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRatingControl3 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.IstekGonder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPuanFiltre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMevkiFiltre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSehirFiltre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtArama = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArkadaslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewArkadaslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIstekler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIstekler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFikstur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.cmsArkadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbArama)).BeginInit();
            this.grbArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAramaSonuclari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAramaSonuclari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPuanFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMevkiFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSehirFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridArkadaslar);
            this.groupControl1.Controls.Add(this.gridIstekler);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(388, 802);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Takım Arkadaşlarım";
            // 
            // gridArkadaslar
            // 
            this.gridArkadaslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridArkadaslar.Location = new System.Drawing.Point(2, 153);
            this.gridArkadaslar.MainView = this.gridViewArkadaslar;
            this.gridArkadaslar.Name = "gridArkadaslar";
            this.gridArkadaslar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl1,
            this.repositoryItemRatingControl2});
            this.gridArkadaslar.Size = new System.Drawing.Size(384, 647);
            this.gridArkadaslar.TabIndex = 1;
            this.gridArkadaslar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewArkadaslar});
            this.gridArkadaslar.DoubleClick += new System.EventHandler(this.gridViewArkadaslar_DoubleClick);
            // 
            // gridViewArkadaslar
            // 
            this.gridViewArkadaslar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.gridViewArkadaslar.GridControl = this.gridArkadaslar;
            this.gridViewArkadaslar.Name = "gridViewArkadaslar";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Genel Puan";
            this.gridColumn1.ColumnEdit = this.repositoryItemRatingControl1;
            this.gridColumn1.FieldName = "OrtalamaPuan";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            this.repositoryItemRatingControl1.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Arkadaş Adı ";
            this.gridColumn3.FieldName = "Arkadaş";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // repositoryItemRatingControl2
            // 
            this.repositoryItemRatingControl2.AutoHeight = false;
            this.repositoryItemRatingControl2.Name = "repositoryItemRatingControl2";
            // 
            // gridIstekler
            // 
            this.gridIstekler.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridIstekler.Location = new System.Drawing.Point(2, 23);
            this.gridIstekler.MainView = this.gridViewIstekler;
            this.gridIstekler.Name = "gridIstekler";
            this.gridIstekler.Size = new System.Drawing.Size(384, 130);
            this.gridIstekler.TabIndex = 0;
            this.gridIstekler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIstekler});
            // 
            // gridViewIstekler
            // 
            this.gridViewIstekler.GridControl = this.gridIstekler;
            this.gridViewIstekler.Name = "gridViewIstekler";
            // 
            // gridFikstur
            // 
            this.gridFikstur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFikstur.Location = new System.Drawing.Point(2, 285);
            this.gridFikstur.MainView = this.gridView1;
            this.gridFikstur.Name = "gridFikstur";
            this.gridFikstur.Size = new System.Drawing.Size(381, 515);
            this.gridFikstur.TabIndex = 0;
            this.gridFikstur.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridFikstur;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridFikstur);
            this.groupControl2.Controls.Add(this.chartControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(1428, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(385, 802);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Performansım";
            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartControl1.Location = new System.Drawing.Point(2, 23);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(381, 262);
            this.chartControl1.TabIndex = 0;
            // 
            // cmsArkadas
            // 
            this.cmsArkadas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arkadaşlıktanÇıkarToolStripMenuItem});
            this.cmsArkadas.Name = "cmsArkadas";
            this.cmsArkadas.Size = new System.Drawing.Size(176, 26);
            // 
            // arkadaşlıktanÇıkarToolStripMenuItem
            // 
            this.arkadaşlıktanÇıkarToolStripMenuItem.Name = "arkadaşlıktanÇıkarToolStripMenuItem";
            this.arkadaşlıktanÇıkarToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.arkadaşlıktanÇıkarToolStripMenuItem.Text = "Arkadaşlıktan Çıkar";
            this.arkadaşlıktanÇıkarToolStripMenuItem.Click += new System.EventHandler(this.arkadaşlıktanÇıkarToolStripMenuItem_Click);
            // 
            // grbArama
            // 
            this.grbArama.Controls.Add(this.btnAra);
            this.grbArama.Controls.Add(this.labelControl3);
            this.grbArama.Controls.Add(this.txtArama);
            this.grbArama.Controls.Add(this.gridAramaSonuclari);
            this.grbArama.Controls.Add(this.labelControl2);
            this.grbArama.Controls.Add(this.cmbPuanFiltre);
            this.grbArama.Controls.Add(this.cmbSehirFiltre);
            this.grbArama.Controls.Add(this.cmbMevkiFiltre);
            this.grbArama.Controls.Add(this.labelControl1);
            this.grbArama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbArama.Location = new System.Drawing.Point(388, 0);
            this.grbArama.Name = "grbArama";
            this.grbArama.Size = new System.Drawing.Size(1040, 802);
            this.grbArama.TabIndex = 2;
            this.grbArama.Text = "Oyuncu Arama";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(660, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 19);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Puan Filtrele :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(399, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(122, 19);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Mevki Filtrele :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(159, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 19);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Şehir Filtrele :";
            // 
            // gridAramaSonuclari
            // 
            this.gridAramaSonuclari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAramaSonuclari.Location = new System.Drawing.Point(0, 102);
            this.gridAramaSonuclari.MainView = this.gridViewAramaSonuclari;
            this.gridAramaSonuclari.Name = "gridAramaSonuclari";
            this.gridAramaSonuclari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl3,
            this.repositoryItemButtonEdit1});
            this.gridAramaSonuclari.Size = new System.Drawing.Size(1043, 700);
            this.gridAramaSonuclari.TabIndex = 5;
            this.gridAramaSonuclari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAramaSonuclari});
            // 
            // gridViewAramaSonuclari
            // 
            this.gridViewAramaSonuclari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UserId,
            this.AdSoyad,
            this.Sehir,
            this.Mevki,
            this.OrtalamaPuan,
            this.IstekGonder});
            this.gridViewAramaSonuclari.GridControl = this.gridAramaSonuclari;
            this.gridViewAramaSonuclari.Name = "gridViewAramaSonuclari";
            // 
            // UserId
            // 
            this.UserId.Caption = "ID";
            this.UserId.FieldName = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = true;
            this.UserId.VisibleIndex = 0;
            // 
            // AdSoyad
            // 
            this.AdSoyad.Caption = "Ad-Soyad";
            this.AdSoyad.FieldName = "AsSoyad";
            this.AdSoyad.Name = "AdSoyad";
            this.AdSoyad.Visible = true;
            this.AdSoyad.VisibleIndex = 1;
            // 
            // Sehir
            // 
            this.Sehir.Caption = "Şehir";
            this.Sehir.FieldName = "Sehir";
            this.Sehir.Name = "Sehir";
            this.Sehir.Visible = true;
            this.Sehir.VisibleIndex = 2;
            // 
            // Mevki
            // 
            this.Mevki.Caption = "MEVKİ";
            this.Mevki.FieldName = "Mevki";
            this.Mevki.Name = "Mevki";
            this.Mevki.Visible = true;
            this.Mevki.VisibleIndex = 3;
            // 
            // OrtalamaPuan
            // 
            this.OrtalamaPuan.Caption = "PUAN";
            this.OrtalamaPuan.ColumnEdit = this.repositoryItemRatingControl3;
            this.OrtalamaPuan.FieldName = "OrtalamaPuan";
            this.OrtalamaPuan.Name = "OrtalamaPuan";
            this.OrtalamaPuan.Visible = true;
            this.OrtalamaPuan.VisibleIndex = 4;
            // 
            // repositoryItemRatingControl3
            // 
            this.repositoryItemRatingControl3.AutoHeight = false;
            this.repositoryItemRatingControl3.Name = "repositoryItemRatingControl3";
            this.repositoryItemRatingControl3.ReadOnly = true;
            // 
            // IstekGonder
            // 
            this.IstekGonder.Caption = "Ekle";
            this.IstekGonder.ColumnEdit = this.repositoryItemButtonEdit1;
            this.IstekGonder.FieldName = "IstekGonder";
            this.IstekGonder.Name = "IstekGonder";
            this.IstekGonder.Visible = true;
            this.IstekGonder.VisibleIndex = 5;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(934, 52);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 23);
            this.btnAra.TabIndex = 4;
            this.btnAra.Text = "Ara";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // cmbPuanFiltre
            // 
            this.cmbPuanFiltre.Location = new System.Drawing.Point(781, 55);
            this.cmbPuanFiltre.Name = "cmbPuanFiltre";
            this.cmbPuanFiltre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPuanFiltre.Size = new System.Drawing.Size(100, 20);
            this.cmbPuanFiltre.TabIndex = 3;
            // 
            // cmbMevkiFiltre
            // 
            this.cmbMevkiFiltre.Location = new System.Drawing.Point(527, 55);
            this.cmbMevkiFiltre.Name = "cmbMevkiFiltre";
            this.cmbMevkiFiltre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMevkiFiltre.Size = new System.Drawing.Size(100, 20);
            this.cmbMevkiFiltre.TabIndex = 2;
            // 
            // cmbSehirFiltre
            // 
            this.cmbSehirFiltre.Location = new System.Drawing.Point(281, 55);
            this.cmbSehirFiltre.Name = "cmbSehirFiltre";
            this.cmbSehirFiltre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSehirFiltre.Size = new System.Drawing.Size(100, 20);
            this.cmbSehirFiltre.TabIndex = 1;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(44, 55);
            this.txtArama.Name = "txtArama";
            this.txtArama.Properties.NullText = "İsim veya ID";
            this.txtArama.Size = new System.Drawing.Size(78, 20);
            this.txtArama.TabIndex = 0;
            // 
            // FrmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1813, 802);
            this.Controls.Add(this.grbArama);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnasayfa";
            this.ShowIcon = false;
            this.Text = "Anasayfa Dashboard";
            this.Load += new System.EventHandler(this.FrmAnasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArkadaslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewArkadaslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIstekler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIstekler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFikstur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.cmsArkadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbArama)).EndInit();
            this.grbArama.ResumeLayout(false);
            this.grbArama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAramaSonuclari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAramaSonuclari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPuanFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMevkiFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSehirFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArama.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridFikstur;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraGrid.GridControl gridArkadaslar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewArkadaslar;
        private DevExpress.XtraGrid.GridControl gridIstekler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewIstekler;
        private System.Windows.Forms.ContextMenuStrip cmsArkadas;
        private System.Windows.Forms.ToolStripMenuItem arkadaşlıktanÇıkarToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl2;
        private DevExpress.XtraEditors.GroupControl grbArama;
        private DevExpress.XtraEditors.TextEdit txtArama;
        private DevExpress.XtraGrid.GridControl gridAramaSonuclari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAramaSonuclari;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPuanFiltre;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMevkiFiltre;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSehirFiltre;
        private DevExpress.XtraGrid.Columns.GridColumn UserId;
        private DevExpress.XtraGrid.Columns.GridColumn AdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn Sehir;
        private DevExpress.XtraGrid.Columns.GridColumn Mevki;
        private DevExpress.XtraGrid.Columns.GridColumn OrtalamaPuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl3;
        private DevExpress.XtraGrid.Columns.GridColumn IstekGonder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}