namespace DairyMart.Views
{
    partial class UcCheckout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            txtTotalBayar = new TextBox();
            label2 = new Label();
            cmbTipeTransaksi = new ComboBox();
            label1 = new Label();
            btnBayar = new Button();
            cmbMetode = new ComboBox();
            lblHarga = new Label();
            lblNamaProduk = new Label();
            btnLogout = new Button();
            btnKembali = new Button();
            btnLogoutt = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(337, 326);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 17;
            label3.Text = "Total Pembayaran";
            // 
            // txtTotalBayar
            // 
            txtTotalBayar.Location = new Point(266, 296);
            txtTotalBayar.Name = "txtTotalBayar";
            txtTotalBayar.ReadOnly = true;
            txtTotalBayar.Size = new Size(266, 27);
            txtTotalBayar.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(569, 218);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 15;
            label2.Text = "Pilih Tipe Transaksi";
            // 
            // cmbTipeTransaksi
            // 
            cmbTipeTransaksi.FormattingEnabled = true;
            cmbTipeTransaksi.Items.AddRange(new object[] { "Beli Langsung (Eceran)", "Langganan Bulanan (Kirim 2x Seminggu)" });
            cmbTipeTransaksi.Location = new Point(560, 187);
            cmbTipeTransaksi.Name = "cmbTipeTransaksi";
            cmbTipeTransaksi.Size = new Size(151, 28);
            cmbTipeTransaksi.TabIndex = 14;
            cmbTipeTransaksi.SelectedIndexChanged += cmbTipeTransaksi_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(565, 142);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 13;
            label1.Text = "Metode Pembayaran";
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(266, 407);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(257, 29);
            btnBayar.TabIndex = 12;
            btnBayar.Text = "Bayar Sekarang";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // cmbMetode
            // 
            cmbMetode.FormattingEnabled = true;
            cmbMetode.Items.AddRange(new object[] { "1 - QRIS", "2 - GoPay", "3 - DANA", "4 - ShopeePay" });
            cmbMetode.Location = new Point(560, 111);
            cmbMetode.Name = "cmbMetode";
            cmbMetode.Size = new Size(151, 28);
            cmbMetode.TabIndex = 11;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(37, 218);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(50, 20);
            lblHarga.TabIndex = 10;
            lblHarga.Text = "Harga";
            // 
            // lblNamaProduk
            // 
            lblNamaProduk.AutoSize = true;
            lblNamaProduk.Location = new Point(37, 147);
            lblNamaProduk.Name = "lblNamaProduk";
            lblNamaProduk.Size = new Size(99, 20);
            lblNamaProduk.TabIndex = 9;
            lblNamaProduk.Text = "Nama Produk";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(554, 497);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(157, 29);
            btnLogout.TabIndex = 18;
            btnLogout.Text = "Selesai dan Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(42, 29);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(94, 29);
            btnKembali.TabIndex = 19;
            btnKembali.Text = "⬅ Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // btnLogoutt
            // 
            btnLogoutt.Location = new Point(594, 29);
            btnLogoutt.Name = "btnLogoutt";
            btnLogoutt.Size = new Size(94, 29);
            btnLogoutt.TabIndex = 20;
            btnLogoutt.Text = "Logout";
            btnLogoutt.UseVisualStyleBackColor = true;
            btnLogoutt.Click += btnLogoutt_Click;
            // 
            // UcCheckout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(btnLogoutt);
            Controls.Add(btnKembali);
            Controls.Add(btnLogout);
            Controls.Add(label3);
            Controls.Add(txtTotalBayar);
            Controls.Add(label2);
            Controls.Add(cmbTipeTransaksi);
            Controls.Add(label1);
            Controls.Add(btnBayar);
            Controls.Add(cmbMetode);
            Controls.Add(lblHarga);
            Controls.Add(lblNamaProduk);
            Name = "UcCheckout";
            Size = new Size(758, 555);
            Load += UcCheckout_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox txtTotalBayar;
        private Label label2;
        private ComboBox cmbTipeTransaksi;
        private Label label1;
        private Button btnBayar;
        private ComboBox cmbMetode;
        private Label lblHarga;
        private Label lblNamaProduk;
        private Button btnLogout;
        private Button btnKembali;
        private Button btnLogoutt;
    }
}
