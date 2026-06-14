using System;
using System.Data;
using Npgsql;

namespace DairyMart.Models
{
    public class Produk
    {
        private Koneksi db = new Koneksi();

        public DataTable AmbilDataKatalog()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"SELECT p.id_produk, k.nama_kategori, p.nama_produk, p.ukuran, p.harga, p.stok 
                                 FROM produk p 
                                 JOIN kategori_produk k ON p.id_kategori = k.id_kategori
                                 WHERE p.stok > 0 AND p.status_kelayakan != 'Kadaluarsa'";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public string CheckoutProdukDatabase(int idPelanggan, int idProduk, int idMetode, int qty, int totalBayar)
        {
            using (NpgsqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Tambahkan @p_qty ke dalam kurung CALL
                    string query = "CALL sp_checkout_langganan(@p_pel, @p_prod, @p_metode, @p_qty, @p_total)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@p_pel", idPelanggan);
                        cmd.Parameters.AddWithValue("@p_prod", idProduk);
                        cmd.Parameters.AddWithValue("@p_metode", idMetode);
                        cmd.Parameters.AddWithValue("@p_qty", qty); // Ini sesajen ke-5 (Jumlah Beli) yang diminta PostgreSQL
                        cmd.Parameters.AddWithValue("@p_total", totalBayar);

                        cmd.ExecuteNonQuery();
                        return "SUKSES";
                    }
                }
                catch (Exception ex)
                {
                    return "Database Error: " + ex.Message;
                }
            }
        }
    }
}