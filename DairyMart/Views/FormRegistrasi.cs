using System;
using System.Windows.Forms;
using DairyMart.Controllers;

namespace DairyMart.Views
{
    public partial class FormRegistrasi : Form
    {
        private RegistrasiController controller = new RegistrasiController();

        public FormRegistrasi()
        {
            InitializeComponent();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtNoWa.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi!, tidak boleh ada yang kosong!", "Data Belum Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string nama = txtNama.Text;
            string wa = txtNoWa.Text;
            string password = txtPassword.Text;
            string alamat = txtAlamat.Text;

            string roleDipilih = "Konsumen";

            string respon = controller.ProsesRegistrasi(nama, wa, password, alamat, roleDipilih);

            if (respon == "SUKSES")
            {
                MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormLogin frmLogin = new FormLogin();
                frmLogin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(respon, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblKeLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void txtNoWa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}