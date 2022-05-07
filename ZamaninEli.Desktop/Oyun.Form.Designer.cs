namespace ZamaninEli.Desktop
{
    partial class OyunForm
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
            this.kalansure = new System.Windows.Forms.Label();
            this.bilgiPanel = new System.Windows.Forms.Panel();
            this.kazanilanGunLabel = new System.Windows.Forms.Label();
            this.elektrolizorLabel = new System.Windows.Forms.Label();
            this.oLabel = new System.Windows.Forms.Label();
            this.h2Label = new System.Windows.Forms.Label();
            this.uzayPanel = new System.Windows.Forms.Panel();
            this.bilgiPanel.SuspendLayout();
            this.uzayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kalansure
            // 
            this.kalansure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kalansure.Font = new System.Drawing.Font("Verdana", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kalansure.Location = new System.Drawing.Point(-18, 0);
            this.kalansure.Name = "kalansure";
            this.kalansure.Size = new System.Drawing.Size(147, 83);
            this.kalansure.TabIndex = 0;
            this.kalansure.Text = "120";
            this.kalansure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bilgiPanel
            // 
            this.bilgiPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bilgiPanel.Controls.Add(this.kazanilanGunLabel);
            this.bilgiPanel.Controls.Add(this.elektrolizorLabel);
            this.bilgiPanel.Controls.Add(this.oLabel);
            this.bilgiPanel.Controls.Add(this.h2Label);
            this.bilgiPanel.Controls.Add(this.kalansure);
            this.bilgiPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bilgiPanel.Location = new System.Drawing.Point(992, 0);
            this.bilgiPanel.Name = "bilgiPanel";
            this.bilgiPanel.Size = new System.Drawing.Size(129, 612);
            this.bilgiPanel.TabIndex = 2;
            // 
            // kazanilanGunLabel
            // 
            this.kazanilanGunLabel.AutoSize = true;
            this.kazanilanGunLabel.Location = new System.Drawing.Point(27, 141);
            this.kazanilanGunLabel.Name = "kazanilanGunLabel";
            this.kazanilanGunLabel.Size = new System.Drawing.Size(89, 16);
            this.kazanilanGunLabel.TabIndex = 4;
            this.kazanilanGunLabel.Text = "kazanılan gün";
            // 
            // elektrolizorLabel
            // 
            this.elektrolizorLabel.AutoSize = true;
            this.elektrolizorLabel.Location = new System.Drawing.Point(46, 217);
            this.elektrolizorLabel.Name = "elektrolizorLabel";
            this.elektrolizorLabel.Size = new System.Drawing.Size(14, 16);
            this.elektrolizorLabel.TabIndex = 3;
            this.elektrolizorLabel.Text = "0";
            // 
            // oLabel
            // 
            this.oLabel.AutoSize = true;
            this.oLabel.Location = new System.Drawing.Point(49, 330);
            this.oLabel.Name = "oLabel";
            this.oLabel.Size = new System.Drawing.Size(14, 16);
            this.oLabel.TabIndex = 2;
            this.oLabel.Text = "0";
            // 
            // h2Label
            // 
            this.h2Label.AutoSize = true;
            this.h2Label.Location = new System.Drawing.Point(46, 428);
            this.h2Label.Name = "h2Label";
            this.h2Label.Size = new System.Drawing.Size(14, 16);
            this.h2Label.TabIndex = 1;
            this.h2Label.Text = "0";
            // 
            // uzayPanel
            // 
            this.uzayPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uzayPanel.Controls.Add(this.bilgiPanel);
            this.uzayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uzayPanel.Location = new System.Drawing.Point(0, 0);
            this.uzayPanel.Name = "uzayPanel";
            this.uzayPanel.Size = new System.Drawing.Size(1121, 612);
            this.uzayPanel.TabIndex = 3;
            // 
            // OyunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 612);
            this.Controls.Add(this.uzayPanel);
            this.Name = "OyunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OyunForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OyunForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OyunForm_KeyDown);
            this.bilgiPanel.ResumeLayout(false);
            this.bilgiPanel.PerformLayout();
            this.uzayPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label kalansure;
        private System.Windows.Forms.Panel bilgiPanel;
        private System.Windows.Forms.Panel uzayPanel;
        private System.Windows.Forms.Label h2Label;
        private System.Windows.Forms.Label kazanilanGunLabel;
        private System.Windows.Forms.Label elektrolizorLabel;
        private System.Windows.Forms.Label oLabel;
    }
}

