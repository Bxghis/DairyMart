using DairyMart.Models;
using Npgsql;
using System;
using System.Data; // 🔥 WAJIB DITAMBAHIN BUAT BACA KERANJANG DATATABLE

namespace DairyMart.Controllers
{
    public class CheckoutController
    {
        // 🔥 NAMA FUNGSI DAN PARAMETERNYA BERUBAH TOTAL! (Nerima DataTable keranjang)
        public string ProsesPembayaranKeranjang(int idPelanggan, DataTable keranjang, string tipeTransaksi, string metodePembayaran, int grandTotal)
        {
            using (var conn = new Koneksi().GetConnection())
            {
                conn.Open();

                // 🔥 INISIALISASI TRANSAKSI C# (Ini yang bikin dosen lu bakal ngasih nilai A!)
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Tarik ID Metode Pembayaran (Cukup 1 kali aja di luar looping)
                        int idMetode = 1; // Default
                        using (var cmdMet = new NpgsqlCommand("SELECT id_metode FROM metode_pembayaran WHERE nama_metode = @metode LIMIT 1", conn, transaction))
                        {
                            cmdMet.Parameters.AddWithValue("@metode", metodePembayaran);
                            var res = cmdMet.ExecuteScalar();
                            if (res != null) idMetode = Convert.ToInt32(res);
                        }

                        // 2. 🔥 BACA ISI KERANJANG SATU PERSATU (LOOPING)
                        foreach (DataRow row in keranjang.Rows)
                        {
                            string namaProduk = row["Nama_Produk"].ToString();
                            int qtyBeli = Convert.ToInt32(row["Qty"]);
                            int subtotalBarang = Convert.ToInt32(row["Subtotal"]);

                            // Penerjemah otomatis biar gak typo pas nyari di database
                            string namaFixDB = namaProduk;
                            if (namaProduk.Contains("1000 ML")) namaFixDB = "Susu Segar 1000 ML";
                            else if (namaProduk.Contains("750 ML")) namaFixDB = "Susu Segar 750 ML";
                            else if (namaProduk.Contains("500 ML")) namaFixDB = "Susu Segar 500 ML";

                            // Cari ID Produk
                            int idProduk = 0;
                            using (var cmdProd = new NpgsqlCommand("SELECT id_produk FROM produk WHERE nama_produk = @nama LIMIT 1", conn, transaction))
                            {
                                cmdProd.Parameters.AddWithValue("@nama", namaFixDB);
                                var resProd = cmdProd.ExecuteScalar();
                                if (resProd != null) idProduk = Convert.ToInt32(resProd);
                            }

                            // Tembok Pertahanan
                            if (idProduk == 0)
                            {
                                throw new Exception($"Waduh! Produk '{namaFixDB}' gak ketemu di database bray!");
                            }

                            // 3. 🔥 CABANG LOGIKA: LANGGANAN vs OFFLINE (ECERAN)
                            if (tipeTransaksi.Contains("Langganan"))
                            {
                                int qtyLangganan = qtyBeli * 8; // Aturan langganan dikali 8
                                int subtotalLangganan = subtotalBarang * 8;

                                // A. Potong Stok Online Gudang
                                using (var cmdUpd = new NpgsqlCommand("UPDATE produk SET stok_online = stok_online - @qty WHERE id_produk = @id", conn, transaction))
                                {
                                    cmdUpd.Parameters.AddWithValue("@qty", qtyLangganan);
                                    cmdUpd.Parameters.AddWithValue("@id", idProduk);
                                    cmdUpd.ExecuteNonQuery();
                                }

                                // B. Insert ke Tabel Langganan
                                using (var cmdIns = new NpgsqlCommand("INSERT INTO langganan (id_pelanggan, id_produk, id_metode, jumlah, total_bayar) VALUES (@pel, @prod, @met, @qty, @tot)", conn, transaction))
                                {
                                    cmdIns.Parameters.AddWithValue("@pel", idPelanggan);
                                    cmdIns.Parameters.AddWithValue("@prod", idProduk);
                                    cmdIns.Parameters.AddWithValue("@met", idMetode);
                                    cmdIns.Parameters.AddWithValue("@qty", qtyLangganan);
                                    cmdIns.Parameters.AddWithValue("@tot", subtotalLangganan);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // JIKA PILIH BELI LANGSUNG (ECERAN)
                                // A. Potong Stok Offline Kulkas
                                using (var cmdUpd = new NpgsqlCommand("UPDATE produk SET stok_offline = stok_offline - @qty WHERE id_produk = @id", conn, transaction))
                                {
                                    cmdUpd.Parameters.AddWithValue("@qty", qtyBeli);
                                    cmdUpd.Parameters.AddWithValue("@id", idProduk);
                                    cmdUpd.ExecuteNonQuery();
                                }

    
                                using (var cmdIns = new NpgsqlCommand("INSERT INTO transaksi_offline (id_produk, kuantitas, total_harga) VALUES (@prod, @qty, @tot)", conn, transaction))
                                {
                                    cmdIns.Parameters.AddWithValue("@prod", idProduk);
                                    // cmdIns.Parameters.AddWithValue("@met", idMetode); ---> BARIS INI KITA HAPUS TOTAL!
                                    cmdIns.Parameters.AddWithValue("@qty", qtyBeli);
                                    cmdIns.Parameters.AddWithValue("@tot", subtotalBarang);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                        }

                        // 4. 🔥 JIKA SEMUA BARANG DI KERANJANG SUKSES, KUNCI PERMANEN!
                        transaction.Commit();
                        return "SUKSES";
                    }
                    catch (Exception ex)
                    {
                        // 🔥 JIKA ADA 1 BARANG GAGAL, BATALKAN SEMUANYA BIAR DATA GAK BERANTAKAN!
                        transaction.Rollback();
                        return "Transaksi Dibatalkan Sistem: " + ex.Message;
                    }
                }
            }
        }
    }
}