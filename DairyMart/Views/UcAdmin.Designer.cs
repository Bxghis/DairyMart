namespace DairyMart.Views
{
    partial class UcAdmin
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnEdit = new Button();
            btnHapus = new Button();
            label4 = new Label();
            label3 = new Label();
            txtTglKadaluarsa = new TextBox();
            txtStatusKelayakan = new TextBox();
            btnTambahStok = new Button();
            label2 = new Label();
            dgvStok = new DataGridView();
            label1 = new Label();
            txtNamaProduk = new TextBox();
            txtJumlah = new TextBox();
            tabPage2 = new TabPage();
            dgvRiwayat = new DataGridView();
            btnLogout = new Button();
            label5 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStok).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(65, 44);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(701, 377);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnEdit);
            tabPage1.Controls.Add(btnHapus);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtTglKadaluarsa);
            tabPage1.Controls.Add(txtStatusKelayakan);
            tabPage1.Controls.Add(btnTambahStok);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dgvStok);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtNamaProduk);
            tabPage1.Controls.Add(txtJumlah);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(693, 369);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Manajemen Stok";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Yellow;
            btnEdit.Location = new Point(580, 321);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(81, 26);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.IndianRed;
            btnHapus.Location = new Point(484, 320);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(84, 29);
            btnHapus.TabIndex = 10;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(525, 221);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 9;
            label4.Text = "Tanggal Kadaluarsa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(537, 169);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 8;
            label3.Text = "Status Kelayakan";
            label3.Click += label3_Click;
            // 
            // txtTglKadaluarsa
            // 
            txtTglKadaluarsa.Location = new Point(538, 191);
            txtTglKadaluarsa.Name = "txtTglKadaluarsa";
            txtTglKadaluarsa.Size = new Size(106, 27);
            txtTglKadaluarsa.TabIndex = 7;
            // 
            // txtStatusKelayakan
            // 
            txtStatusKelayakan.Location = new Point(538, 130);
            txtStatusKelayakan.Name = "txtStatusKelayakan";
            txtStatusKelayakan.Size = new Size(106, 27);
            txtStatusKelayakan.TabIndex = 6;
            // 
            // btnTambahStok
            // 
            btnTambahStok.BackColor = Color.FromArgb(0, 192, 192);
            btnTambahStok.Location = new Point(400, 320);
            btnTambahStok.Name = "btnTambahStok";
            btnTambahStok.Size = new Size(76, 29);
            btnTambahStok.TabIndex = 3;
            btnTambahStok.Text = "Tambah Stok";
            btnTambahStok.UseVisualStyleBackColor = false;
            btnTambahStok.Click += btnTambah_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(563, 107);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 5;
            label2.Text = "Jumlah";
            // 
            // dgvStok
            // 
            dgvStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStok.Location = new Point(6, 6);
            dgvStok.Name = "dgvStok";
            dgvStok.RowHeadersWidth = 51;
            dgvStok.Size = new Size(513, 301);
            dgvStok.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(541, 54);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 4;
            label1.Text = "Nama Produk";
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.Location = new Point(538, 21);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(106, 27);
            txtNamaProduk.TabIndex = 1;
            // 
            // txtJumlah
            // 
            txtJumlah.Location = new Point(538, 77);
            txtJumlah.Name = "txtJumlah";
            txtJumlah.Size = new Size(106, 27);
            txtJumlah.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvRiwayat);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(693, 344);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Riwayat Transaksi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRiwayat.Dock = DockStyle.Fill;
            dgvRiwayat.Location = new Point(3, 3);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.RowHeadersWidth = 51;
            dgvRiwayat.Size = new Size(687, 338);
            dgvRiwayat.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(672, 427);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(136, 33);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout / Keluar";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(322, 4);
            label5.Name = "label5";
            label5.Size = new Size(155, 37);
            label5.TabIndex = 6;
            label5.Text = "DAIRYMART";
            // 
            // UcAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btnLogout);
            Controls.Add(tabControl1);
            Name = "UcAdmin";
            Size = new Size(838, 504);
            Load += UcAdmin_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStok).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnEdit;
        private Button btnHapus;
        private Label label4;
        private Label label3;
        private TextBox txtTglKadaluarsa;
        private TextBox txtStatusKelayakan;
        private Button btnTambahStok;
        private Label label2;
        private DataGridView dgvStok;
        private Label label1;
        private TextBox txtNamaProduk;
        private TextBox txtJumlah;
        private TabPage tabPage2;
        private DataGridView dgvRiwayat;
        private Button btnLogout;
        private Label label5;
    }
}
