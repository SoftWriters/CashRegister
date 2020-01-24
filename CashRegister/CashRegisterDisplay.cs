using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CashRegister.Interfaces;

namespace CashRegister
{
    public partial class CashRegisterForm : Form
    {
        private readonly IProcessChangeGenerator _pcg;
        private string _errorMessage = string.Empty;

        #region Constructor

        public CashRegisterForm(IProcessChangeGenerator pcg)
        {
            // Assign dependencies to variables
            _pcg = pcg;

            InitializeComponent();

            // Set various form control properties
            SetControlProperties();
        }

        #endregion Constructor

        #region Input File Selection

        /// <summary>
        /// Open flat input file, call methods to process data, write data to screen and file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                    // Reset TextBoxes when input file is chosen
                    InputFileTextBox.Text = string.Empty;
                    ResultsTextBox.Text = string.Empty;

                    // Get path of input file
                    var filePath = openFileDialog.FileName;

                    // Populate TextBox next to file open button with path of input file selected
                    InputFileTextBox.Text = filePath;

                    // Populate Input TextBox with data from flat source file
                    SourceTextBox.Text = File.ReadAllText(filePath);

                    // Read file line by line, splitting valid entries on comma
                    var inputArr = File.ReadAllLines(filePath).Select(x => x.Split(','));

                    // Populate ResultsTextBox after processing change
                    ResultsTextBox.Text = _pcg.OutputChangeToCustomer(inputArr.ToList());

                    // Also write results to text file
                    DownloadOutputFileLinkLabel.Visible = true;
                    File.WriteAllText(Props.OutputFile, ResultsTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorSelectingInputFile");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Input File Selection

        #region Set Control Properties

        /// <summary>
        /// Set form control properties
        /// </summary>
        public void SetControlProperties()
        {
            try
            {
                // These controls are inside GroupBoxes.
                // Setting the font of a GroupBox title also sets it in any of its controls.
                // Control properties are explicitly set here for that reason.
                SourceTextBox.Font = new Font("Microsoft Sans Serif", 9.5f);
                ResultsTextBox.Font = new Font("Microsoft Sans Serif", 9.5f);
                FileOpenButton.Font = new Font("Microsoft Sans Serif", 8.5f);
                InputFileTextBox.Font = new Font("Microsoft Sans Serif", 9.5f);
            }
            catch (Exception e)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorSettingControlProperties");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + e.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Set Control Properties

        #region DownloadOutputFileLinkLabel LinkClicked

        /// <summary>
        /// Download output file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DownloadOutputFileLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Props.OutputFile);
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhileRunningProccessToDownloadOutputFile");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion DownloadOutputFileLinkLabel LinkClicked

        #region Exit Button Click

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhileExitingApplication");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Exit Button Click

        #region Reset Button  Click

        /// <summary>
        /// Reset form fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ResetButton_Click(object sender, EventArgs e)
        {
            try
            {
                InputFileTextBox.Text = string.Empty;
                SourceTextBox.Text = string.Empty;
                ResultsTextBox.Text = string.Empty;
                DownloadOutputFileLinkLabel.Visible = false;
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhileResettingFields");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Reset Button  Click

        #region About Cash Register LinkLabel

        /// <summary>
        /// Show about screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var aboutScreen = new AboutScreenForm();
                aboutScreen.ShowDialog();
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhenClickingAboutLabel");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion About Cash Register LinkLabel
    }
}