using System;
using Npgsql;
using DairyMart.Models;

namespace DairyMart.Controllers
{
    public class RegistrasiController
    {
        public string ProsesRegistrasi(string nama, string wa, string password, string alamat, string role)
        {
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(wa) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(alamat) ||
                string.IsNullOrWhiteSpace(role))
            {
                return "Semua kolom dan Role wajib diisi!";
            }

            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO pelanggan (id_area, nama_pelanggan, no_wa, password, alamat_detail, role) VALUES (1, @nama, @wa, @password, @alamat, @role)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nama", nama);
                        cmd.Parameters.AddWithValue("wa", wa);

                        cmd.Parameters.AddWithValue("password", password);

                        cmd.Parameters.AddWithValue("alamat", alamat);
                        cmd.Parameters.AddWithValue("role", role);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            return "SUKSES";
                        else
                            return "Gagal menyimpan data ke database.";
                    }
                }
                catch (PostgresException pgEx)
                {
                    if (pgEx.SqlState == "23505")
                        return "Nomor WA tersebut sudah terdaftar! Silakan gunakan nomor lain.";

                    return "Error Database: " + pgEx.MessageText;
                }
                catch (Exception ex)
                {
                    return "Koneksi Error: " + ex.Message;
                }
            }
        }
    }
}