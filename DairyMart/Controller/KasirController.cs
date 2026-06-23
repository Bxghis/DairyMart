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
                    string query = "SELECT * FROM v_stok_kulkas ORDER BY id_produk ASC";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { dt.Columns.Add("Error"); dt.Rows.Add(ex.Message); }
            return dt;
        }


        public string UpdateProdukOffline(int idProduk, string nama, int stokOffline, string tglKadaluarsa)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE produk SET nama_produk = @nama, stok_offline = @stokOffline, tgl_kadaluarsa = @tgl WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@stokOffline", stokOffline);

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
            using (var conn = new Koneksi().GetConnection())
            {
                conn.Open();
     
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Potong Stok Kulkas (stok_offline)
                        string queryUpd = "UPDATE produk SET stok_offline = stok_offline - @qty WHERE id_produk = @id";
                        using (var cmdUpd = new NpgsqlCommand(queryUpd, conn, transaction))
                        {
                            cmdUpd.Parameters.AddWithValue("@qty", qty);
                            cmdUpd.Parameters.AddWithValue("@id", idProduk);
                            cmdUpd.ExecuteNonQuery();
                        }

                        // 2. Catat ke Riwayat Kasir
                        string queryIns = "INSERT INTO transaksi_offline (id_produk, kuantitas, total_harga) VALUES (@prod, @qty, @tot)";
                        using (var cmdIns = new NpgsqlCommand(queryIns, conn, transaction))
                        {
                            cmdIns.Parameters.AddWithValue("@prod", idProduk);
                            cmdIns.Parameters.AddWithValue("@qty", qty);
                            cmdIns.Parameters.AddWithValue("@tot", total);
                            cmdIns.ExecuteNonQuery();
                        }

                      
                        transaction.Commit();
                        return "SUKSES";
                    }
                    catch (Exception ex)
                    {
                    
                        transaction.Rollback();
                        return "Gagal Transaksi: " + ex.Message;
                    }
                }
            }
        }
    }
}