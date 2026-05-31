using System;
using System.Windows.Forms;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        KullaniciBL bl = new KullaniciBL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = bl.Listele();
        }
        private void KitaplariListele()
        {
            WindowsFormsApp1.BL.KitapBL kitapBl = new WindowsFormsApp1.BL.KitapBL();
            dataGridViewKitaplar.DataSource = kitapBl.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.AdSoyad = textBoxAd.Text;
            k.Email = textBoxEmail.Text;

            bl.Ekle(k);
            Listele();
            MessageBox.Show("Başarıyla eklendi! (Trigger çalışarak 5 takas kredisi verdi)");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);
                bl.Sil(id);
                Listele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Kullanici k = new Kullanici();
                k.KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);
                k.AdSoyad = textBoxAd.Text;
                k.Email = textBoxEmail.Text;

                bl.Guncelle(k);
                Listele();
            }
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.AdSoyad = textBoxAd.Text;
            k.Email = textBoxEmail.Text;

            bl.Ekle(k);
            Listele();
            MessageBox.Show("Başarıyla eklendi! Veritabanı Trigger'ı çalıştı.");
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);
                bl.Sil(id);
                Listele();
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Kullanici k = new Kullanici();
                k.KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);
                k.AdSoyad = textBoxAd.Text;
                k.Email = textBoxEmail.Text;

                bl.Guncelle(k);
                Listele();
            }
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int seciliKullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KullaniciID"].Value);

                WindowsFormsApp1.Entity.Kitap k = new WindowsFormsApp1.Entity.Kitap();
                k.KullaniciID = seciliKullaniciID;
                k.KitapAdi = txtKitapAd.Text;
                k.Yazar = txtYazar.Text;
                k.BasimYili = Convert.ToInt32(txtBasimYili.Text);

                WindowsFormsApp1.BL.KitapBL kitapBl = new WindowsFormsApp1.BL.KitapBL();
                kitapBl.Ekle(k);

                Listele();
                MessageBox.Show("Kitap arayüzden başarıyla eklendi! Veritabanı bunu algılayıp Trigger'ı çalıştırdı ve takas kredini 5 artırdı!");
            }
            else
            {
                MessageBox.Show("Lütfen önce tablodan kitabı ekleyecek kullanıcıyı seçin.");
            }
            KitaplariListele();
        }

        private void btnTakasYap_Click(object sender, EventArgs e)
        {
            try
            {
                // Arayüzdeki kutulardan verileri alıyoruz
                WindowsFormsApp1.Entity.TakasIslemi t = new WindowsFormsApp1.Entity.TakasIslemi();
                t.VerenKullaniciID = Convert.ToInt32(txtVerenID.Text);
                t.AlanKullaniciID = Convert.ToInt32(txtAlanID.Text);
                t.KitapID = Convert.ToInt32(txtKitapID.Text);

                // BL katmanı üzerinden veritabanına gönderiyoruz
                WindowsFormsApp1.BL.TakasIslemiBL takasBl = new WindowsFormsApp1.BL.TakasIslemiBL();
                takasBl.Ekle(t);

                MessageBox.Show("Takas işlemi başarıyla gerçekleşti! Arka plandaki Trigger çalıştı ve kitabın durumu 'Takaslandı' olarak güncellendi.");
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu. Lütfen ID'leri rakam olarak doğru girdiğinizden emin olun: " + ex.Message);
            }
        }

    }
}
