namespace Cash_Register
{
	partial class frmCashRegister
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
			this.ofdInputFile = new System.Windows.Forms.OpenFileDialog();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.btnProcessData = new System.Windows.Forms.Button();
			this.btnSaveData = new System.Windows.Forms.Button();
			this.txtChangeResults = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(12, 12);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(75, 23);
			this.btnLoadData.TabIndex = 0;
			this.btnLoadData.Text = "Load Data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// btnProcessData
			// 
			this.btnProcessData.Location = new System.Drawing.Point(151, 12);
			this.btnProcessData.Name = "btnProcessData";
			this.btnProcessData.Size = new System.Drawing.Size(100, 23);
			this.btnProcessData.TabIndex = 1;
			this.btnProcessData.Text = "Process Data";
			this.btnProcessData.UseVisualStyleBackColor = true;
			this.btnProcessData.Click += new System.EventHandler(this.btnProcessData_Click);
			// 
			// btnSaveData
			// 
			this.btnSaveData.Location = new System.Drawing.Point(316, 12);
			this.btnSaveData.Name = "btnSaveData";
			this.btnSaveData.Size = new System.Drawing.Size(75, 23);
			this.btnSaveData.TabIndex = 2;
			this.btnSaveData.Text = "Save Data";
			this.btnSaveData.UseVisualStyleBackColor = true;
			this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
			// 
			// txtChangeResults
			// 
			this.txtChangeResults.Location = new System.Drawing.Point(12, 134);
			this.txtChangeResults.Multiline = true;
			this.txtChangeResults.Name = "txtChangeResults";
			this.txtChangeResults.Size = new System.Drawing.Size(379, 112);
			this.txtChangeResults.TabIndex = 3;
			// 
			// frmCashRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 326);
			this.Controls.Add(this.txtChangeResults);
			this.Controls.Add(this.btnSaveData);
			this.Controls.Add(this.btnProcessData);
			this.Controls.Add(this.btnLoadData);
			this.Name = "frmCashRegister";
			this.Text = "Cash Register";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdInputFile;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Button btnProcessData;
		private System.Windows.Forms.Button btnSaveData;
		private System.Windows.Forms.TextBox txtChangeResults;
	}
}

