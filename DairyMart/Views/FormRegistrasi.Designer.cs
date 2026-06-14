namespace DairyMart.Views
{
    partial class FormRegistrasi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Nama = new Label();
            label1 = new Label();
            txtNama = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtNoWa = new TextBox();
            txtAlamat = new TextBox();
            btnDaftar = new Button();
            lblKeLogin = new LinkLabel();
            SuspendLayout();
            // 
            // Nama
            // 
            Nama.AutoSize = true;
            Nama.Location = new Point(32, 97);
            Nama.Name = "Nama";
            Nama.Size = new Size(49, 20);
            Nama.TabIndex = 0;
            Nama.Text = "Nama";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(308, 26);
            label1.Name = "label1";
            label1.Size = new Size(155, 37);
            label1.TabIndex = 1;
            label1.Text = "DAIRYMART";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(32, 120);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(328, 27);
            txtNama.TabIndex = 2;
            txtNama.KeyPress += txtNama_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 159);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(32, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(329, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 223);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 5;
            label3.Text = "Nomor Wa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 289);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 6;
            label4.Text = "Alamat";
            // 
            // txtNoWa
            // 
            txtNoWa.Location = new Point(33, 246);
            txtNoWa.Name = "txtNoWa";
            txtNoWa.Size = new Size(329, 27);
            txtNoWa.TabIndex = 7;
            txtNoWa.KeyPress += txtNoWa_KeyPress;
            // 
            // txtAlamat
            // 
            txtAlamat.Location = new Point(33, 312);
            txtAlamat.Multiline = true;
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(329, 27);
            txtAlamat.TabIndex = 8;
            // 
            // btnDaftar
            // 
            btnDaftar.Location = new Point(319, 374);
            btnDaftar.Name = "btnDaftar";
            btnDaftar.Size = new Size(144, 26);
            btnDaftar.TabIndex = 9;
            btnDaftar.Text = "Daftar";
            btnDaftar.UseVisualStyleBackColor = true;
            btnDaftar.Click += btnDaftar_Click;
            // 
            // lblKeLogin
            // 
            lblKeLogin.AutoSize = true;
            lblKeLogin.Location = new Point(292, 403);
            lblKeLogin.Name = "lblKeLogin";
            lblKeLogin.Size = new Size(201, 20);
            lblKeLogin.TabIndex = 10;
            lblKeLogin.TabStop = true;
            lblKeLogin.Text = "Sudah punya akun? klik disini";
            lblKeLogin.LinkClicked += lblKeLogin_LinkClicked;
            // 
            // FormRegistrasi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(800, 450);
            Controls.Add(lblKeLogin);
            Controls.Add(btnDaftar);
            Controls.Add(txtAlamat);
            Controls.Add(txtNoWa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtNama);
            Controls.Add(label1);
            Controls.Add(Nama);
            Name = "FormRegistrasi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrasi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nama;
        private Label label1;
        private TextBox txtNama;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private Label label4;
        private TextBox txtNoWa;
        private TextBox txtAlamat;
        private Button btnDaftar;
        private LinkLabel lblKeLogin;
    }
}