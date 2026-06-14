using System;
using System.Data;
using Npgsql;
using DairyMart.Models;

namespace DairyMart.Controllers
{
    public class AdminController
    {

        public DataTable GetStokOnline()
        {
            DataTable dt = new DataTable();
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM v_stok_gudang ORDER BY id_produk ASC";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader()) { dt.Load(reader); }
                    }
                }
                catch (Exception ex) { dt.Columns.Add("Error"); dt.Rows.Add(ex.Message); }
            }
            return dt;
        }

        public DataTable GetRiwayatTransaksi()
        {
            DataTable dt = new DataTable();
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
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


        public string TambahProdukBaru(string nama, int stokOnline, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO produk 
                             (id_kategori, nama_produk, ukuran, harga, stok_online, stok_offline, tgl_kadaluarsa) 
                             VALUES 
                             (1, @nama, 'Default', 25000, @stokOnline, 0, @tgl)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@stokOnline", stokOnline);

                        DateTime parsedDate;
                        if (DateTime.TryParse(tglKadaluarsa, out parsedDate)) { cmd.Parameters.AddWithValue("@tgl", parsedDate); }
                        else { cmd.Parameters.AddWithValue("@tgl", DBNull.Value); }

                        cmd.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
                catch (Exception ex) { return "Gagal Bikin Produk: " + ex.Message; }
            }
        }

        public string UpdateProduk(int idProduk, string nama, int harga, int stokOnline, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE produk SET nama_produk = @nama, harga = @harga, stok_online = @stokOnline, tgl_kadaluarsa = @tgl WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@stokOnline", stokOnline);

                        DateTime parsedDate;
                        if (DateTime.TryParse(tglKadaluarsa, out parsedDate)) { cmd.Parameters.AddWithValue("@tgl", parsedDate); }
                        else { cmd.Parameters.AddWithValue("@tgl", DBNull.Value); }

                        cmd.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
                catch (Exception ex) { return "Gagal Update: " + ex.Message; }
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
                catch (Exception ex) { return "Gagal Hapus: " + ex.Message; }
            }
        }
    }
}