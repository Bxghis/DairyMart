using System;
using System.Windows.Forms;
using DairyMart.Controllers; // Wajib biar bisa nyambung ke controller kasir/checkout lu

namespace DairyMart.Views
{
    public partial class UcCheckout : UserControl
    {
        private string namaProdukBeli;
        private int hargaProdukBeli;

        public UcCheckout(string namaSusu, int hargaSusu)
        {
            InitializeComponent();

            namaProdukBeli = namaSusu;
            hargaProdukBeli = hargaSusu;
        }

        private CheckoutController controller = new CheckoutController();

        private void UcCheckout_Load(object sender, EventArgs e)
        {
            lblNamaProduk.Text = namaProdukBeli;
            lblHarga.Text = "Rp " + hargaProdukBeli.ToString("#,##0");

            txtTotalBayar.Text = "Rp " + hargaProdukBeli.ToString("#,##0");
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormDashboard bapak = (FormDashboard)this.FindForm();
            if (bapak != null)
            {
                bapak.TampilkanHalaman(new UcKatalog()); // Balik milih barang lagi bray
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Terima kasih sudah berbelanja di DairyMart! Keluar aplikasi?", "Konfirmasi Selesai", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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

        private void cmbTipeTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalAkhir = hargaProdukBeli;

            if (cmbTipeTransaksi.Text.Contains("Langganan"))
            {
                totalAkhir = hargaProdukBeli * 8;
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

            int qtyBeli = 1;
            if (cmbTipeTransaksi.Text.Contains("Langganan"))
            {
                qtyBeli = 8;
            }

            int totalAkhir = hargaProdukBeli * qtyBeli;

            string respon = controller.ProsesPembayaran(namaProdukBeli, cmbTipeTransaksi.Text, cmbMetode.Text, totalAkhir, qtyBeli);

            if (respon == "SUKSES")
            {
                string struk = "PEMBAYARAN BERHASIL!\n\n" +
                               "Produk : " + namaProdukBeli + "\n" +
                               "Jumlah : " + qtyBeli + " item\n" +
                               "Tipe   : " + cmbTipeTransaksi.Text + "\n" +
                               "Metode : " + cmbMetode.Text + "\n" +
                               "Total  : " + txtTotalBayar.Text + "\n\n" +
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