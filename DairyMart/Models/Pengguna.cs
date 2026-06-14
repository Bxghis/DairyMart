using System;
using Npgsql;

namespace DairyMart.Models
{
    public abstract class AkunSistem
    {
        protected Koneksi db = new Koneksi();
        public abstract bool Autentikasi(string identitas, string passwordAman);
    }

    public class Pelanggan : AkunSistem
    {
        public override bool Autentikasi(string inputWa, string passwordAman)
        {
            using (NpgsqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT id_pelanggan, nama_pelanggan FROM pelanggan WHERE no_wa = @nowa AND password = @pass";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nowa", inputWa);
                    cmd.Parameters.AddWithValue("@pass", passwordAman);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SessionData.IdPelangganAktif = Convert.ToInt32(reader["id_pelanggan"]);
                            SessionData.NamaPelangganAktif = reader["nama_pelanggan"].ToString();
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public string DaftarBaru(string nama, string noWa, string passwordAman, string alamat)
        {
            using (NpgsqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO pelanggan (id_area, nama_pelanggan, no_wa, password, alamat_detail) " +
                                   "VALUES (1, @nama, @nowa, @pass, @alamat)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@nowa", noWa);
                        cmd.Parameters.AddWithValue("@pass", passwordAman);
                        cmd.Parameters.AddWithValue("@alamat", alamat);

                        cmd.ExecuteNonQuery();
                        return "SUKSES";
                    }
                }
                catch (Exception)
                {
                    return "Gagal mendaftar! Mungkin Nomor WA tersebut sudah pernah digunakan.";
                }
            }
        }
    }
}