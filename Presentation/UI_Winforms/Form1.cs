using BusinessLogic.DTO.CashRegister;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WinForms_Desktop.Extensions;

namespace WinForms_Desktop
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            this.btnBrowse.Click += btnBrowse_Click;
            this.btnProcess.Click += btnProcess_Click;
            this.btnExport.Click += btnExport_Click;
            this.btnExport.Enabled = false;
        }
        #endregion

        #region Variables/Events    
        private const int C_RANDOM_DIV = 3;      
        #endregion

        #region Properties          
        #endregion

        #region EventHandlers
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.tbInput.Text = of.FileName;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.grdResults.Rows.Clear();
                this.btnExport.Enabled = false;

                List<string> errList = this.ValidateForm();
                if (errList.Count != 0)
                {
                    MessageBox.Show("Please correct the following errors:" + Environment.NewLine + Environment.NewLine +
                            errList.ListToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CashTransactionImportResult res = this.LoadTransactionData(this.tbInput.Text);

                    //Add successful transactions to the grid.
                    foreach (CashTransactionDTO t in res.ValidTransactions)
                    {
                        DataGridViewRow row = (DataGridViewRow)this.grdResults.RowTemplate.Clone();
                        row.CreateCells(this.grdResults, new object[] { t.Owed, t.Paid, t.Change, t.Change_Formatted_Verbose });
                        row.Tag = t;
                        this.grdResults.Rows.Add(row);
                    }

                    if (res.ErrorMessages.Count != 0)
                    {
                        MessageBox.Show("Process complete with errors:" + Environment.NewLine + Environment.NewLine +
                            res.ErrorMessages.ListToString(), "Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Process complete with no errors.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (res.ValidTransactions.Count != 0)
                    {
                        this.btnExport.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //This would be logged in a real scenario.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
            finally
            {
                this.Cursor = Cursors.Default;
            }       
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {              
                if (this.foldBrowse.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    //Grab data from grid and export.
                    CashTransactionImportResult data = new CashTransactionImportResult(this.tbInput.Text);
                    foreach (DataGridViewRow r in this.grdResults.Rows)
                    {
                        data.ValidTransactions.Add((CashTransactionDTO)r.Tag);
                    }
                    string outPathFile = this.ExportData(this.foldBrowse.SelectedPath.AddTrailingSlash(), data);
                    MessageBox.Show("Data exported to: " + outPathFile, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //This would be logged in a real scenario.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Methods
        private List<string> ValidateForm()
        {
            List<string> errList = new List<string>();

            if (this.tbInput.Text.Trim() == "")
            {
                errList.Add("Please select a transaction file to process.");
            }
            else
            {
                if (!File.Exists(this.tbInput.Text))
                {
                    errList.Add("The transaction file you selected does not exist.");
                }
            }

            return errList;
        }

        private CashTransactionImportResult LoadTransactionData(string pathFile)
        {
            DataAccess.CurrencyRepository r = new DataAccess.CurrencyRepository();
            DataAccess.DelimitedFileBasicValidationRepository v = new DataAccess.DelimitedFileBasicValidationRepository();
            BusinessLogic.CashRegister.Worker w = new BusinessLogic.CashRegister.Worker(r, v);

            return w.LoadTransactionData(pathFile, C_RANDOM_DIV);
        }

        private string ExportData(string path, CashTransactionImportResult data)
        {
            DataAccess.CurrencyRepository r = new DataAccess.CurrencyRepository();
            DataAccess.DelimitedFileBasicValidationRepository v = new DataAccess.DelimitedFileBasicValidationRepository();
            BusinessLogic.CashRegister.Worker w = new BusinessLogic.CashRegister.Worker(r, v);

            return w.ExportData(path, "ProcessedData_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + data.InputFile, data);
        }
        #endregion
    }
}