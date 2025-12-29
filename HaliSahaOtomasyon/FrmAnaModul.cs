using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace HaliSahaOtomasyon
{
    public partial class FrmAnaModul : RibbonForm
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        // --- KULLANICI BİLGİSİ ALMA ---
        public void KullaniciBilgisiAl(string adSoyad, int id)
        {
            // Sağ üstteki bilgi kutusuna yaz (Eğer Ribbon üzerinde böyle bir label varsa)
            if (txtKullaniciBilgi != null)
            {
                txtKullaniciBilgi.Caption = $"{adSoyad}  (ID: {id})";
            }
            // ID'yi arka planda sakla
            this.Tag = id;
        }

        // --- ORTAK FORM AÇMA METODU (MDI CHILD KONTROLÜ) ---
        // Bu metot, formun ikinci kez açılmasını engeller, varsa öne getirir.
        private void FormGetir(Form fr)
        {
            bool acikMi = false;

            // 1. Zaten açık mı diye bak
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() == fr.GetType())
                {
                    item.Activate(); // Varsa öne getir
                    acikMi = true;
                    fr.Dispose();    // Yeni oluşturulanı bellekten sil
                    break;
                }
            }

            // 2. Açık değilse yeni aç
            if (acikMi == false)
            {
                fr.MdiParent = this; // Ana formun içinde aç
                fr.WindowState = FormWindowState.Maximized;
                fr.Show();
            }
        }

        // --- FORM YÜKLENİRKEN ---
        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            // Açılışta direkt Ana Sayfa gelsin
            FormGetir(new FrmAnasayfa());
        }

        // --- BUTON TIKLAMALARI ---

        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormGetir(new FrmAnasayfa());
        }

        private void btnRandevular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormGetir(new FrmRandevuAl());
        }

        private void btnMaclarim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormGetir(new FrmMaclarim());
        }

        private void btnHalisahalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormGetir(new FrmSahalar());
        }

        private void btnProfilim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // DÜZELTME: Burası da artık standart metoda bağlandı.
            FormGetir(new FrmProfil());
        }

        private void btnBahisformu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Bahis formunu aç
            FormGetir(new FrmBahis());
        }

        private void btnCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult onay = MessageBox.Show("Sistemden çıkış yapmak istediğinize emin misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                FrmGiris fr = new FrmGiris();
                fr.Show();
                this.Close();
            }
        }
    }
}