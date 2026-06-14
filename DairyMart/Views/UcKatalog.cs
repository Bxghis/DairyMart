using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DairyMart.Views
{
    public partial class UcKatalog : UserControl
    {
        public UcKatalog()
        {
            InitializeComponent();
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            string namaPilihan = "";
            int hargaPilihan = 0;

            if (rb1000.Checked)
            {
                namaPilihan = "SUSU 1000 ML";
                hargaPilihan = 100000;
            }
            else if (rb750.Checked)
            {
                namaPilihan = "SUSU 750 ML";
                hargaPilihan = 75000;
            }
            else if (rb500.Checked)
            {
                namaPilihan = "SUSU 500 ML";
                hargaPilihan = 50000;
            }

            else
            {
                MessageBox.Show("Pilih ukuran susu dulu bosku sebelum lanjut!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormDashboard bapak = (FormDashboard)this.FindForm();
            if (bapak != null)
            {
                bapak.TampilkanHalaman(new UcCheckout(namaPilihan, hargaPilihan));
            }
        }

        private void UcKatalog_Load(object sender, EventArgs e)
        {

        }
    }
}
