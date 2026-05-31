namespace WindowsFormsApp1.Entity
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public int KullaniciID { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string Durum { get; set; }
        public int BasimYili { get; set; }
    }
}
