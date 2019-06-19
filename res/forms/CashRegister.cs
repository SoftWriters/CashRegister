//Single Form Application: All the form-specific UI stuff is below.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CCDS.res.calc;
using CCDS.res.ctrls.console.io.output;
using CCDS.res.forms.animations;
using CCDS.res.forms.input;
using CCDS.res.forms.movement;
using CCDS.res.forms.transitions;
using CCDS.res.forms.traversal;
using CCDS.res.forms.traversal.screens;
namespace CCDS.res.forms
{
    public partial class CashRegisterForm : Form
    {
        private readonly Drag _drag;
        private Prompt _cmdPrompt;
        private List<AuditTrail> _trail;
        private string _consoleInput;
        public CashRegisterForm()
        {
            InitializeComponent();
            new BackgroundImage(this).Animate();
            _cmdPrompt = new Prompt(ConsoleAlphaBlendTextBox);
            _drag = new Drag(this);
            Shown += CashRegisterForm_Shown;
            InitializeStartScreen();
            _trail = new List<AuditTrail>(); //init trail
            _trail.Add(new StartScreen());
            _trail.Add(new InteractiveModeScreen());
            _trail.Add(new OpenFileModeScreen());
            _trail.Add(new OpenFileModeOptionsScreen());
            SetFileTypeCheckBoxSettings();
        }
        private void ActivateAndDisplayScreen(string name)
        {
            new Fade().Out(this);
            string previousScreen = ActiveScreenName;
            ActivateScreen(name);
            switch (ActiveScreenName)
            {
                case "INTERACTIVE_MODE_SCREEN":
                    BackPictureBox.Visible = true;
                    SavePictureBox.Visible = true;
                    InteractiveModeButton.BackColor = Color.FromArgb(44, 62, 80);
                    InteractiveModeButton.Text = "&Clear Screen";
                    InteractiveModeButton.MouseEnter += InteractiveModeButton_Active_OnMouseEnter;
                    InteractiveModeButton.MouseLeave += InteractiveModeButton_Active_OnMouseLeave;
                    OpenFileButton.Visible = false;
                    OpenFileBillboardPanel.Visible = false;
                    OpenFilePanel.Visible = false;
                    RefreshConsoleControl();
                    ConsoleAlphaBlendTextBox.TabStop = true;
                    ConsoleAlphaBlendTextBox.ReadOnly = false;
                    ConsoleAlphaBlendTextBox.Visible = true;
                    ConsoleAlphaBlendTextBox.Location = new Point(0, 35);
                    ConsoleAlphaBlendTextBox.Size = new Size(650, 305);
                    ConsoleAlphaBlendTextBox.TabStop = true;
                    _cmdPrompt.Clear();
                    break;
                case "OPEN_FILE_MODE_SCREEN":
                    switch (previousScreen)
                    {
                        case "OPEN_FILE_MODE_OPTIONS_SCREEN":
                            OpenFileBillboardPanel.Visible = true;
                            OpenFilePanel.Location = new Point(0, 100);
                            OpenFilePanel.Size = new Size(650, 240);
                            PopulateFileChooser.AddFilesToPanel(OpenFilePanel);
                            OpenFilePanel.Visible = true;
                            OpenFileButton.Visible = false;
                            ConsoleAlphaBlendTextBox.Visible = false;
                            SettingsPictureBox.Visible = false;
                            OptionsTitleLabel.Visible = false;
                            FileTypesOptionLabel.Visible = false;
                            TextFilePictureBox.Visible = false;
                            TextFilesOptionCheckBox.Visible = false;
                            CSVFilePictureBox.Visible = false;
                            CSVFilesOptionCheckBox.Visible = false;
                            SelectAllFileTypesPictureBox.Visible = false;
                            UnselectAllFileTypesPictureBox.Visible = false;
                            DirectoryLabel.Visible = false;
                            DirectoryTextBox.Text = Program.OpenFileDirectory;
                            DirectoryTextBox.Visible = false;
                            ChooseDirectoryButton.Visible = false;
                            InteractiveModeButton.BackColor = Color.FromArgb(38, 202, 133);
                            InteractiveModeButton.Text = "&Run";
                            InteractiveModeButton.MouseEnter += InteractiveModeButton_Inactive_OnMouseEnter;
                            InteractiveModeButton.MouseLeave += InteractiveModeButton_Inactive_OnMouseLeave;
                            SetFileTypeCheckBoxSettings();
                            break;
                        case "START_SCREEN":
                            BackPictureBox.Visible = true;
                            SavePictureBox.Visible = false;
                            PopulateFileChooser.AddFilesToPanel(OpenFilePanel);
                            OpenFileBillboardPanel.Visible = true;
                            OpenFilePanel.Visible = true;
                            OpenFileButton.Visible = false;
                            ConsoleAlphaBlendTextBox.Visible = false;
                            InteractiveModeButton.Text = "&Run";
                            break;
                    }
                    break;
                case "OPEN_FILE_MODE_OPTIONS_SCREEN":
                    OpenFileBillboardPanel.Visible = false;
                    PopulateFileChooser.RemoveFilesFromPanel(OpenFilePanel);
                    NoFilesFoundLabel.Visible = false;
                    OpenFilePanel.Location = new Point(0, 35);
                    OpenFilePanel.Size = new Size(650, 305);
                    SettingsPictureBox.Visible = true;
                    OptionsTitleLabel.Visible = true;
                    FileTypesOptionLabel.Visible = true;
                    TextFilePictureBox.Visible = true;
                    TextFilesOptionCheckBox.Visible = true;
                    CSVFilePictureBox.Visible = true;
                    CSVFilesOptionCheckBox.Visible = true;
                    SelectAllFileTypesPictureBox.Visible = true;
                    UnselectAllFileTypesPictureBox.Visible = true;
                    DirectoryLabel.Visible = true;
                    DirectoryTextBox.Text = Program.OpenFileDirectory;
                    DirectoryTextBox.Visible = true;
                    ChooseDirectoryButton.Visible = true;
                    InteractiveModeButton.BackColor = Color.FromArgb(44, 62, 80);
                    InteractiveModeButton.Text = "&Save Changes";
                    InteractiveModeButton.MouseEnter += InteractiveModeButton_Active_OnMouseEnter;
                    InteractiveModeButton.MouseLeave += InteractiveModeButton_Active_OnMouseLeave;
                    break;
                case "START_SCREEN":
                    switch (previousScreen)
                    {
                        case "INTERACTIVE_MODE_SCREEN":
                            RefreshConsoleControl();
                            InitializeStartScreen();
                            break;
                        case "OPEN_FILE_MODE_SCREEN":
                            OpenFileBillboardPanel.Visible = false;
                            OpenFilePanel.Visible = false;
                            InitializeStartScreen();
                            break;
                        case "OPEN_FILE_MODE_OPTIONS_SCREEN":
                            break;
                        case "START_SCREEN":
                            break;
                    }
                    break;
            }
            new Fade().In(this);
        }
        private void ActivateScreen(string name)
        {
            _trail.ForEach(screen => { screen.SetActiveStatus(false); });
            _trail.Where(screen => screen.GetScreenName() == name).ToList()
                .ForEach(screen => { screen.SetActiveStatus(true); });
        }
        private string ActiveScreenName
        {
            get
            {
                var activeScreen = _trail.Where(screen => screen.GetActiveStatus().Equals(true));
                return activeScreen.ToList().FirstOrDefault()?.GetScreenName();
            }
        }
        private void AddConsoleControl()
        {
            ConsoleAlphaBlendTextBox = new ZBobb.AlphaBlendTextBox();
            ConsoleAlphaBlendTextBox.BackAlpha = 70;
            ConsoleAlphaBlendTextBox.BackColor = Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))),
                ((int)(((byte)(29)))));
            ConsoleAlphaBlendTextBox.BorderStyle = BorderStyle.None;
            ConsoleAlphaBlendTextBox.Font = new Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            ConsoleAlphaBlendTextBox.ForeColor = Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))),
                ((int)(((byte)(241)))));
            ConsoleAlphaBlendTextBox.Location = new Point(0, 100);
            ConsoleAlphaBlendTextBox.Multiline = true;
            ConsoleAlphaBlendTextBox.Name = "ConsoleAlphaBlendTextBox";
            ConsoleAlphaBlendTextBox.ReadOnly = true;
            ConsoleAlphaBlendTextBox.ScrollBars = ScrollBars.Vertical;
            ConsoleAlphaBlendTextBox.Size = new Size(650, 240);
            ConsoleAlphaBlendTextBox.TabIndex = 52;
            ConsoleAlphaBlendTextBox.TabStop = false;
            ConsoleAlphaBlendTextBox.Text = string.Empty;
            ConsoleAlphaBlendTextBox.Visible = false;
            ConsoleAlphaBlendTextBox.GotFocus += ConsoleAlphaBlendTextBox_Read_Only_GotFocus;
            ConsoleAlphaBlendTextBox.KeyDown += ConsoleAlphaBlendTextBox_KeyDown;
            ConsoleAlphaBlendTextBox.KeyUp += ConsoleAlphaBlendTextBox_KeyUp;
            ConsoleAlphaBlendTextBox.MouseDown += ConsoleAlphaBlendTextBox_MouseDown;
            ConsoleAlphaBlendTextBox.MouseMove += ConsoleAlphaBlendTextBox_MouseMove;
            ConsoleAlphaBlendTextBox.MouseUp += ConsoleAlphaBlendTextBox_MouseUp;
            Controls.Add(ConsoleAlphaBlendTextBox);
        }
        private void BackPictureBox_Click(object sender, EventArgs e)
        {
            switch (ActiveScreenName)
            {
                case "INTERACTIVE_MODE_SCREEN":
                    ActivateAndDisplayScreen("START_SCREEN");
                    break;
                case "OPEN_FILE_MODE_SCREEN":
                    ActivateAndDisplayScreen("START_SCREEN");
                    break;
                case "OPEN_FILE_MODE_OPTIONS_SCREEN":
                    ActivateAndDisplayScreen("OPEN_FILE_MODE_SCREEN");
                    //don't save changes
                    break;
                case "START_SCREEN":
                    break;
            }
        }
        private void CashRegisterForm_MouseDown(object sender, MouseEventArgs e) => _drag.Enable();
        private void CashRegisterForm_MouseMove(object sender, MouseEventArgs e)
        {
            (_drag.IsEnabled() ? (Action) _drag.Move : (() => { }))();
            OpenFileBillboardPanel.Refresh();
            OpenFilePanel.Refresh();
        }
        // Mouse events hooked up here from the designer file to "trick" Windows into thinking that a Control on a form is the actual form...
        private void CashRegisterForm_MouseUp(object sender, MouseEventArgs e) => _drag.Disable();
        private void CashRegisterForm_Shown(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            new Fade().In(this);
        }
        private void ChooseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
                DirectoryTextBox.Text = folderDlg.SelectedPath;
        }
        private void ClosePictureBox_Click(object sender, EventArgs e)
        {
            new Fade().Out(this);
            Application.Exit();
        }
        private void ConsoleAlphaBlendTextBox_Read_Only_GotFocus(object sender, EventArgs e)
        {
            if (ConsoleAlphaBlendTextBox.ReadOnly)
                SendKeys.Send("{TAB}");
        }
        private void ConsoleAlphaBlendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _consoleInput = ConsoleAlphaBlendTextBox.Text.Substring(_cmdPrompt.GetPromptStartingPosition(), (ConsoleAlphaBlendTextBox.TextLength - _cmdPrompt.GetPromptStartingPosition())).Trim();
            }
            if (e.KeyCode == Keys.Left)
                if (_cmdPrompt.GetPromptStartingPosition() >= ConsoleAlphaBlendTextBox.SelectionStart) e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                if (ConsoleAlphaBlendTextBox.TextLength > _cmdPrompt.GetPromptStartingPosition()) ConsoleAlphaBlendTextBox.Text = ConsoleAlphaBlendTextBox.Text.Remove((ConsoleAlphaBlendTextBox.TextLength - 1), 1);
                ConsoleAlphaBlendTextBox.Select(ConsoleAlphaBlendTextBox.TextLength, 0);
                ConsoleAlphaBlendTextBox.ScrollToCaret();
            }
        }
        private void ConsoleAlphaBlendTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) new ProcessTransactions(_cmdPrompt, _consoleInput);
        }
        private void ConsoleAlphaBlendTextBox_MouseDown(object sender, EventArgs e)
        {
            ConsoleAlphaBlendTextBox.Select(ConsoleAlphaBlendTextBox.TextLength, 0);
            _drag.Enable();
        }
        private void ConsoleAlphaBlendTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            ConsoleAlphaBlendTextBox.Select(ConsoleAlphaBlendTextBox.TextLength, 0);
            (_drag.IsEnabled() ? (Action) _drag.Move : (() => { }))();
        }
        private void ConsoleAlphaBlendTextBox_MouseUp(object sender, EventArgs e) => _drag.Disable();
        private void CSVFilePictureBox_Click(object sender, EventArgs e) => CSVFilesOptionCheckBox.Checked = !(CSVFilesOptionCheckBox.Checked);
        private void DeselectPictureBox_Click(object sender, EventArgs e) => OpenFilePanel.Controls.OfType<CheckBox>().ToList().Where(chk => (chk.Name != $"TextFilesOptionCheckBox") && (chk.Name != $"CSVFilesOptionCheckBox")).ToList().ForEach(chk => chk.Checked = false);
        private void DirectoryTextBox_GotFocus(object sender, EventArgs e) => ((TextBox)sender).Parent.Focus();
        private void Interactive_Mode_Button_Click(object sender, EventArgs e)
        {
            switch (ActiveScreenName)
            {
                case "INTERACTIVE_MODE_SCREEN":
                    _cmdPrompt.Clear();
                    break;
                case "OPEN_FILE_MODE_SCREEN":
                    Program.IsFileData = true;
                    ActivateAndDisplayScreen("INTERACTIVE_MODE_SCREEN");
                    ConsoleAlphaBlendTextBox.Text = "";
                    ArrayList remainingFilesToProcess = PopulateFileChooser.GetListOfSelectedFlatFiles(OpenFilePanel);
                    while (remainingFilesToProcess.Count != 0)
                    {
                        _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}PROCESSING FILE: {remainingFilesToProcess[0]}");
                        try
                        {
                            string[] lines = File.ReadAllLines($"{Program.OpenFileDirectory}\\{remainingFilesToProcess[0]}"); // Read each line of the file and process one at a time for each file selected.
                            lines.ToList().ForEach(line => { new ProcessTransactions(_cmdPrompt, line); });
                        }
                        catch (IOException ioe)
                        {
                            _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}UNABLE TO PROCESS IN-USE FILE: {remainingFilesToProcess[0]}  {ioe.Message}");
                        }
                        catch (Exception ge)
                        {
                            _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}FILE PROCESSING FAILED: {ge.Message}");
                        }
                        remainingFilesToProcess.RemoveAt(0);
                    }
                    Program.IsFileData = false;
                    break;
                case "OPEN_FILE_MODE_OPTIONS_SCREEN":
                    Program.OpenFileDirectory = DirectoryTextBox.Text;
                    Program.TextFilesChecked = TextFilesOptionCheckBox.Checked;
                    Program.CsvFilesChecked = CSVFilesOptionCheckBox.Checked;
                    ActivateAndDisplayScreen("OPEN_FILE_MODE_SCREEN");
                    break;
                case "START_SCREEN":
                    ActivateAndDisplayScreen("INTERACTIVE_MODE_SCREEN");
                    break;
            }
        }
        private void InteractiveModeButton_Inactive_OnMouseLeave(object sender, EventArgs e) => InteractiveModeButton.BackColor = Color.FromArgb(38, 202, 133);
        private void InteractiveModeButton_Inactive_OnMouseEnter(object sender, EventArgs e) => InteractiveModeButton.BackColor = Color.FromArgb(39, 174, 96);
        private void InteractiveModeButton_Active_OnMouseLeave(object sender, EventArgs e) => InteractiveModeButton.BackColor = Color.FromArgb(44, 62, 80);
        private void InteractiveModeButton_Active_OnMouseEnter(object sender, EventArgs e) => InteractiveModeButton.BackColor = Color.FromArgb(53, 90, 116);
        private void InitializeStartScreen()
        {
            BackPictureBox.Visible = false;
            SavePictureBox.Visible = false;
            OpenFileButton.Visible = true;
            ConsoleAlphaBlendTextBox.Visible = true;
            ConsoleAlphaBlendTextBox.ScrollBars = ScrollBars.None;
            InteractiveModeButton.Visible = true;
            InteractiveModeButton.BackColor = Color.FromArgb(38, 202, 133);
            InteractiveModeButton.Text = "&Interactive Mode";
            InteractiveModeButton.MouseEnter += InteractiveModeButton_Inactive_OnMouseEnter;
            InteractiveModeButton.MouseLeave += InteractiveModeButton_Inactive_OnMouseLeave;
            ConsoleAlphaBlendTextBox.Location = new Point(0, 100);
            ConsoleAlphaBlendTextBox.Size = new Size(650, 240);
            ConsoleAlphaBlendTextBox.Text = Program.StartScreenText;
            ConsoleAlphaBlendTextBox.TabStop = false;
            var crLTimes5 =
                new string(Enumerable.Range(0, 5).SelectMany(x => Program.CarriageReturnLineFeed)
                    .ToArray()); //center align text
            ConsoleAlphaBlendTextBox.Text = $@"{crLTimes5}    {ConsoleAlphaBlendTextBox.Text}";
            ConsoleAlphaBlendTextBox.ReadOnly = true;
            InteractiveModeButton.Focus();
        }
        private void MenuPictureBox_Click(object sender, EventArgs e) => ActivateAndDisplayScreen("OPEN_FILE_MODE_OPTIONS_SCREEN");
        private void MinimizePictureBox_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void OpenFileBillboardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = OpenFileBillboardPanel.CreateGraphics();
            Rectangle panelRect = OpenFileBillboardPanel.ClientRectangle;
            Point bottomLeft = new Point(panelRect.Left, panelRect.Bottom - 1); //Bottom Left Most Point
            Point bottomRight = new Point(panelRect.Right - 1, panelRect.Bottom - 1); //Bottom Right Most Point
            Pen coloredPen = new Pen(Color.FromArgb(206, 214, 224));
            g.DrawLine(coloredPen, bottomLeft, bottomRight);  //I only wanted a bottom border...
        }
        private void OpenFileButton_Click(object sender, EventArgs e) => ActivateAndDisplayScreen("OPEN_FILE_MODE_SCREEN");
        private void OpenFileButton_OnMouseLeave(object sender, EventArgs e) => OpenFileButton.BackColor = Color.FromArgb(141, 96, 140);
        private void OpenFileButton_OnMouseEnter(object sender, EventArgs e) => OpenFileButton.BackColor = Color.FromArgb(155, 89, 182);
        private void RefreshConsoleControl()
        {
            RemoveConsoleControl();
            AddConsoleControl();
            _cmdPrompt = new Prompt(ConsoleAlphaBlendTextBox);
            _cmdPrompt.reInitializeText();
            _cmdPrompt.ResetCursorPosition();
        }
        private void RemoveConsoleControl() => Controls.Remove(ConsoleAlphaBlendTextBox);
        private void SavePictureBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
                Program.SaveFileDirectory = folderDlg.SelectedPath;
            else if (folderDlg.ShowDialog() == DialogResult.Cancel)
                _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}SAVE FILE OPERATION CANCELED");
            else if (folderDlg.ShowDialog() == DialogResult.Abort)
                _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}SAVE FILE OPERATION ABORTED");
            else
                _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}SAVE FILE OPERATION FAILED: Invalid Dialog result.");
            try
            {
                File.WriteAllText($"{Program.SaveFileDirectory}\\output.txt", ConsoleAlphaBlendTextBox.Text);
            }
            catch (UnauthorizedAccessException uae)
            {
                _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}SAVE FILE OPERATION FAILED: {uae.Message}");
            }
            catch (Exception ge)
            {
                _cmdPrompt.WriteInformationMessageToConsole($"{Program.CarriageReturnLineFeed}SAVE FILE OPERATION FAILED: {ge.Message}");
            }
        }
        private void SelectAllFileTypesPictureBox_Click(object sender, EventArgs e) => OpenFilePanel.Controls.OfType<CheckBox>().ToList().Where(chk => (chk.Name == $"TextFilesOptionCheckBox") || (chk.Name == $"CSVFilesOptionCheckBox")).ToList().ForEach(chk => chk.Checked = true);
        private void SelectAllPictureBox_Click(object sender, EventArgs e) => OpenFilePanel.Controls.OfType<CheckBox>().ToList().Where(chk => (chk.Name != $"TextFilesOptionCheckBox") && (chk.Name != $"CSVFilesOptionCheckBox")).ToList().ForEach(chk => chk.Checked = true);
        private void SetFileTypeCheckBoxSettings()
        {
            TextFilesOptionCheckBox.Checked = Program.TextFilesChecked;
            CSVFilesOptionCheckBox.Checked = Program.CsvFilesChecked;
        }
        private void TextFilePictureBox_Click(object sender, EventArgs e) => TextFilesOptionCheckBox.Checked = !(TextFilesOptionCheckBox.Checked);

        private void TestPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = OpenFilePanel.CreateGraphics();
            Rectangle panelRect = OpenFilePanel.ClientRectangle;
            Point topLeft = new Point(panelRect.Left, panelRect.Top); // Top Left Most Point 
            Point topRight = new Point(panelRect.Right - 1, panelRect.Top); //Top Right Most Point
            Pen coloredPen = new Pen(Color.FromArgb(206, 214, 224));
            g.DrawLine(coloredPen, topLeft, topRight);
        }
        private void UnselectAllFileTypesPictureBox_Click(object sender, EventArgs e) => OpenFilePanel.Controls.OfType<CheckBox>().ToList().Where(chk => (chk.Name == $"TextFilesOptionCheckBox") || (chk.Name == $"CSVFilesOptionCheckBox")).ToList().ForEach(chk => chk.Checked = false);
    }
}