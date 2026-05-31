using System;
using System.Data;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
    public class KullaniciDAL
    {
        private string connString = "Server=127.0.0.1;Database=KitapTakasDB;Uid=takas_user;Pwd=Proje123!;";

        public void Ekle(Kullanici k)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KullaniciEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_AdSoyad", k.AdSoyad);
                cmd.Parameters.AddWithValue("p_Email", k.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KullaniciSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(Kullanici k)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KullaniciGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ID", k.KullaniciID);
                cmd.Parameters.AddWithValue("p_AdSoyad", k.AdSoyad);
                cmd.Parameters.AddWithValue("p_Email", k.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_KullaniciListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}