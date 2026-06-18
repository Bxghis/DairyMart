using System;
using System.Windows.Forms;
using DairyMart.Controllers;

namespace DairyMart.Views
{
    public partial class UcKasir : UserControl
    {
        private KasirController kasirController = new KasirController();
        private int idProdukTerpilih = 0;

        public UcKasir()
        {
            InitializeComponent();
        }

        private void UcKasir_Load(object sender, EventArgs e)
        {
            RefreshTabel();
        }

        private void RefreshTabel()
        {
            dgvStokOffline.DataSource = kasirController.GetStokOffline();
        }

        private void dgvStokOffline_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStokOffline.Rows[e.RowIndex];

                idProdukTerpilih = Convert.ToInt32(row.Cells["id_produk"].Value);

                txtNamaProduk.Text = row.Cells["nama_produk"].Value.ToString();
                txtJumlah.Text = row.Cells["stok_offline"].Value.ToString();
                txtStatusKelayakan.Text = row.Cells["status_kelayakan"].Value.ToString();

                // FIX KETEMU: Ubah format tanggal jadi yyyy-MM-dd biar database gak kejang-kejang pas lu nge-Edit
                if (row.Cells["tgl_kadaluarsa"].Value != DBNull.Value)
                {
                    DateTime tgl = DateTime.Parse(row.Cells["tgl_kadaluarsa"].Value.ToString());
                    txtTglKadaluarsa.Text = tgl.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtTglKadaluarsa.Text = "";
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (idProdukTerpilih == 0)
            {
                MessageBox.Show("Pilih dulu produk yang mau diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = Convert.ToInt32(txtJumlah.Text);

            // AMAN: Cuma 4 parameter (ID, Nama, Stok, Tanggal)
            string respon = kasirController.UpdateProdukOffline(idProdukTerpilih, txtNamaProduk.Text, qty, txtTglKadaluarsa.Text);

            if (respon == "SUKSES")
            {
                MessageBox.Show("Data kulkas berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTabel();
                BersihkanForm(); // FIX KETEMU: Gw tambahin BersihkanForm biar abis ngedit kotaknya langsung kosong
            }
            else { MessageBox.Show(respon, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idProdukTerpilih == 0)
            {
                MessageBox.Show("Pilih dulu produk yang mau dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Yakin hapus barang ini dari etalase?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                string respon = kasirController.HapusProdukOffline(idProdukTerpilih);
                if (respon == "SUKSES")
                {
                    MessageBox.Show("Barang musnah dari kulkas!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshTabel();
                    BersihkanForm();
                }
                else { MessageBox.Show(respon, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (idProdukTerpilih == 0)
            {
                MessageBox.Show("Klik dulu susu mana yang mau dibeli pelanggan di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qtyBeli = 0;
            int.TryParse(txtJumlah.Text, out qtyBeli);

            if (qtyBeli <= 0)
            {
                MessageBox.Show("Jumlah beli harus lebih dari 0 dong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hargaSusu = 25000;
            int totalBayar = qtyBeli * hargaSusu;

            // Panggil fungsi Jualan Kasir (Ini otomatis manggil sp_kasir_jualan dan ngurangin stok kulkas)
            string respon = kasirController.SimpanTransaksiOffline(idProdukTerpilih, qtyBeli, totalBayar);

            if (respon == "SUKSES")
            {
                string struk = $"TRANSAKSI BERHASIL!\n\nProduk: {txtNamaProduk.Text}\nJumlah: {qtyBeli}\nTotal Bayar: Rp {totalBayar}\n\nSisa stok offline udah otomatis kepotong!";
                MessageBox.Show(struk, "Struk Kasir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTabel();
                BersihkanForm();
            }
            else
            {
                MessageBox.Show(respon, "Transaksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BersihkanForm()
        {
            txtNamaProduk.Clear();
            txtJumlah.Clear();
            txtStatusKelayakan.Clear();
            txtTglKadaluarsa.Clear();
            idProdukTerpilih = 0;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Yakin mau tutup shift dan logout?", "Tutup Toko", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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