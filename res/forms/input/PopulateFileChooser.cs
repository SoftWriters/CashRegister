// This class populates the open file menu by adding dynamic CheckBox controls to the panel (corresponding with the selected file directory, by default, or as chosen at runtime).
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace CCDS.res.forms.input
{
    internal static class PopulateFileChooser
    {
        public static void AddFilesToPanel(Panel panel)
        {
            int x_Offset = 75, y_Offset = 10, idx = 0;
            if (Program.TextFilesChecked || Program.CsvFilesChecked)
            {
                panel.Controls.OfType<Label>().ToList().Where(lbl => lbl.Name == $"NoFilesFoundLabel").ToList().ForEach(lbl => lbl.Visible = false);
                CreateDynamicCheckboxesFromFileDirectory(panel, x_Offset, y_Offset, idx);
            }
            else
            {
                panel.Controls.OfType<Label>().ToList().Where(lbl => lbl.Name == $"NoFilesFoundLabel").ToList().ForEach(lbl => lbl.Visible = true);
            }
        }
        public static void CreateDynamicCheckbox(Panel panel, int x, int y, int i, string fileInfoName)
        {
            var dynamic_Client_CheckBox = new CheckBox();
            dynamic_Client_CheckBox.Location = new Point(x, y); // Initialized x_Offset to 75, y_Offset to 10.  [Column 1]
            SetDynamicCheckboxTextualInfo(fileInfoName, dynamic_Client_CheckBox);
            SetDynamicCheckboxLookAndFeel(dynamic_Client_CheckBox);
            panel.Controls.Add(dynamic_Client_CheckBox);
        }
        public static void CreateDynamicCheckboxesFromFileDirectory(Panel panel, int x, int y, int i)
        {
            bool directoryHasNoMatchingFileTypes = true; //number of omissions
            foreach (string file in Directory.GetFiles(Program.OpenFileDirectory))
            {
                var fileInformationFileName = new FileInfo(file).Name;
                string txtSearchCriteria = $".TXT", csvSearchCriteria = $".CSV";
                bool omitIncrementation = false;
                if (Program.TextFilesChecked && !(Program.CsvFilesChecked))
                {
                    if (fileInformationFileName.ToUpper().Contains(txtSearchCriteria)) CreateDynamicCheckbox(panel, x, y, i, fileInformationFileName);
                    else omitIncrementation = true;
                }
                else if (!(Program.TextFilesChecked) && Program.CsvFilesChecked)
                {
                    if (fileInformationFileName.ToUpper().Contains(csvSearchCriteria)) CreateDynamicCheckbox(panel, x, y, i, fileInformationFileName);
                    else omitIncrementation = true;
                }
                else
                {
                    if (fileInformationFileName.ToUpper().Contains(txtSearchCriteria) || fileInformationFileName.ToUpper().Contains(csvSearchCriteria)) CreateDynamicCheckbox(panel, x, y, i, fileInformationFileName);
                    else omitIncrementation = true;
                }
                if (omitIncrementation) continue;
                directoryHasNoMatchingFileTypes = false;
                x += 300;
                i++;
                if ((i % 2 == 0)) // [2-column display]
                {
                    x = 75; // Re-Initialize x_Offset to 75.
                    y += 30; //Keep incrementing y_Offset.
                }
            }
            if (directoryHasNoMatchingFileTypes) panel.Controls.OfType<Label>().ToList().Where(lbl => lbl.Name == $"NoFilesFoundLabel").ToList().ForEach(lbl => lbl.Visible = true);
        }
        public static ArrayList GetListOfSelectedFlatFiles(Panel panel)
        {
            ArrayList selectedFiles = new ArrayList();
            panel.Controls.OfType<CheckBox>().ToList().Where(chk => chk.Name != $"TextFilesOptionCheckBox" && chk.Name != $"CSVFilesOptionCheckBox").ToList().ForEach(chk =>
            {
                if (chk.Checked) selectedFiles.Add(chk.Name.Replace($"___EXT___", $"."));
            });
            return selectedFiles;
        }
        public static void RemoveFilesFromPanel(Panel panel) => panel.Controls.OfType<CheckBox>().ToList().Where(chk => chk.Name != $"TextFilesOptionCheckBox" && chk.Name != $"CSVFilesOptionCheckBox").ToList().ForEach(chk => panel.Controls.Remove(chk));
        public static void SetDynamicCheckboxLookAndFeel(CheckBox chk)
        {
            chk.Font = new Font(new FontFamily("Arial Rounded MT Bold"), 12);
            chk.ForeColor = Color.FromArgb(29, 29, 29);
            chk.Checked = false;
            chk.Size = new Size(225, 25);
        }
        public static void SetDynamicCheckboxTextualInfo(string fileInfoName, CheckBox chk)
        {
            var fileName = fileInfoName;
            chk.Name = fileName.Replace($".", $"___EXT___");
            if (fileName.Length > 22)
            {
                fileName = fileName.Remove(19, (fileName.Length - 19));
                fileName += $"...";
            }
            chk.Text = fileName;
        }
    }
}