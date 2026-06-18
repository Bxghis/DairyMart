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
            label1 = new Label();
            cb500 = new CheckBox();
            cb750 = new CheckBox();
            cb1000 = new CheckBox();
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
            // cb500
            // 
            cb500.AutoSize = true;
            cb500.Location = new Point(108, 206);
            cb500.Name = "cb500";
            cb500.Size = new Size(119, 24);
            cb500.TabIndex = 10;
            cb500.Text = "SUSU 500 ML";
            cb500.UseVisualStyleBackColor = true;
            cb500.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cb750
            // 
            cb750.AutoSize = true;
            cb750.Location = new Point(320, 206);
            cb750.Name = "cb750";
            cb750.Size = new Size(119, 24);
            cb750.TabIndex = 11;
            cb750.Text = "SUSU 750 ML";
            cb750.UseVisualStyleBackColor = true;
            // 
            // cb1000
            // 
            cb1000.AutoSize = true;
            cb1000.Location = new Point(528, 206);
            cb1000.Name = "cb1000";
            cb1000.Size = new Size(127, 24);
            cb1000.TabIndex = 12;
            cb1000.Text = "SUSU 1000 ML";
            cb1000.UseVisualStyleBackColor = true;
            // 
            // UcKatalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(cb1000);
            Controls.Add(cb750);
            Controls.Add(cb500);
            Controls.Add(btnLanjut);
            Controls.Add(label1);
            Name = "UcKatalog";
            Size = new Size(776, 549);
            Load += UcKatalog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLanjut;
        private Label label1;
        private CheckBox cb500;
        private CheckBox cb750;
        private CheckBox cb1000;
    }
}
