using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;

namespace Cash_Register
{
	public partial class frmCashRegister : Form
	{
		public frmCashRegister()
		{
			InitializeComponent();

			ofdInputFile.InitialDirectory = Directory.GetCurrentDirectory();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dr = ofdInputFile.ShowDialog();
				if (dr == DialogResult.OK)
				{
					Logic.LoadData(ofdInputFile.FileName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Error loading data - {0}", ex.Message));
			}
		}

		private void btnProcessData_Click(object sender, EventArgs e)
		{
			try
			{
				Logic.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Error processing data - {0}", ex.Message));
			}
		}

		private void btnSaveData_Click(object sender, EventArgs e)
		{
			try
			{
				txtChangeResults.Text = Logic.SaveData(String.Concat(ofdInputFile.FileName, ".output"));
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Error saving data - {0}", ex.Message));
			}
		}
	}
}
