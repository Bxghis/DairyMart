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
            btnLogout = new Button();
            btnKembali = new Button();
            btnLogoutt = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            dgvKeranjangCheckout = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKeranjangCheckout).BeginInit();
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
            // btnLogout
            // 
            btnLogout.Location = new Point(554, 497);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(157, 29);
            btnLogout.TabIndex = 18;
            btnLogout.Text = "Selesai dan Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogoutt_Click;
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
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // dgvKeranjangCheckout
            // 
            dgvKeranjangCheckout.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeranjangCheckout.Location = new Point(42, 88);
            dgvKeranjangCheckout.Name = "dgvKeranjangCheckout";
            dgvKeranjangCheckout.RowHeadersWidth = 51;
            dgvKeranjangCheckout.Size = new Size(300, 188);
            dgvKeranjangCheckout.TabIndex = 21;
            // 
            // UcCheckout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(dgvKeranjangCheckout);
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
            Name = "UcCheckout";
            Size = new Size(758, 555);
            Load += UcCheckout_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKeranjangCheckout).EndInit();
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
        private Button btnLogout;
        private Button btnKembali;
        private Button btnLogoutt;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private DataGridView dgvKeranjangCheckout;
    }
}
