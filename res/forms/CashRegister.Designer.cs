namespace CCDS.res.forms
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
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code (*ahem* David was here.)
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashRegisterForm));
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.SavePictureBox = new System.Windows.Forms.PictureBox();
            this.BackPictureBox = new System.Windows.Forms.PictureBox();
            this.MinimizePictureBox = new System.Windows.Forms.PictureBox();
            this.ApplicationIconPictureBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ClosePictureBox = new System.Windows.Forms.PictureBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.InteractiveModeButton = new System.Windows.Forms.Button();
            this.ConsoleAlphaBlendTextBox = new ZBobb.AlphaBlendTextBox();
            this.OpenFileBillboardPanel = new System.Windows.Forms.Panel();
            this.DeselectPictureBox = new System.Windows.Forms.PictureBox();
            this.SelectAllPictureBox = new System.Windows.Forms.PictureBox();
            this.MenuPictureBox = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.OpenFilePanel = new System.Windows.Forms.Panel();
            this.NoFilesFoundLabel = new System.Windows.Forms.Label();
            this.OptionsTitleLabel = new System.Windows.Forms.Label();
            this.SettingsPictureBox = new System.Windows.Forms.PictureBox();
            this.UnselectAllFileTypesPictureBox = new System.Windows.Forms.PictureBox();
            this.SelectAllFileTypesPictureBox = new System.Windows.Forms.PictureBox();
            this.CSVFilePictureBox = new System.Windows.Forms.PictureBox();
            this.CSVFilesOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.TextFilePictureBox = new System.Windows.Forms.PictureBox();
            this.TextFilesOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.FileTypesOptionLabel = new System.Windows.Forms.Label();
            this.ChooseDirectoryButton = new System.Windows.Forms.Button();
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePictureBox)).BeginInit();
            this.OpenFileBillboardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeselectPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectAllPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.OpenFilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnselectAllFileTypesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectAllFileTypesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextFilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.TitlePanel.Controls.Add(this.SavePictureBox);
            this.TitlePanel.Controls.Add(this.BackPictureBox);
            this.TitlePanel.Controls.Add(this.MinimizePictureBox);
            this.TitlePanel.Controls.Add(this.ApplicationIconPictureBox);
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Controls.Add(this.ClosePictureBox);
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.MaximumSize = new System.Drawing.Size(650, 35);
            this.TitlePanel.MinimumSize = new System.Drawing.Size(650, 35);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(650, 35);
            this.TitlePanel.TabIndex = 49;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseDown);
            this.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseMove);
            this.TitlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseUp);
            // 
            // SavePictureBox
            // 
            this.SavePictureBox.BackgroundImage = global::CCDS.Properties.Resources.save_icon;
            this.SavePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SavePictureBox.InitialImage = global::CCDS.Properties.Resources.save_icon;
            this.SavePictureBox.Location = new System.Drawing.Point(527, 5);
            this.SavePictureBox.Name = "SavePictureBox";
            this.SavePictureBox.Size = new System.Drawing.Size(25, 25);
            this.SavePictureBox.TabIndex = 7;
            this.SavePictureBox.TabStop = false;
            this.SavePictureBox.Visible = false;
            this.SavePictureBox.Click += new System.EventHandler(this.SavePictureBox_Click);
            // 
            // BackPictureBox
            // 
            this.BackPictureBox.BackgroundImage = global::CCDS.Properties.Resources.back_icon;
            this.BackPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackPictureBox.InitialImage = global::CCDS.Properties.Resources.back_icon;
            this.BackPictureBox.Location = new System.Drawing.Point(557, 5);
            this.BackPictureBox.Name = "BackPictureBox";
            this.BackPictureBox.Size = new System.Drawing.Size(25, 25);
            this.BackPictureBox.TabIndex = 6;
            this.BackPictureBox.TabStop = false;
            this.BackPictureBox.Visible = false;
            this.BackPictureBox.Click += new System.EventHandler(this.BackPictureBox_Click);
            // 
            // MinimizePictureBox
            // 
            this.MinimizePictureBox.BackgroundImage = global::CCDS.Properties.Resources.minimize_icon;
            this.MinimizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizePictureBox.InitialImage = global::CCDS.Properties.Resources.minimize_icon;
            this.MinimizePictureBox.Location = new System.Drawing.Point(586, 5);
            this.MinimizePictureBox.Name = "MinimizePictureBox";
            this.MinimizePictureBox.Size = new System.Drawing.Size(25, 25);
            this.MinimizePictureBox.TabIndex = 5;
            this.MinimizePictureBox.TabStop = false;
            this.MinimizePictureBox.Click += new System.EventHandler(this.MinimizePictureBox_Click);
            // 
            // ApplicationIconPictureBox
            // 
            this.ApplicationIconPictureBox.BackgroundImage = global::CCDS.Properties.Resources.ccd_logo_24x24;
            this.ApplicationIconPictureBox.Location = new System.Drawing.Point(9, 5);
            this.ApplicationIconPictureBox.Name = "ApplicationIconPictureBox";
            this.ApplicationIconPictureBox.Size = new System.Drawing.Size(27, 26);
            this.ApplicationIconPictureBox.TabIndex = 4;
            this.ApplicationIconPictureBox.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TitleLabel.Location = new System.Drawing.Point(40, 7);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(420, 22);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Creative Cash Draw Solutions: Cash Register";
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseDown);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseMove);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CashRegisterForm_MouseUp);
            // 
            // ClosePictureBox
            // 
            this.ClosePictureBox.BackgroundImage = global::CCDS.Properties.Resources.close_icon;
            this.ClosePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClosePictureBox.InitialImage = global::CCDS.Properties.Resources.close_icon;
            this.ClosePictureBox.Location = new System.Drawing.Point(614, 5);
            this.ClosePictureBox.Name = "ClosePictureBox";
            this.ClosePictureBox.Size = new System.Drawing.Size(25, 25);
            this.ClosePictureBox.TabIndex = 0;
            this.ClosePictureBox.TabStop = false;
            this.ClosePictureBox.Click += new System.EventHandler(this.ClosePictureBox_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(96)))), ((int)(((byte)(140)))));
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFileButton.FlatAppearance.BorderSize = 0;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.OpenFileButton.Location = new System.Drawing.Point(0, 35);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(650, 65);
            this.OpenFileButton.TabIndex = 50;
            this.OpenFileButton.Text = "&Open File";
            this.OpenFileButton.UseVisualStyleBackColor = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            this.OpenFileButton.MouseEnter += new System.EventHandler(this.OpenFileButton_OnMouseEnter);
            this.OpenFileButton.MouseLeave += new System.EventHandler(this.OpenFileButton_OnMouseLeave);
            // 
            // InteractiveModeButton
            // 
            this.InteractiveModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(202)))), ((int)(((byte)(133)))));
            this.InteractiveModeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InteractiveModeButton.FlatAppearance.BorderSize = 0;
            this.InteractiveModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InteractiveModeButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InteractiveModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.InteractiveModeButton.Location = new System.Drawing.Point(0, 340);
            this.InteractiveModeButton.Margin = new System.Windows.Forms.Padding(0);
            this.InteractiveModeButton.Name = "InteractiveModeButton";
            this.InteractiveModeButton.Size = new System.Drawing.Size(650, 65);
            this.InteractiveModeButton.TabIndex = 51;
            this.InteractiveModeButton.Text = "&Interactive Mode";
            this.InteractiveModeButton.UseVisualStyleBackColor = false;
            this.InteractiveModeButton.Click += new System.EventHandler(this.Interactive_Mode_Button_Click);
            this.InteractiveModeButton.MouseEnter += new System.EventHandler(this.InteractiveModeButton_Inactive_OnMouseEnter);
            this.InteractiveModeButton.MouseLeave += new System.EventHandler(this.InteractiveModeButton_Inactive_OnMouseLeave);
            // 
            // ConsoleAlphaBlendTextBox
            // 
            this.ConsoleAlphaBlendTextBox.BackAlpha = 70;
            this.ConsoleAlphaBlendTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ConsoleAlphaBlendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleAlphaBlendTextBox.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.ConsoleAlphaBlendTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ConsoleAlphaBlendTextBox.Location = new System.Drawing.Point(0, 100);
            this.ConsoleAlphaBlendTextBox.Multiline = true;
            this.ConsoleAlphaBlendTextBox.Name = "ConsoleAlphaBlendTextBox";
            this.ConsoleAlphaBlendTextBox.ReadOnly = true;
            this.ConsoleAlphaBlendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleAlphaBlendTextBox.Size = new System.Drawing.Size(650, 240);
            this.ConsoleAlphaBlendTextBox.TabIndex = 52;
            this.ConsoleAlphaBlendTextBox.TabStop = false;
            this.ConsoleAlphaBlendTextBox.Text = "PLEASE CHOOSE TO OPEN A FILE OR ENTER INTERACTIVE MODE...";
            this.ConsoleAlphaBlendTextBox.Visible = false;
            this.ConsoleAlphaBlendTextBox.GotFocus += new System.EventHandler(this.ConsoleAlphaBlendTextBox_Read_Only_GotFocus);
            this.ConsoleAlphaBlendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsoleAlphaBlendTextBox_KeyDown);
            this.ConsoleAlphaBlendTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConsoleAlphaBlendTextBox_KeyUp);
            this.ConsoleAlphaBlendTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConsoleAlphaBlendTextBox_MouseDown);
            this.ConsoleAlphaBlendTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConsoleAlphaBlendTextBox_MouseMove);
            this.ConsoleAlphaBlendTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ConsoleAlphaBlendTextBox_MouseUp);
            // 
            // OpenFileBillboardPanel
            // 
            this.OpenFileBillboardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.OpenFileBillboardPanel.Controls.Add(this.DeselectPictureBox);
            this.OpenFileBillboardPanel.Controls.Add(this.SelectAllPictureBox);
            this.OpenFileBillboardPanel.Controls.Add(this.MenuPictureBox);
            this.OpenFileBillboardPanel.Controls.Add(this.PictureBox1);
            this.OpenFileBillboardPanel.Controls.Add(this.Label2);
            this.OpenFileBillboardPanel.Controls.Add(this.Label1);
            this.OpenFileBillboardPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.OpenFileBillboardPanel.Location = new System.Drawing.Point(0, 35);
            this.OpenFileBillboardPanel.Name = "OpenFileBillboardPanel";
            this.OpenFileBillboardPanel.Size = new System.Drawing.Size(650, 66);
            this.OpenFileBillboardPanel.TabIndex = 53;
            this.OpenFileBillboardPanel.Visible = false;
            this.OpenFileBillboardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenFileBillboardPanel_Paint);
            // 
            // DeselectPictureBox
            // 
            this.DeselectPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeselectPictureBox.Image = global::CCDS.Properties.Resources.deselect_all;
            this.DeselectPictureBox.InitialImage = global::CCDS.Properties.Resources.deselect_all;
            this.DeselectPictureBox.Location = new System.Drawing.Point(622, 41);
            this.DeselectPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.DeselectPictureBox.Name = "DeselectPictureBox";
            this.DeselectPictureBox.Size = new System.Drawing.Size(16, 16);
            this.DeselectPictureBox.TabIndex = 7;
            this.DeselectPictureBox.TabStop = false;
            this.DeselectPictureBox.Click += new System.EventHandler(this.DeselectPictureBox_Click);
            // 
            // SelectAllPictureBox
            // 
            this.SelectAllPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllPictureBox.Image = global::CCDS.Properties.Resources.select_all;
            this.SelectAllPictureBox.InitialImage = global::CCDS.Properties.Resources.select_all;
            this.SelectAllPictureBox.Location = new System.Drawing.Point(595, 41);
            this.SelectAllPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllPictureBox.Name = "SelectAllPictureBox";
            this.SelectAllPictureBox.Size = new System.Drawing.Size(16, 16);
            this.SelectAllPictureBox.TabIndex = 6;
            this.SelectAllPictureBox.TabStop = false;
            this.SelectAllPictureBox.Click += new System.EventHandler(this.SelectAllPictureBox_Click);
            // 
            // MenuPictureBox
            // 
            this.MenuPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuPictureBox.Image = global::CCDS.Properties.Resources.menu;
            this.MenuPictureBox.InitialImage = global::CCDS.Properties.Resources.menu;
            this.MenuPictureBox.Location = new System.Drawing.Point(13, 16);
            this.MenuPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPictureBox.Name = "MenuPictureBox";
            this.MenuPictureBox.Size = new System.Drawing.Size(16, 16);
            this.MenuPictureBox.TabIndex = 4;
            this.MenuPictureBox.TabStop = false;
            this.MenuPictureBox.Click += new System.EventHandler(this.MenuPictureBox_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Location = new System.Drawing.Point(1158, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(64, 64);
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Label2.Location = new System.Drawing.Point(45, 31);
            this.Label2.Margin = new System.Windows.Forms.Padding(0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(124, 20);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Please select a file:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Label1.Location = new System.Drawing.Point(38, 13);
            this.Label1.Margin = new System.Windows.Forms.Padding(0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 18);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "File Setup";
            // 
            // OpenFilePanel
            // 
            this.OpenFilePanel.AutoScroll = true;
            this.OpenFilePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.OpenFilePanel.Controls.Add(this.NoFilesFoundLabel);
            this.OpenFilePanel.Controls.Add(this.OptionsTitleLabel);
            this.OpenFilePanel.Controls.Add(this.SettingsPictureBox);
            this.OpenFilePanel.Controls.Add(this.UnselectAllFileTypesPictureBox);
            this.OpenFilePanel.Controls.Add(this.SelectAllFileTypesPictureBox);
            this.OpenFilePanel.Controls.Add(this.CSVFilePictureBox);
            this.OpenFilePanel.Controls.Add(this.CSVFilesOptionCheckBox);
            this.OpenFilePanel.Controls.Add(this.TextFilePictureBox);
            this.OpenFilePanel.Controls.Add(this.TextFilesOptionCheckBox);
            this.OpenFilePanel.Controls.Add(this.FileTypesOptionLabel);
            this.OpenFilePanel.Controls.Add(this.ChooseDirectoryButton);
            this.OpenFilePanel.Controls.Add(this.DirectoryTextBox);
            this.OpenFilePanel.Controls.Add(this.DirectoryLabel);
            this.OpenFilePanel.Location = new System.Drawing.Point(0, 100);
            this.OpenFilePanel.Name = "OpenFilePanel";
            this.OpenFilePanel.Size = new System.Drawing.Size(650, 240);
            this.OpenFilePanel.TabIndex = 54;
            this.OpenFilePanel.Visible = false;
            this.OpenFilePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TestPanel_Paint);
            // 
            // NoFilesFoundLabel
            // 
            this.NoFilesFoundLabel.AutoSize = true;
            this.NoFilesFoundLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.NoFilesFoundLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.NoFilesFoundLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NoFilesFoundLabel.Location = new System.Drawing.Point(201, 109);
            this.NoFilesFoundLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NoFilesFoundLabel.Name = "NoFilesFoundLabel";
            this.NoFilesFoundLabel.Size = new System.Drawing.Size(242, 18);
            this.NoFilesFoundLabel.TabIndex = 18;
            this.NoFilesFoundLabel.Text = "No matching files were found!";
            this.NoFilesFoundLabel.Visible = false;
            // 
            // OptionsTitleLabel
            // 
            this.OptionsTitleLabel.AutoSize = true;
            this.OptionsTitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Underline);
            this.OptionsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.OptionsTitleLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.OptionsTitleLabel.Location = new System.Drawing.Point(58, 24);
            this.OptionsTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsTitleLabel.Name = "OptionsTitleLabel";
            this.OptionsTitleLabel.Size = new System.Drawing.Size(150, 22);
            this.OptionsTitleLabel.TabIndex = 17;
            this.OptionsTitleLabel.Text = "Folder Options:";
            this.OptionsTitleLabel.Visible = false;
            // 
            // SettingsPictureBox
            // 
            this.SettingsPictureBox.Image = global::CCDS.Properties.Resources.settings_cog;
            this.SettingsPictureBox.InitialImage = global::CCDS.Properties.Resources.settings_cog;
            this.SettingsPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SettingsPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPictureBox.Name = "SettingsPictureBox";
            this.SettingsPictureBox.Size = new System.Drawing.Size(99, 87);
            this.SettingsPictureBox.TabIndex = 16;
            this.SettingsPictureBox.TabStop = false;
            this.SettingsPictureBox.Visible = false;
            // 
            // UnselectAllFileTypesPictureBox
            // 
            this.UnselectAllFileTypesPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnselectAllFileTypesPictureBox.Image = global::CCDS.Properties.Resources.deselect_all;
            this.UnselectAllFileTypesPictureBox.InitialImage = global::CCDS.Properties.Resources.deselect_all;
            this.UnselectAllFileTypesPictureBox.Location = new System.Drawing.Point(544, 135);
            this.UnselectAllFileTypesPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.UnselectAllFileTypesPictureBox.Name = "UnselectAllFileTypesPictureBox";
            this.UnselectAllFileTypesPictureBox.Size = new System.Drawing.Size(16, 16);
            this.UnselectAllFileTypesPictureBox.TabIndex = 15;
            this.UnselectAllFileTypesPictureBox.TabStop = false;
            this.UnselectAllFileTypesPictureBox.Visible = false;
            this.UnselectAllFileTypesPictureBox.Click += new System.EventHandler(this.UnselectAllFileTypesPictureBox_Click);
            // 
            // SelectAllFileTypesPictureBox
            // 
            this.SelectAllFileTypesPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllFileTypesPictureBox.Image = global::CCDS.Properties.Resources.select_all;
            this.SelectAllFileTypesPictureBox.InitialImage = global::CCDS.Properties.Resources.select_all;
            this.SelectAllFileTypesPictureBox.Location = new System.Drawing.Point(517, 135);
            this.SelectAllFileTypesPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.SelectAllFileTypesPictureBox.Name = "SelectAllFileTypesPictureBox";
            this.SelectAllFileTypesPictureBox.Size = new System.Drawing.Size(16, 16);
            this.SelectAllFileTypesPictureBox.TabIndex = 14;
            this.SelectAllFileTypesPictureBox.TabStop = false;
            this.SelectAllFileTypesPictureBox.Visible = false;
            this.SelectAllFileTypesPictureBox.Click += new System.EventHandler(this.SelectAllFileTypesPictureBox_Click);
            // 
            // CSVFilePictureBox
            // 
            this.CSVFilePictureBox.BackgroundImage = global::CCDS.Properties.Resources.csv_icon;
            this.CSVFilePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CSVFilePictureBox.InitialImage = global::CCDS.Properties.Resources.csv_icon;
            this.CSVFilePictureBox.Location = new System.Drawing.Point(313, 130);
            this.CSVFilePictureBox.Name = "CSVFilePictureBox";
            this.CSVFilePictureBox.Size = new System.Drawing.Size(25, 25);
            this.CSVFilePictureBox.TabIndex = 13;
            this.CSVFilePictureBox.TabStop = false;
            this.CSVFilePictureBox.Visible = false;
            this.CSVFilePictureBox.Click += new System.EventHandler(this.CSVFilePictureBox_Click);
            // 
            // CSVFilesOptionCheckBox
            // 
            this.CSVFilesOptionCheckBox.AutoSize = true;
            this.CSVFilesOptionCheckBox.Checked = true;
            this.CSVFilesOptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CSVFilesOptionCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CSVFilesOptionCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.CSVFilesOptionCheckBox.Location = new System.Drawing.Point(342, 132);
            this.CSVFilesOptionCheckBox.Name = "CSVFilesOptionCheckBox";
            this.CSVFilesOptionCheckBox.Size = new System.Drawing.Size(158, 22);
            this.CSVFilesOptionCheckBox.TabIndex = 12;
            this.CSVFilesOptionCheckBox.Text = "CSV Files (*.csv)";
            this.CSVFilesOptionCheckBox.UseVisualStyleBackColor = true;
            this.CSVFilesOptionCheckBox.Visible = false;
            // 
            // TextFilePictureBox
            // 
            this.TextFilePictureBox.BackgroundImage = global::CCDS.Properties.Resources.txt_icon;
            this.TextFilePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextFilePictureBox.InitialImage = global::CCDS.Properties.Resources.txt_icon;
            this.TextFilePictureBox.Location = new System.Drawing.Point(133, 130);
            this.TextFilePictureBox.Name = "TextFilePictureBox";
            this.TextFilePictureBox.Size = new System.Drawing.Size(25, 25);
            this.TextFilePictureBox.TabIndex = 11;
            this.TextFilePictureBox.TabStop = false;
            this.TextFilePictureBox.Visible = false;
            this.TextFilePictureBox.Click += new System.EventHandler(this.TextFilePictureBox_Click);
            // 
            // TextFilesOptionCheckBox
            // 
            this.TextFilesOptionCheckBox.AutoSize = true;
            this.TextFilesOptionCheckBox.Checked = true;
            this.TextFilesOptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TextFilesOptionCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextFilesOptionCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.TextFilesOptionCheckBox.Location = new System.Drawing.Point(162, 132);
            this.TextFilesOptionCheckBox.Name = "TextFilesOptionCheckBox";
            this.TextFilesOptionCheckBox.Size = new System.Drawing.Size(150, 22);
            this.TextFilesOptionCheckBox.TabIndex = 10;
            this.TextFilesOptionCheckBox.Text = "Text Files (*.txt)";
            this.TextFilesOptionCheckBox.UseVisualStyleBackColor = true;
            this.TextFilesOptionCheckBox.Visible = false;
            // 
            // FileTypesOptionLabel
            // 
            this.FileTypesOptionLabel.AutoSize = true;
            this.FileTypesOptionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypesOptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.FileTypesOptionLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FileTypesOptionLabel.Location = new System.Drawing.Point(67, 132);
            this.FileTypesOptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FileTypesOptionLabel.Name = "FileTypesOptionLabel";
            this.FileTypesOptionLabel.Size = new System.Drawing.Size(61, 18);
            this.FileTypesOptionLabel.TabIndex = 4;
            this.FileTypesOptionLabel.Text = "Types:";
            this.FileTypesOptionLabel.Visible = false;
            // 
            // ChooseDirectoryButton
            // 
            this.ChooseDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ChooseDirectoryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseDirectoryButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.ChooseDirectoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ChooseDirectoryButton.Location = new System.Drawing.Point(514, 160);
            this.ChooseDirectoryButton.Name = "ChooseDirectoryButton";
            this.ChooseDirectoryButton.Size = new System.Drawing.Size(90, 35);
            this.ChooseDirectoryButton.TabIndex = 3;
            this.ChooseDirectoryButton.Text = "Choose";
            this.ChooseDirectoryButton.UseVisualStyleBackColor = false;
            this.ChooseDirectoryButton.Visible = false;
            this.ChooseDirectoryButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.DirectoryTextBox.Location = new System.Drawing.Point(132, 164);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.ReadOnly = true;
            this.DirectoryTextBox.Size = new System.Drawing.Size(375, 26);
            this.DirectoryTextBox.TabIndex = 2;
            this.DirectoryTextBox.TabStop = false;
            this.DirectoryTextBox.Visible = false;
            this.DirectoryTextBox.GotFocus += new System.EventHandler(this.DirectoryTextBox_GotFocus);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.DirectoryLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DirectoryLabel.Location = new System.Drawing.Point(40, 166);
            this.DirectoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(88, 18);
            this.DirectoryLabel.TabIndex = 1;
            this.DirectoryLabel.Text = "Directory:";
            this.DirectoryLabel.Visible = false;
            // 
            // CashRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CCDS.Properties.Resources.throbber_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(650, 405);
            this.Controls.Add(this.OpenFilePanel);
            this.Controls.Add(this.OpenFileBillboardPanel);
            this.Controls.Add(this.ConsoleAlphaBlendTextBox);
            this.Controls.Add(this.InteractiveModeButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashRegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SavePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePictureBox)).EndInit();
            this.OpenFileBillboardPanel.ResumeLayout(false);
            this.OpenFileBillboardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeselectPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectAllPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.OpenFilePanel.ResumeLayout(false);
            this.OpenFilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnselectAllFileTypesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectAllFileTypesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextFilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        internal System.Windows.Forms.Panel TitlePanel;
        internal System.Windows.Forms.PictureBox ApplicationIconPictureBox;
        internal System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.PictureBox ClosePictureBox;
        internal System.Windows.Forms.Button OpenFileButton;
        internal System.Windows.Forms.Button InteractiveModeButton;
        private ZBobb.AlphaBlendTextBox ConsoleAlphaBlendTextBox;
        internal System.Windows.Forms.PictureBox MinimizePictureBox;
        internal System.Windows.Forms.PictureBox BackPictureBox;
        internal System.Windows.Forms.Panel OpenFileBillboardPanel;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel OpenFilePanel;
        internal System.Windows.Forms.PictureBox MenuPictureBox;
        internal System.Windows.Forms.PictureBox DeselectPictureBox;
        internal System.Windows.Forms.PictureBox SelectAllPictureBox;
        private System.Windows.Forms.Button ChooseDirectoryButton;
        private System.Windows.Forms.TextBox DirectoryTextBox;
        internal System.Windows.Forms.Label DirectoryLabel;
        internal System.Windows.Forms.PictureBox CSVFilePictureBox;
        private System.Windows.Forms.CheckBox CSVFilesOptionCheckBox;
        internal System.Windows.Forms.PictureBox TextFilePictureBox;
        private System.Windows.Forms.CheckBox TextFilesOptionCheckBox;
        internal System.Windows.Forms.Label FileTypesOptionLabel;
        internal System.Windows.Forms.PictureBox UnselectAllFileTypesPictureBox;
        internal System.Windows.Forms.PictureBox SelectAllFileTypesPictureBox;
        internal System.Windows.Forms.PictureBox SettingsPictureBox;
        internal System.Windows.Forms.Label OptionsTitleLabel;
        internal System.Windows.Forms.Label NoFilesFoundLabel;
        internal System.Windows.Forms.PictureBox SavePictureBox;
    }
}

