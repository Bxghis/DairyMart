using System;
using System.Windows.Forms;

namespace DairyMart.Views
{
    public partial class FormDashboard : Form
    {
        public FormDashboard(string role)
        {
            InitializeComponent();

            string roleAman = role.Trim().ToLower();

            if (roleAman == "admin")
            {
                TampilkanHalaman(new UcAdmin());
            }
            else if (roleAman == "kasir")
            {
                TampilkanHalaman(new UcKasir());
            }
            else
            {
                TampilkanHalaman(new UcKatalog());
            }
        }

        public void TampilkanHalaman(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
        }
    }
}