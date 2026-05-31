using System.Data;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BL
{
    public class KitapBL
    {
        KitapDAL dal = new KitapDAL();

        public bool Ekle(Kitap k)
        {
            if (k.KullaniciID > 0 && !string.IsNullOrEmpty(k.KitapAdi) && !string.IsNullOrEmpty(k.Yazar))
            {
                dal.Ekle(k);
                return true;
            }
            return false;
        }

        public bool Sil(int id)
        {
            if (id > 0)
            {
                dal.Sil(id);
                return true;
            }
            return false;
        }

        public bool Guncelle(Kitap k)
        {
            if (k.KitapID > 0 && !string.IsNullOrEmpty(k.KitapAdi))
            {
                dal.Guncelle(k);
                return true;
            }
            return false;
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}
