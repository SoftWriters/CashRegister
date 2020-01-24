namespace CashRegister
{
    partial class CashRegisterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputFileTextBox = new System.Windows.Forms.TextBox();
            this.FileOpenButton = new System.Windows.Forms.Button();
            this.InputFileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.OutputFileGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.FlatFileInputGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadOutputFileLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.AboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.OutputFileGroupBox.SuspendLayout();
            this.FlatFileInputGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InputFileTextBox);
            this.groupBox1.Controls.Add(this.FileOpenButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open Input File";
            // 
            // InputFileTextBox
            // 
            this.InputFileTextBox.Location = new System.Drawing.Point(22, 31);
            this.InputFileTextBox.Multiline = true;
            this.InputFileTextBox.Name = "InputFileTextBox";
            this.InputFileTextBox.ReadOnly = true;
            this.InputFileTextBox.Size = new System.Drawing.Size(591, 31);
            this.InputFileTextBox.TabIndex = 1;
            // 
            // FileOpenButton
            // 
            this.FileOpenButton.Location = new System.Drawing.Point(619, 31);
            this.FileOpenButton.Name = "FileOpenButton";
            this.FileOpenButton.Size = new System.Drawing.Size(75, 31);
            this.FileOpenButton.TabIndex = 0;
            this.FileOpenButton.Text = "Open";
            this.FileOpenButton.UseVisualStyleBackColor = true;
            this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
            // 
            // InputFileOpenDialog
            // 
            this.InputFileOpenDialog.FileName = "openFileDialog1";
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceTextBox.Location = new System.Drawing.Point(22, 33);
            this.SourceTextBox.Multiline = true;
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.ReadOnly = true;
            this.SourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SourceTextBox.Size = new System.Drawing.Size(931, 182);
            this.SourceTextBox.TabIndex = 4;
            // 
            // OutputFileGroupBox
            // 
            this.OutputFileGroupBox.Controls.Add(this.ResultsTextBox);
            this.OutputFileGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFileGroupBox.Location = new System.Drawing.Point(20, 506);
            this.OutputFileGroupBox.Name = "OutputFileGroupBox";
            this.OutputFileGroupBox.Size = new System.Drawing.Size(981, 235);
            this.OutputFileGroupBox.TabIndex = 6;
            this.OutputFileGroupBox.TabStop = false;
            this.OutputFileGroupBox.Text = "Contents of Output File";
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsTextBox.Location = new System.Drawing.Point(28, 34);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ReadOnly = true;
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultsTextBox.Size = new System.Drawing.Size(931, 182);
            this.ResultsTextBox.TabIndex = 4;
            // 
            // FlatFileInputGroupBox
            // 
            this.FlatFileInputGroupBox.Controls.Add(this.SourceTextBox);
            this.FlatFileInputGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlatFileInputGroupBox.Location = new System.Drawing.Point(20, 246);
            this.FlatFileInputGroupBox.Name = "FlatFileInputGroupBox";
            this.FlatFileInputGroupBox.Size = new System.Drawing.Size(981, 235);
            this.FlatFileInputGroupBox.TabIndex = 5;
            this.FlatFileInputGroupBox.TabStop = false;
            this.FlatFileInputGroupBox.Text = "Contents of Input File";
            // 
            // DownloadOutputFileLinkLabel
            // 
            this.DownloadOutputFileLinkLabel.AutoSize = true;
            this.DownloadOutputFileLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadOutputFileLinkLabel.Location = new System.Drawing.Point(17, 761);
            this.DownloadOutputFileLinkLabel.Name = "DownloadOutputFileLinkLabel";
            this.DownloadOutputFileLinkLabel.Size = new System.Drawing.Size(175, 18);
            this.DownloadOutputFileLinkLabel.TabIndex = 7;
            this.DownloadOutputFileLinkLabel.TabStop = true;
            this.DownloadOutputFileLinkLabel.Text = "Download Output File ";
            this.DownloadOutputFileLinkLabel.Visible = false;
            this.DownloadOutputFileLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadOutputFileLinkLabel_LinkClicked);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(747, 151);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(98, 33);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLabel.Location = new System.Drawing.Point(112, 50);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(557, 27);
            this.InstructionsLabel.TabIndex = 9;
            this.InstructionsLabel.Text = "Please open an input file on your computer by pressing the \'Open\' button.";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(747, 190);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 33);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WelcomeLabel);
            this.panel1.Controls.Add(this.InstructionsLabel);
            this.panel1.Location = new System.Drawing.Point(134, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 84);
            this.panel1.TabIndex = 11;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(209, 15);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(290, 23);
            this.WelcomeLabel.TabIndex = 10;
            this.WelcomeLabel.Text = "Welcome to the Cash Register";
            // 
            // AboutLinkLabel
            // 
            this.AboutLinkLabel.AutoSize = true;
            this.AboutLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLinkLabel.Location = new System.Drawing.Point(864, 159);
            this.AboutLinkLabel.Name = "AboutLinkLabel";
            this.AboutLinkLabel.Size = new System.Drawing.Size(137, 15);
            this.AboutLinkLabel.TabIndex = 12;
            this.AboutLinkLabel.TabStop = true;
            this.AboutLinkLabel.Text = "About Cash Register";
            this.AboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutLinkLabel_LinkClicked);
            // 
            // CashRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1033, 793);
            this.Controls.Add(this.AboutLinkLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DownloadOutputFileLinkLabel);
            this.Controls.Add(this.OutputFileGroupBox);
            this.Controls.Add(this.FlatFileInputGroupBox);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "CashRegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creative Cash Draw Solutions - Cash Register  (Richard Keslar)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OutputFileGroupBox.ResumeLayout(false);
            this.OutputFileGroupBox.PerformLayout();
            this.FlatFileInputGroupBox.ResumeLayout(false);
            this.FlatFileInputGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog InputFileOpenDialog;
        private System.Windows.Forms.TextBox InputFileTextBox;
        private System.Windows.Forms.Button FileOpenButton;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.GroupBox OutputFileGroupBox;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.GroupBox FlatFileInputGroupBox;
        private System.Windows.Forms.LinkLabel DownloadOutputFileLinkLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.LinkLabel AboutLinkLabel;
    }
}

