using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class AboutScreenForm : Form
    {
        private string _errorMessage = string.Empty;

        #region Constructor

        /// <summary>
        /// Populate about screen from resource file
        /// </summary>
        public AboutScreenForm()
        {
            InitializeComponent();
            InstructionsLabel.Text = Props.ResourceManager.GetString("ProgramInformation");
        }

        #endregion Constructor

        #region Close About Screen

        /// <summary>
        /// Close about screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabelClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                _errorMessage = Props.ResourceManager.GetString("ErrorWhenClosingAboutForm");
                File.AppendAllText(Props.MessagesFile, DateTime.Now.ToString(CultureInfo.CurrentCulture) + @" - " + _errorMessage + Environment.NewLine + ex.Message + Environment.NewLine);
                throw;
            }
        }

        #endregion Close About Screen
    }
}