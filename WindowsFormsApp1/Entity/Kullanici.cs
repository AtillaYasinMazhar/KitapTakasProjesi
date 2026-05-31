using System;

namespace WindowsFormsApp1.Entity
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public int TakasKredisi { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}