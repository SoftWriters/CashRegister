namespace Cash_Register
{
    partial class CashRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashRegister));
            this.mainTblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.browseBtn = new System.Windows.Forms.Button();
            this.fileTxtBx = new System.Windows.Forms.TextBox();
            this.enterFileLbl = new System.Windows.Forms.Label();
            this.cashRegLbl = new System.Windows.Forms.Label();
            this.getChangeBtn = new System.Windows.Forms.Button();
            this.bottomStrip = new System.Windows.Forms.StatusStrip();
            this.changeLbl = new System.Windows.Forms.Label();
            this.changeTxtBx = new System.Windows.Forms.TextBox();
            this.mainTblPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTblPanel
            // 
            this.mainTblPanel.ColumnCount = 4;
            this.mainTblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.mainTblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.mainTblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.mainTblPanel.Controls.Add(this.browseBtn, 2, 1);
            this.mainTblPanel.Controls.Add(this.fileTxtBx, 1, 1);
            this.mainTblPanel.Controls.Add(this.enterFileLbl, 0, 1);
            this.mainTblPanel.Controls.Add(this.cashRegLbl, 1, 0);
            this.mainTblPanel.Controls.Add(this.getChangeBtn, 3, 1);
            this.mainTblPanel.Controls.Add(this.bottomStrip, 0, 3);
            this.mainTblPanel.Controls.Add(this.changeLbl, 0, 2);
            this.mainTblPanel.Controls.Add(this.changeTxtBx, 1, 2);
            this.mainTblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTblPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTblPanel.Name = "mainTblPanel";
            this.mainTblPanel.RowCount = 4;
            this.mainTblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.mainTblPanel.Size = new System.Drawing.Size(685, 261);
            this.mainTblPanel.TabIndex = 0;
            // 
            // browseBtn
            // 
            this.browseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.browseBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.browseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.browseBtn.Location = new System.Drawing.Point(499, 31);
            this.browseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(78, 27);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // fileTxtBx
            // 
            this.fileTxtBx.Location = new System.Drawing.Point(113, 33);
            this.fileTxtBx.Name = "fileTxtBx";
            this.fileTxtBx.Size = new System.Drawing.Size(362, 22);
            this.fileTxtBx.TabIndex = 0;
            this.fileTxtBx.TextChanged += new System.EventHandler(this.fileTxtBx_TextChanged);
            // 
            // enterFileLbl
            // 
            this.enterFileLbl.AutoSize = true;
            this.enterFileLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enterFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterFileLbl.Location = new System.Drawing.Point(3, 30);
            this.enterFileLbl.Name = "enterFileLbl";
            this.enterFileLbl.Size = new System.Drawing.Size(104, 30);
            this.enterFileLbl.TabIndex = 2;
            this.enterFileLbl.Text = "Select File";
            this.enterFileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cashRegLbl
            // 
            this.cashRegLbl.AutoSize = true;
            this.cashRegLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashRegLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashRegLbl.Location = new System.Drawing.Point(113, 0);
            this.cashRegLbl.Name = "cashRegLbl";
            this.cashRegLbl.Size = new System.Drawing.Size(362, 30);
            this.cashRegLbl.TabIndex = 1;
            this.cashRegLbl.Text = "Cash Register";
            this.cashRegLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getChangeBtn
            // 
            this.getChangeBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.getChangeBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.getChangeBtn.Enabled = false;
            this.getChangeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.getChangeBtn.Location = new System.Drawing.Point(577, 31);
            this.getChangeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.getChangeBtn.Name = "getChangeBtn";
            this.getChangeBtn.Size = new System.Drawing.Size(106, 27);
            this.getChangeBtn.TabIndex = 5;
            this.getChangeBtn.Text = "Get Change";
            this.getChangeBtn.UseVisualStyleBackColor = false;
            this.getChangeBtn.Click += new System.EventHandler(this.getChangeBtn_Click);
            // 
            // bottomStrip
            // 
            this.mainTblPanel.SetColumnSpan(this.bottomStrip, 4);
            this.bottomStrip.Location = new System.Drawing.Point(0, 239);
            this.bottomStrip.Name = "bottomStrip";
            this.bottomStrip.Size = new System.Drawing.Size(685, 22);
            this.bottomStrip.TabIndex = 4;
            this.bottomStrip.Text = "statusStrip1";
            // 
            // changeLbl
            // 
            this.changeLbl.AutoSize = true;
            this.changeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLbl.Location = new System.Drawing.Point(3, 60);
            this.changeLbl.Name = "changeLbl";
            this.changeLbl.Size = new System.Drawing.Size(104, 179);
            this.changeLbl.TabIndex = 6;
            this.changeLbl.Text = "Change";
            this.changeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changeTxtBx
            // 
            this.mainTblPanel.SetColumnSpan(this.changeTxtBx, 3);
            this.changeTxtBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeTxtBx.Location = new System.Drawing.Point(113, 63);
            this.changeTxtBx.Multiline = true;
            this.changeTxtBx.Name = "changeTxtBx";
            this.changeTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.changeTxtBx.Size = new System.Drawing.Size(569, 173);
            this.changeTxtBx.TabIndex = 7;
            // 
            // CashRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 261);
            this.Controls.Add(this.mainTblPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashRegister";
            this.Text = "Creative Cash Draw Solutions";
            this.mainTblPanel.ResumeLayout(false);
            this.mainTblPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTblPanel;
        private System.Windows.Forms.TextBox fileTxtBx;
        private System.Windows.Forms.Label enterFileLbl;
        private System.Windows.Forms.Label cashRegLbl;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.StatusStrip bottomStrip;
        private System.Windows.Forms.Button getChangeBtn;
        private System.Windows.Forms.Label changeLbl;
        private System.Windows.Forms.TextBox changeTxtBx;
    }
}

