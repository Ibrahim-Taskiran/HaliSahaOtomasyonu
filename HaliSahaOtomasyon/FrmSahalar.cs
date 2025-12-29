using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Card; // CardView kütüphanesi eklendi

namespace HaliSahaOtomasyon
{
    public partial class FrmSahalar : Form
    {
        public FrmSahalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void SahalariListele()
        {
            // Verileri çek
            string sorgu = "SELECT SahaID, TesisAdi, SahaTanimi, CimTuru, Boyutlar FROM Sahalar";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Veriyi GridControl'e bağla
            gridSaha.DataSource = dt;
            // NOT: Tasarımda GridControl'ün Adı 'gridSaha' veya 'gridControl1' neyse onu kullan.
            // Eğer hata verirse burayı 'gridControl1' yap.
        }

        private void FrmSahalar_Load(object sender, EventArgs e)
        {
            SahalariListele();

            // --- GÖRSEL AYARLAR (KOD İLE) ---

            // CardView'da GroupPanel kapatmak için:
            

            // Kart başlığını kapatmak için (Record 1 yazısı):
            cardView1.OptionsView.ShowCardCaption = false;

            // Kart genişliği (Bu özellik OptionsView altında değil, direkt View üstündedir veya OptionsBehavior'dadır)
            // Eğer kodla hata verirse burayı silip tasarım ekranından yaparız.
            // cardView1.CardWidth = 300; // Hata verirse bu satırı sil.
        }

        // ÇİFT TIKLAMA OLAYI (GÜNCELLENDİ)
        private void cardView1_DoubleClick(object sender, EventArgs e)
        {
            // Tıklanan kartın verisini almak için CardView kullanılır
            CardView view = (CardView)sender;

            // Seçili satırın verisini al
            // CardView'da 'GetFocusedDataRow' kullanılır
            DataRow dr = view.GetDataRow(view.FocusedRowHandle);

            if (dr != null)
            {
                FrmRandevuAl fr = new FrmRandevuAl();
                fr.gelenSahaID = int.Parse(dr["SahaID"].ToString());
                fr.Show();
            }
        }
    }
}