namespace DairyMart.Views
{
    partial class UcKatalog
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
            btnLanjut = new Button();
            rb500 = new RadioButton();
            rb750 = new RadioButton();
            rb1000 = new RadioButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLanjut
            // 
            btnLanjut.Location = new Point(599, 381);
            btnLanjut.Name = "btnLanjut";
            btnLanjut.Size = new Size(112, 39);
            btnLanjut.TabIndex = 9;
            btnLanjut.Text = "Lanjut";
            btnLanjut.UseVisualStyleBackColor = true;
            btnLanjut.Click += btnLanjut_Click;
            // 
            // rb500
            // 
            rb500.AutoSize = true;
            rb500.Location = new Point(524, 189);
            rb500.Name = "rb500";
            rb500.Size = new Size(118, 24);
            rb500.TabIndex = 8;
            rb500.TabStop = true;
            rb500.Text = "SUSU 500 ML";
            rb500.UseVisualStyleBackColor = true;
            // 
            // rb750
            // 
            rb750.AutoSize = true;
            rb750.Location = new Point(306, 189);
            rb750.Name = "rb750";
            rb750.Size = new Size(118, 24);
            rb750.TabIndex = 7;
            rb750.TabStop = true;
            rb750.Text = "SUSU 750 ML";
            rb750.UseVisualStyleBackColor = true;
            // 
            // rb1000
            // 
            rb1000.AutoSize = true;
            rb1000.Location = new Point(83, 189);
            rb1000.Name = "rb1000";
            rb1000.Size = new Size(126, 24);
            rb1000.TabIndex = 6;
            rb1000.TabStop = true;
            rb1000.Text = "SUSU 1000 ML";
            rb1000.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(293, 71);
            label1.Name = "label1";
            label1.Size = new Size(155, 37);
            label1.TabIndex = 5;
            label1.Text = "DAIRYMART";
            // 
            // UcKatalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(btnLanjut);
            Controls.Add(rb500);
            Controls.Add(rb750);
            Controls.Add(rb1000);
            Controls.Add(label1);
            Name = "UcKatalog";
            Size = new Size(776, 549);
            Load += UcKatalog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLanjut;
        private RadioButton rb500;
        private RadioButton rb750;
        private RadioButton rb1000;
        private Label label1;
    }
}
