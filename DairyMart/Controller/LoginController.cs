using System;
using Npgsql;
using DairyMart.Models; // Memanggil folder Models untuk class Koneksi

namespace DairyMart.Controllers
{
    public class LoginController
    {
        // Fungsi ini sekarang mengembalikan Role (Admin / Pelanggan) jika sukses, 
        // atau kata "GAGAL" / pesan error jika gagal.
        public string ProsesLogin(string wa, string password)
        {
            if (string.IsNullOrWhiteSpace(wa) || string.IsNullOrWhiteSpace(password))
            {
                return "KOSONG";
            }

            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT role FROM pelanggan WHERE no_wa = @wa AND password = @password";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("wa", wa);
                        cmd.Parameters.AddWithValue("password", password);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return "GAGAL";
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Error Database: " + ex.Message;
                }
            }
        }
    }
}