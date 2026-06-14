using DairyMart.Models;
using Npgsql;
using System;
using System.Data;

namespace DairyMart.Controllers
{
    public class AdminController
    {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=DairyMart9";

        public DataTable GetStokOnline()
        {
            DataTable dt = new DataTable();
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    // PERHATIKAN: Sekarang kita manggil stok_online dan stok_offline!
                    string query = "SELECT id_produk, nama_produk, stok_online, stok_offline, status_kelayakan, tgl_kadaluarsa FROM produk ORDER BY id_produk ASC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dt.Columns.Add("Error");
                    dt.Rows.Add(ex.Message);
                }
            }
            return dt;
        }

        public string TambahStokProduk(int idProduk, int qtyTambah)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    // FIX: Nama kolomnya 'stok', bukan 'jumlah' ya bray!
                    string query = "UPDATE produk SET stok = stok + @qty WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", qtyTambah);
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.ExecuteNonQuery();
                        return "SUKSES";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public DataTable GetRiwayatTransaksi()
        {
            DataTable dt = new DataTable();
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    // INI YANG BIKIN ERROR TADI, SEKARANG KITA UBAH MANGGIL VIEW!
                    string query = "SELECT * FROM v_riwayat_global ORDER BY tanggal DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader()) { dt.Load(reader); }
                    }
                }
                catch (Exception ex) { dt.Columns.Add("Error"); dt.Rows.Add(ex.Message); }
            }
            return dt;
        }

        public string UpdateProduk(int idProduk, string nama, int harga, int stokOnline, string status)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    // FILTER: UPDATE-nya cuma nembak ke stok_online!
                    string query = "UPDATE produk SET nama_produk = @nama, harga = @harga, stok_online = @stokOnline, status_kelayakan = @status WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@stokOnline", stokOnline);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
                catch (Exception ex)
                {
                    return "Gagal Update: " + ex.Message;
                }
            }
        }

        public string HapusProduk(int idProduk)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM produk WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState == "23503")
                    {
                        return "Produk tidak bisa dihapus karena sudah ada riwayat transaksinya oleh pelanggan!";
                    }
                    return "Error DB: " + ex.Message;
                }
            }
        }

        public string TambahProdukBaru(string nama, int stokOnline, string status, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    // FILTER: Kolomnya kita ganti jadi stok_online aja bray!
                    string query = @"INSERT INTO produk 
                     (id_kategori, nama_produk, ukuran, harga, stok_online, tgl_kadaluarsa, status_kelayakan) 
                     VALUES 
                     (1, @nama, 'Default', 25000, @stokOnline, @tgl, @status)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@stokOnline", stokOnline); // Masuk ke gudang online
                        cmd.Parameters.AddWithValue("@status", status);

                        DateTime parsedDate;
                        if (DateTime.TryParse(tglKadaluarsa, out parsedDate))
                        {
                            cmd.Parameters.AddWithValue("@tgl", parsedDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@tgl", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
                catch (Exception ex)
                {
                    return "Gagal Bikin Produk: " + ex.Message;
                }
            }
        }
    }
}