using System;
using Npgsql;
using DairyMart.Models;

namespace DairyMart.Controllers
{
    public class LoginController
    {

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

                    string query = "SELECT id_pelanggan, nama_pelanggan, role FROM pelanggan WHERE no_wa = @wa AND password = @password";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("wa", wa);
                        cmd.Parameters.AddWithValue("password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Kalau akunnya ketemu di database
                            {
                                SessionData.IdPelangganAktif = Convert.ToInt32(reader["id_pelanggan"]);
                                SessionData.NamaPelangganAktif = reader["nama_pelanggan"].ToString();

                       
                                return reader["role"].ToString();
                            }
                            else
                            {
                                return "GAGAL";
                            }
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