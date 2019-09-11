namespace WinForms_Desktop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.of = new System.Windows.Forms.OpenFileDialog();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.foldBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.colOwed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(162, 13);
            this.tbInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(748, 23);
            this.tbInput.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(811, 44);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(99, 26);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 16);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(70, 17);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Load File:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(917, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(48, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // of
            // 
            this.of.Filter = "Text Files|*.txt|All files|*.*";
            this.of.InitialDirectory = "C:\\";
            this.of.Title = "Select a transaction file to load";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 97);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(129, 17);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "Valid Transactions:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(811, 304);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // foldBrowse
            // 
            this.foldBrowse.Description = "Export to";
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.AllowUserToResizeColumns = false;
            this.grdResults.AllowUserToResizeRows = false;
            this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOwed,
            this.colPaid,
            this.colChangeDue,
            this.colChangeText});
            this.grdResults.Location = new System.Drawing.Point(162, 94);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersVisible = false;
            this.grdResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdResults.Size = new System.Drawing.Size(748, 201);
            this.grdResults.TabIndex = 3;
            // 
            // colOwed
            // 
            this.colOwed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "c";
            this.colOwed.DefaultCellStyle = dataGridViewCellStyle9;
            this.colOwed.FillWeight = 50F;
            this.colOwed.HeaderText = "Owed";
            this.colOwed.Name = "colOwed";
            this.colOwed.ReadOnly = true;
            // 
            // colPaid
            // 
            this.colPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "c";
            this.colPaid.DefaultCellStyle = dataGridViewCellStyle10;
            this.colPaid.FillWeight = 50F;
            this.colPaid.HeaderText = "Paid";
            this.colPaid.Name = "colPaid";
            this.colPaid.ReadOnly = true;
            // 
            // colChangeDue
            // 
            this.colChangeDue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "c";
            this.colChangeDue.DefaultCellStyle = dataGridViewCellStyle11;
            this.colChangeDue.FillWeight = 50F;
            this.colChangeDue.HeaderText = "Change Due";
            this.colChangeDue.Name = "colChangeDue";
            this.colChangeDue.ReadOnly = true;
            // 
            // colChangeText
            // 
            this.colChangeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Format = "c";
            this.colChangeText.DefaultCellStyle = dataGridViewCellStyle12;
            this.colChangeText.HeaderText = "Change Due Breakdown";
            this.colChangeText.Name = "colChangeText";
            this.colChangeText.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 343);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbInput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Process Cash Transactions";
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog of;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog foldBrowse;
        private System.Windows.Forms.DataGridView grdResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeText;
    }
}

