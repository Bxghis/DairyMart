using System;
using System.Windows.Forms;
using DairyMart.Controllers;
using DairyMart.Views;

namespace DairyMart
{
    public partial class FormLogin : Form
    {
        private LoginController controller = new LoginController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string wa = txtNoWa.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(wa) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Nomor WA dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string respon = controller.ProsesLogin(wa, pass);

            if (respon == "Konsumen" || respon == "Admin" || respon == "Kasir" || respon == "Pelanggan")
            {
                MessageBox.Show($"Login Berhasil! Selamat Datang {respon}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormDashboard dashboard = new FormDashboard(respon);
                dashboard.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(respon, "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}