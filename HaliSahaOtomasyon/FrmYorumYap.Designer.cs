namespace HaliSahaOtomasyon
{
    partial class FrmYorumYap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYorumYap));
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.ratingPuan = new DevExpress.XtraEditors.RatingControl();
            this.YrmBaşlık = new DevExpress.XtraEditors.LabelControl();
            this.txtYorum = new DevExpress.XtraEditors.MemoEdit();
            this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ratingPuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYorum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.BackColor = System.Drawing.Color.LightCoral;
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBaslik.Appearance.Options.UseBackColor = true;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(12, 3);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(155, 19);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Deneyiminizi Puanlayın";
            // 
            // ratingPuan
            // 
            this.ratingPuan.Location = new System.Drawing.Point(12, 28);
            this.ratingPuan.Name = "ratingPuan";
            this.ratingPuan.Size = new System.Drawing.Size(92, 16);
            this.ratingPuan.TabIndex = 1;
            this.ratingPuan.Text = "ratingControl1";
            // 
            // YrmBaşlık
            // 
            this.YrmBaşlık.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.YrmBaşlık.Appearance.Options.UseFont = true;
            this.YrmBaşlık.Location = new System.Drawing.Point(12, 50);
            this.YrmBaşlık.Name = "YrmBaşlık";
            this.YrmBaşlık.Size = new System.Drawing.Size(103, 19);
            this.YrmBaşlık.TabIndex = 2;
            this.YrmBaşlık.Text = "Yorumunuz :";
            // 
            // txtYorum
            // 
            this.txtYorum.Location = new System.Drawing.Point(15, 75);
            this.txtYorum.Name = "txtYorum";
            this.txtYorum.Properties.NullText = "Düşüncelerinizi Buraya Yazınız";
            this.txtYorum.Size = new System.Drawing.Size(212, 96);
            this.txtYorum.TabIndex = 3;
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGonder.ImageOptions.SvgImage")));
            this.btnGonder.Location = new System.Drawing.Point(79, 177);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(88, 29);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // FrmYorumYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 601);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtYorum);
            this.Controls.Add(this.YrmBaşlık);
            this.Controls.Add(this.ratingPuan);
            this.Controls.Add(this.lblBaslik);
            this.Name = "FrmYorumYap";
            this.ShowIcon = false;
            this.Text = "FrmYorumYap";
            ((System.ComponentModel.ISupportInitialize)(this.ratingPuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYorum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.RatingControl ratingPuan;
        private DevExpress.XtraEditors.LabelControl YrmBaşlık;
        private DevExpress.XtraEditors.MemoEdit txtYorum;
        private DevExpress.XtraEditors.SimpleButton btnGonder;
    }
}