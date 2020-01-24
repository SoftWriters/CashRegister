namespace CashRegister
{
    partial class AboutScreenForm
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
            this.LinkLabelClose = new System.Windows.Forms.LinkLabel();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinkLabelClose
            // 
            this.LinkLabelClose.AutoSize = true;
            this.LinkLabelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabelClose.Location = new System.Drawing.Point(263, 450);
            this.LinkLabelClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkLabelClose.Name = "LinkLabelClose";
            this.LinkLabelClose.Size = new System.Drawing.Size(48, 16);
            this.LinkLabelClose.TabIndex = 1;
            this.LinkLabelClose.TabStop = true;
            this.LinkLabelClose.Text = "Close";
            this.LinkLabelClose.VisitedLinkColor = System.Drawing.Color.Blue;
            this.LinkLabelClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClose_LinkClicked);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLabel.Location = new System.Drawing.Point(37, 32);
            this.InstructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(530, 402);
            this.InstructionsLabel.TabIndex = 2;
            this.InstructionsLabel.Text = "PopulatedInResourceFile";
            // 
            // AboutScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(608, 494);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.LinkLabelClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AboutScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkLabelClose;
        private System.Windows.Forms.Label InstructionsLabel;
    }
}