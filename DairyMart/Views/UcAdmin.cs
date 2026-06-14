using System;
using System.Windows.Forms;
using DairyMart.Controllers;

namespace DairyMart.Views
{
    public partial class UcAdmin : UserControl
    {
        private AdminController adminController = new AdminController();

        private int idProdukTerpilih = 0;

        public UcAdmin()
        {
            InitializeComponent();
        }

        private void UcAdmin_Load(object sender, EventArgs e)
        {
            RefreshSemuaTabel();
        }

        private void RefreshSemuaTabel()
        {
            // PASTIKAN pakai nama adminController biar gak error merah lagi!
            dgvStok.DataSource = adminController.GetStokOnline();
            dgvRiwayat.DataSource = adminController.GetRiwayatTransaksi();
        }

        private void dgvStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStok.Rows[e.RowIndex];

                // Tarik data dari baris yang diklik
                idProdukTerpilih = Convert.ToInt32(row.Cells["id_produk"].Value);
                txtNamaProduk.Text = row.Cells["nama_produk"].Value.ToString();
                txtJumlah.Text = row.Cells["stok"].Value.ToString();
                txtStatusKelayakan.Text = row.Cells["status_kelayakan"].Value.ToString();

                // Ngurusin tanggal biar gak error
                if (row.Cells["tgl_kadaluarsa"].Value != DBNull.Value)
                {
                    string tglMentah = row.Cells["tgl_kadaluarsa"].Value.ToString();
                    DateTime tgl = DateTime.Parse(tglMentah);
                    txtTglKadaluarsa.Text = tgl.ToString("dd-MM-yyyy");
                }
                else
                {
                    txtTglKadaluarsa.Text = "";
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string namaBaru = txtNamaProduk.Text;
            string statusBaru = txtStatusKelayakan.Text;
            string tglBaru = txtTglKadaluarsa.Text;

            int stokBaru = 0;
            int.TryParse(txtJumlah.Text, out stokBaru);

            if (string.IsNullOrWhiteSpace(namaBaru))
            {
                MessageBox.Show("Nama Produk wajib diisi bosku!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string respon = adminController.TambahProdukBaru(namaBaru, stokBaru, statusBaru, tglBaru);

            if (respon == "SUKSES")
            {
                MessageBox.Show("Produk baru berhasil ditambah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshSemuaTabel(); // Panggil fungsi refresh yang baru
                BersihkanForm();
            }
            else
            {
                MessageBox.Show(respon, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (idProdukTerpilih == 0)
            {
                MessageBox.Show("Pilih dulu produk yang mau diedit dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaBaru = txtNamaProduk.Text;
            string statusBaru = txtStatusKelayakan.Text;
            int stokBaru = Convert.ToInt32(txtJumlah.Text);
            int hargaBaru = 25000;

            string respon = adminController.UpdateProduk(idProdukTerpilih, namaBaru, hargaBaru, stokBaru, statusBaru);

            if (respon == "SUKSES")
            {
                MessageBox.Show("Data produk berhasil diupdate!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshSemuaTabel();
                BersihkanForm();
            }
            else
            {
                MessageBox.Show(respon, "Gagal Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idProdukTerpilih == 0)
            {
                MessageBox.Show("Pilih dulu produk yang mau dihapus bosku!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Yakin mau menghapus produk ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                string respon = adminController.HapusProduk(idProdukTerpilih);

                if (respon == "SUKSES")
                {
                    MessageBox.Show("Produk sukses dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSemuaTabel(); 
                    BersihkanForm();
                }
                else
                {
                    MessageBox.Show(respon, "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void label3_Click(object sender, EventArgs e) { }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Yakin mau istirahat dan logout bosku?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Form bapak = this.FindForm();

                if (bapak != null)
                {
                    FormLogin loginPage = new FormLogin();
                    loginPage.Show();
                    bapak.Close();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSemuaTabel();
        }
    }
}