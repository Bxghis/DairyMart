using System;
using System.Data; // 🔥 WAJIB TAMBAH INI BUAT DATATABLE KERANJANG
using System.Windows.Forms;
using DairyMart.Controllers;
using DairyMart.Models;

namespace DairyMart.Views
{
    public partial class UcCheckout : UserControl
    {
        // 1. Siapin wadah buat nampung keranjang dari katalog
        private DataTable keranjangBelanja;
        private int totalKeranjangAwal = 0;

        // 🔥 PERUBAHAN: Sekarang form ini nerima DataTable, bukan 1 string doang!
        public UcCheckout(DataTable keranjangDariKatalog)
        {
            InitializeComponent();
            keranjangBelanja = keranjangDariKatalog;
        }

        private CheckoutController controller = new CheckoutController();

        private void UcCheckout_Load(object sender, EventArgs e)
        {
            // Tampilkan keranjang ke layar
            dgvKeranjangCheckout.DataSource = keranjangBelanja;

            // Hitung total harga semua barang di keranjang sebelum dikali langganan
            HitungTotalAwal();
        }

        private void HitungTotalAwal()
        {
            totalKeranjangAwal = 0;
            foreach (DataRow row in keranjangBelanja.Rows)
            {
                totalKeranjangAwal += Convert.ToInt32(row["Subtotal"]);
            }
            txtTotalBayar.Text = "Rp " + totalKeranjangAwal.ToString("#,##0");
        }

        private void cmbTipeTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logika Skenario 1: Kalau milih langganan, SELURUH isi keranjang dikali 8
            int totalAkhir = totalKeranjangAwal;

            if (cmbTipeTransaksi.Text.Contains("Langganan"))
            {
                totalAkhir = totalKeranjangAwal * 8;
            }

            txtTotalBayar.Text = "Rp " + totalAkhir.ToString("#,##0");
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbMetode.Text) || string.IsNullOrWhiteSpace(cmbTipeTransaksi.Text))
            {
                MessageBox.Show("Pilih Metode Pembayaran dan Tipe Transaksi dulu bosku!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalAkhir = totalKeranjangAwal;
            if (cmbTipeTransaksi.Text.Contains("Langganan"))
            {
                totalAkhir = totalKeranjangAwal * 8;
            }

            int idPelangganAsli = SessionData.IdPelangganAktif;

            // 🔥 PERUBAHAN: Kirim DataTable Keranjang ke Controller
            string respon = controller.ProsesPembayaranKeranjang(idPelangganAsli, keranjangBelanja, cmbTipeTransaksi.Text, cmbMetode.Text, totalAkhir);

            if (respon == "SUKSES")
            {
                // Bikin Struk Keren yang ngelist semua barang
                string struk = "PEMBAYARAN BERHASIL!\n\nDAFTAR BARANG:\n";
                foreach (DataRow row in keranjangBelanja.Rows)
                {
                    struk += $"- {row["Nama_Produk"]} (x{row["Qty"]})\n";
                }

                struk += $"\nTipe   : {cmbTipeTransaksi.Text}\n" +
                         $"Metode : {cmbMetode.Text}\n" +
                         $"Total  : Rp {totalAkhir.ToString("#,##0")}\n\n" +
                         "Terima kasih sudah berbelanja di DairyMart!";

                MessageBox.Show(struk, "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbMetode.SelectedIndex = -1;
                cmbTipeTransaksi.SelectedIndex = -1;
                btnBayar.Enabled = false;
            }
            else
            {
                MessageBox.Show(respon, "Transaksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormDashboard bapak = (FormDashboard)this.FindForm();
            if (bapak != null)
            {
                bapak.TampilkanHalaman(new UcKatalog());
            }
        }

        private void btnLogoutt_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Terima kasih sudah berbelanja di DairyMart! Keluar aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                Form bapak = this.FindForm();
                if (bapak != null)
                {
                    new FormLogin().Show();
                    bapak.Close();
                }
            }
        }
    }
}