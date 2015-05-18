namespace snake
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panelYilan = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPuan = new System.Windows.Forms.Label();
            this.labelBitir = new System.Windows.Forms.Label();
            this.labelBasla = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelYilan
            // 
            this.panelYilan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelYilan.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelYilan.Location = new System.Drawing.Point(126, 0);
            this.panelYilan.Name = "panelYilan";
            this.panelYilan.Size = new System.Drawing.Size(400, 400);
            this.panelYilan.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.YellowGreen;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMenu.Controls.Add(this.checkBox1);
            this.panelMenu.Controls.Add(this.textBox2);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.textBox1);
            this.panelMenu.Controls.Add(this.labelPuan);
            this.panelMenu.Controls.Add(this.labelBitir);
            this.panelMenu.Controls.Add(this.labelBasla);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(128, 400);
            this.panelMenu.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Duvardan Geçiş";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hız";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adınız";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 229);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // labelPuan
            // 
            this.labelPuan.AutoSize = true;
            this.labelPuan.Font = new System.Drawing.Font("Script MT Bold", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelPuan.Location = new System.Drawing.Point(42, 48);
            this.labelPuan.Name = "labelPuan";
            this.labelPuan.Size = new System.Drawing.Size(24, 28);
            this.labelPuan.TabIndex = 2;
            this.labelPuan.Text = "0";
            // 
            // labelBitir
            // 
            this.labelBitir.AutoSize = true;
            this.labelBitir.Font = new System.Drawing.Font("Script MT Bold", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBitir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelBitir.Location = new System.Drawing.Point(10, 349);
            this.labelBitir.Name = "labelBitir";
            this.labelBitir.Size = new System.Drawing.Size(73, 28);
            this.labelBitir.TabIndex = 1;
            this.labelBitir.Text = "BİTİR";
            this.labelBitir.Click += new System.EventHandler(this.labelBitir_Click);
            this.labelBitir.MouseLeave += new System.EventHandler(this.labelBitir_MouseLeave);
            this.labelBitir.MouseHover += new System.EventHandler(this.labelBitir_MouseHover);
            // 
            // labelBasla
            // 
            this.labelBasla.AutoSize = true;
            this.labelBasla.Font = new System.Drawing.Font("Script MT Bold", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBasla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelBasla.Location = new System.Drawing.Point(10, 309);
            this.labelBasla.Name = "labelBasla";
            this.labelBasla.Size = new System.Drawing.Size(89, 28);
            this.labelBasla.TabIndex = 0;
            this.labelBasla.Text = "BAŞLA";
            this.labelBasla.Click += new System.EventHandler(this.labelBasla_Click);
            this.labelBasla.MouseLeave += new System.EventHandler(this.labelBasla_MouseLeave);
            this.labelBasla.MouseHover += new System.EventHandler(this.labelBasla_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 400);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelYilan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Yılan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelYilan;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelBasla;
        private System.Windows.Forms.Label labelBitir;
        private System.Windows.Forms.Label labelPuan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

