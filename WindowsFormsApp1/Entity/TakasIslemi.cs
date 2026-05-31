using System;

namespace WindowsFormsApp1.Entity
{
    public class TakasIslemi
    {
        public int TakasID { get; set; }
        public int VerenKullaniciID { get; set; }
        public int AlanKullaniciID { get; set; }
        public int KitapID { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}