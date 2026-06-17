using DairyMart.Models;
using Npgsql;
using System;

namespace DairyMart.Controllers
{
    public class CheckoutController
    {
        public string ProsesPembayaran(int idPelanggan, string namaProduk, string tipeTransaksi, string metodePembayaran, int totalBayar, int qtyBeli)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                try
                {
                    conn.Open();

                    // 🔥 PERUBAHAN 1: PENERJEMAH OTOMATIS (Biar sinkron sama Database lu!)
                    string namaFixDB = namaProduk;
                    if (namaProduk.Contains("1000 ML")) namaFixDB = "Susu Segar 1000 ML";
                    else if (namaProduk.Contains("750 ML")) namaFixDB = "Susu Segar 750 ML";
                    else if (namaProduk.Contains("500 ML")) namaFixDB = "Susu Segar 500 ML";

                    int idProduk = 0;
                    using (var cmdProd = new NpgsqlCommand("SELECT id_produk FROM produk WHERE nama_produk = @nama LIMIT 1", conn))
                    {
                        cmdProd.Parameters.AddWithValue("@nama", namaFixDB);
                        var res = cmdProd.ExecuteScalar();
                        if (res != null) idProduk = Convert.ToInt32(res);
                    }

                    // 🔥 PERUBAHAN 2: Tembok Pertahanan! Biar gak error merah kalo namanya masih beda.
                    if (idProduk == 0)
                    {
                        return $"Waduh! Produk '{namaFixDB}' gak ketemu di database bray! Cek ejaannya.";
                    }

                    int idMetode = 1; // Default
                    using (var cmdMet = new NpgsqlCommand("SELECT id_metode FROM metode_pembayaran WHERE nama_metode = @metode LIMIT 1", conn))
                    {
                        cmdMet.Parameters.AddWithValue("@metode", metodePembayaran);
                        var res = cmdMet.ExecuteScalar();
                        if (res != null) idMetode = Convert.ToInt32(res);
                    }

                    string query = "CALL sp_checkout_langganan(@pel, @prod, @met, @qty, @tot)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pel", idPelanggan);
                        cmd.Parameters.AddWithValue("@prod", idProduk);
                        cmd.Parameters.AddWithValue("@met", idMetode);
                        cmd.Parameters.AddWithValue("@qty", qtyBeli);
                        cmd.Parameters.AddWithValue("@tot", totalBayar);
                        cmd.ExecuteNonQuery();
                    }

                    return "SUKSES";
                }
                catch (Exception ex)
                {
                    return "Gagal nyimpen data: " + ex.Message;
                }
            }
        }
    }
}