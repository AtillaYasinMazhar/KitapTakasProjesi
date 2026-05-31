using System.Data;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BL
{
    public class TakasIslemiBL
    {
        TakasIslemiDAL dal = new TakasIslemiDAL();

        public bool Ekle(TakasIslemi t)
        {
            if (t.VerenKullaniciID > 0 && t.AlanKullaniciID > 0 && t.KitapID > 0)
            {
                dal.Ekle(t);
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

        public bool Guncelle(TakasIslemi t)
        {
            if (t.TakasID > 0 && t.VerenKullaniciID > 0)
            {
                dal.Guncelle(t);
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