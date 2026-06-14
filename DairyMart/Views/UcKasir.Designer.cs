namespace DairyMart.Views
{
    partial class UcKasir
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
            btnTambahStok = new Button();
            dgvStokOffline = new DataGridView();
            btnLogout = new Button();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            txtTglKadaluarsa = new TextBox();
            txtStatusKelayakan = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtNamaProduk = new TextBox();
            txtJumlah = new TextBox();
            label1 = new Label();
            btnLogoutt = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStokOffline).BeginInit();
            SuspendLayout();
            // 
            // btnTambahStok
            // 
            btnTambahStok.BackColor = Color.Cyan;
            btnTambahStok.Location = new Point(385, 421);
            btnTambahStok.Name = "btnTambahStok";
            btnTambahStok.Size = new Size(94, 29);
            btnTambahStok.TabIndex = 9;
            btnTambahStok.Text = "Tambah Stok Offline";
            btnTambahStok.UseVisualStyleBackColor = false;
            btnTambahStok.Click += btnTambahStok_Click;
            // 
            // dgvStokOffline
            // 
            dgvStokOffline.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStokOffline.Location = new Point(58, 67);
            dgvStokOffline.Name = "dgvStokOffline";
            dgvStokOffline.RowHeadersWidth = 51;
            dgvStokOffline.Size = new Size(489, 330);
            dgvStokOffline.TabIndex = 5;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(555, 474);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(168, 29);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Tutup Toko / Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(517, 421);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 11;
            button1.Text = "Hapus";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnHapus_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.Location = new Point(641, 421);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 12;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnEdit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(585, 343);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 23;
            label4.Text = "Tanggal Kadaluarsa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(586, 265);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 22;
            label5.Text = "Status Kelayakan";
            // 
            // txtTglKadaluarsa
            // 
            txtTglKadaluarsa.Location = new Point(586, 302);
            txtTglKadaluarsa.Name = "txtTglKadaluarsa";
            txtTglKadaluarsa.Size = new Size(120, 27);
            txtTglKadaluarsa.TabIndex = 21;
            // 
            // txtStatusKelayakan
            // 
            txtStatusKelayakan.Location = new Point(586, 223);
            txtStatusKelayakan.Name = "txtStatusKelayakan";
            txtStatusKelayakan.Size = new Size(120, 27);
            txtStatusKelayakan.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(617, 190);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 19;
            label6.Text = "Jumlah";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(595, 118);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 18;
            label7.Text = "Nama Produk";
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.Location = new Point(586, 77);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(120, 27);
            txtNamaProduk.TabIndex = 16;
            // 
            // txtJumlah
            // 
            txtJumlah.Location = new Point(586, 150);
            txtJumlah.Name = "txtJumlah";
            txtJumlah.Size = new Size(120, 27);
            txtJumlah.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(304, 27);
            label1.Name = "label1";
            label1.Size = new Size(155, 37);
            label1.TabIndex = 24;
            label1.Text = "DAIRYMART";
            // 
            // btnLogoutt
            // 
            btnLogoutt.Location = new Point(58, 417);
            btnLogoutt.Name = "btnLogoutt";
            btnLogoutt.Size = new Size(135, 33);
            btnLogoutt.TabIndex = 25;
            btnLogoutt.Text = "Logout / Keluar";
            btnLogoutt.UseVisualStyleBackColor = true;
            btnLogoutt.Click += btnLogout_Click;
            // 
            // UcKasir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLogoutt);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(txtTglKadaluarsa);
            Controls.Add(txtStatusKelayakan);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtNamaProduk);
            Controls.Add(txtJumlah);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnLogout);
            Controls.Add(btnTambahStok);
            Controls.Add(dgvStokOffline);
            Name = "UcKasir";
            Size = new Size(767, 518);
            Load += UcKasir_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStokOffline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTambahStok;
        private DataGridView dgvStokOffline;
        private Button btnLogout;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label5;
        private TextBox txtTglKadaluarsa;
        private TextBox txtStatusKelayakan;
        private Label label6;
        private Label label7;
        private TextBox txtNamaProduk;
        private TextBox txtJumlah;
        private Label label1;
        private Button btnLogoutt;
    }
}
