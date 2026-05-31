using WindowsFormsApp1.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace WindowsFormsApp1.DAL
{
    public class KitapDAL
    {
        private string connString = "Server=127.0.0.1;Database=KitapTakasDB;Uid=takas_user;Pwd=Proje123!;";

        public void Ekle(Kitap k)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KitapEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_KulID", k.KullaniciID);
                cmd.Parameters.AddWithValue("p_Ad", k.KitapAdi);
                cmd.Parameters.AddWithValue("p_Yazar", k.Yazar);
                cmd.Parameters.AddWithValue("p_Yil", k.BasimYili);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KitapSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(Kitap k)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KitapGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", k.KitapID);
                cmd.Parameters.AddWithValue("p_Ad", k.KitapAdi);
                cmd.Parameters.AddWithValue("p_Yazar", k.Yazar);
                cmd.Parameters.AddWithValue("p_Yil", k.BasimYili);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KitapListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}