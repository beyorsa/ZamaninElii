namespace ZamaninEli.Desktop
{
    partial class MenuForm
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
            this.OyunuBaslat = new System.Windows.Forms.Button();
            this.HikayeAc = new System.Windows.Forms.Button();
            this.Top5 = new System.Windows.Forms.Button();
            this.oyuncuAdiTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OyunuBaslat
            // 
            this.OyunuBaslat.Location = new System.Drawing.Point(298, 144);
            this.OyunuBaslat.Name = "OyunuBaslat";
            this.OyunuBaslat.Size = new System.Drawing.Size(174, 49);
            this.OyunuBaslat.TabIndex = 0;
            this.OyunuBaslat.Text = "Başla";
            this.OyunuBaslat.UseVisualStyleBackColor = true;
            this.OyunuBaslat.Click += new System.EventHandler(this.OyunuBaslat_Click);
            // 
            // HikayeAc
            // 
            this.HikayeAc.Location = new System.Drawing.Point(298, 199);
            this.HikayeAc.Name = "HikayeAc";
            this.HikayeAc.Size = new System.Drawing.Size(174, 49);
            this.HikayeAc.TabIndex = 1;
            this.HikayeAc.Text = "Hikaye";
            this.HikayeAc.UseVisualStyleBackColor = true;
            this.HikayeAc.Click += new System.EventHandler(this.HikayeAc_Click);
            // 
            // Top5
            // 
            this.Top5.Location = new System.Drawing.Point(298, 254);
            this.Top5.Name = "Top5";
            this.Top5.Size = new System.Drawing.Size(174, 49);
            this.Top5.TabIndex = 2;
            this.Top5.Text = "En iyi 5 skor";
            this.Top5.UseVisualStyleBackColor = true;
            this.Top5.Click += new System.EventHandler(this.Top5_Click);
            // 
            // oyuncuAdiTextBox
            // 
            this.oyuncuAdiTextBox.Location = new System.Drawing.Point(298, 64);
            this.oyuncuAdiTextBox.Name = "oyuncuAdiTextBox";
            this.oyuncuAdiTextBox.Size = new System.Drawing.Size(174, 22);
            this.oyuncuAdiTextBox.TabIndex = 3;
            this.oyuncuAdiTextBox.Text = "isim";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oyuncuAdiTextBox);
            this.Controls.Add(this.Top5);
            this.Controls.Add(this.HikayeAc);
            this.Controls.Add(this.OyunuBaslat);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OyunuBaslat;
        private System.Windows.Forms.Button HikayeAc;
        private System.Windows.Forms.Button Top5;
        private System.Windows.Forms.TextBox oyuncuAdiTextBox;
    }
}