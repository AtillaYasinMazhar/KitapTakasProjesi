using System;
using System.Data;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BL
{
    public class KullaniciBL
    {
        KullaniciDAL dal = new KullaniciDAL();

        public bool Ekle(Kullanici k)
        {
            if (!string.IsNullOrEmpty(k.AdSoyad) && !string.IsNullOrEmpty(k.Email))
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

        public bool Guncelle(Kullanici k)
        {
            if (k.KullaniciID > 0 && !string.IsNullOrEmpty(k.AdSoyad) && !string.IsNullOrEmpty(k.Email))
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