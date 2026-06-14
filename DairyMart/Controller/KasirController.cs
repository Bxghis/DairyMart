using System;
using System.Data;
using Npgsql;
using DairyMart.Models;

namespace DairyMart.Controllers
{
    public class KasirController
    {
        public DataTable GetStokOffline()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new Koneksi().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id_produk, nama_produk, stok_offline, tgl_kadaluarsa, status_kelayakan FROM produk ORDER BY id_produk ASC";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt.Columns.Add("Error"); dt.Rows.Add(ex.Message); }
            return dt;
        }

        public string TambahProdukOffline(string nama, int stokOffline, string status, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO produk 
                             (id_kategori, nama_produk, ukuran, harga, stok_offline, stok_online, tgl_kadaluarsa, status_kelayakan) 
                             VALUES 
                             (1, @nama, 'Default', 25000, @stokOffline, 0, @tgl, @status)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@stokOffline", stokOffline);
                        cmd.Parameters.AddWithValue("@status", status);

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

        public string UpdateProdukOffline(int idProduk, string nama, int stokOffline, string status, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE produk SET nama_produk = @nama, stok_offline = @stokOffline, status_kelayakan = @status, tgl_kadaluarsa = @tgl WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@stokOffline", stokOffline);
                        cmd.Parameters.AddWithValue("@status", status);

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

        public string HapusProdukOffline(int idProduk)
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
                    if (ex.SqlState == "23503") { return "Gagal: Produk ini udah ada riwayat penjualannya!"; }
                    return "Error DB: " + ex.Message;
                }
            }
        }

        public string SimpanTransaksiOffline(int idProduk, int qty, int total)
        {
            try
            {
                using (var conn = new Koneksi().GetConnection())
                {
                    conn.Open();
                    string queryUpdate = "UPDATE produk SET stok_offline = stok_offline - @qty WHERE id_produk = @id_prod";
                    using (var cmdUpdate = new NpgsqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@qty", qty);
                        cmdUpdate.Parameters.AddWithValue("@id_prod", idProduk);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    string queryInsert = "INSERT INTO transaksi_offline (id_produk, kuantitas, total_harga, tgl_transaksi) " +
                                         "VALUES (@id_prod, @qty, @total, CURRENT_DATE)";
                    using (var cmdInsert = new NpgsqlCommand(queryInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@id_prod", idProduk);
                        cmdInsert.Parameters.AddWithValue("@qty", qty);
                        cmdInsert.Parameters.AddWithValue("@total", total);
                        cmdInsert.ExecuteNonQuery();
                    }
                    return "SUKSES";
                }
            }
            catch (Exception ex) { return "Gagal Transaksi: " + ex.Message; }
        }
    }
}