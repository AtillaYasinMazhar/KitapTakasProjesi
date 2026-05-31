using System;
using System.Data;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
    public class TakasIslemiDAL
    {
        private string connString = "Server=127.0.0.1;Database=KitapTakasDB;Uid=takas_user;Pwd=Proje123!;";

        public void Ekle(TakasIslemi t)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_TakasEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Veren", t.VerenKullaniciID);
                cmd.Parameters.AddWithValue("p_Alan", t.AlanKullaniciID);
                cmd.Parameters.AddWithValue("p_Kitap", t.KitapID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_TakasSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(TakasIslemi t)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_TakasGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", t.TakasID);
                cmd.Parameters.AddWithValue("p_Veren", t.VerenKullaniciID);
                cmd.Parameters.AddWithValue("p_Alan", t.AlanKullaniciID);
                cmd.Parameters.AddWithValue("p_Kitap", t.KitapID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_TakasListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}