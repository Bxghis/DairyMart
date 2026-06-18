using System;
using System.Data; // 🔥 WAJIB BUAT TABEL KERANJANG
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
            // 1. 🔥 BIKIN KERANJANG FRESH TIAP KALI TOMBOL DIKLIK
            // Kita pindahin pembuatannya ke dalem sini, biar keranjangnya keriset 
            // kalo pelanggan balik lagi dari form checkout.
            DataTable keranjangBelanja = new DataTable();
            keranjangBelanja.Columns.Add("ID_Produk", typeof(int));
            keranjangBelanja.Columns.Add("Nama_Produk", typeof(string));
            keranjangBelanja.Columns.Add("Harga", typeof(int));
            keranjangBelanja.Columns.Add("Qty", typeof(int));
            keranjangBelanja.Columns.Add("Subtotal", typeof(int));

            bool adaYangDipilih = false;

            // 2. 🔥 CEK SATU-SATU (Pake 'if' mandiri, BUKAN 'else if')
            // Biar sistem bisa nangkep kalau 2 atau 3 kotak diceklis sekaligus!

            if (cb1000.Checked)
            {
                keranjangBelanja.Rows.Add(1, "SUSU 1000 ML", 100000, 1, 100000);
                adaYangDipilih = true;
            }

            if (cb750.Checked)
            {
                keranjangBelanja.Rows.Add(2, "SUSU 750 ML", 75000, 1, 75000);
                adaYangDipilih = true;
            }

            if (cb500.Checked)
            {
                keranjangBelanja.Rows.Add(3, "SUSU 500 ML", 50000, 1, 50000);
                adaYangDipilih = true;
            }

            // 3. Tembok Pertahanan: Kalo iseng klik Lanjut tapi gak nyeklis apa-apa
            if (!adaYangDipilih)
            {
                MessageBox.Show("Ceklis minimal satu ukuran susu dulu bosku sebelum lanjut!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 🔥 LANGSUNG BAWA KERANJANGNYA PINDAH KE FORM CHECKOUT
            FormDashboard bapak = (FormDashboard)this.FindForm();
            if (bapak != null)
            {
                bapak.TampilkanHalaman(new UcCheckout(keranjangBelanja));
            }
        }

        private void UcKatalog_Load(object sender, EventArgs e)
        {
            // Dikosongin aja
        }

        // Ini fungsi bawaan kalo lu gak sengaja klik 2x checkbox di layar desain.
        // Biarin aja kosong gini biar gak error.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}