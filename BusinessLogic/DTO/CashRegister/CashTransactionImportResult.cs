using System.Collections.Generic;
using System.IO;

namespace BusinessLogic.DTO.CashRegister
{
    /// <summary>
    /// Results of a transaction file import.
    /// </summary>
    public class CashTransactionImportResult
    {
        #region Constructor
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="inputPathFile">Path and file to import.</param>
        public CashTransactionImportResult(string inputPathFile)
        {
            this.InputPathFile = inputPathFile;
            this.InputFile = Path.GetFileName(this.InputPathFile);
            this.ValidTransactions = new List<CashTransactionDTO>();
            this.ErrorMessages = new List<string>();
        }
        #endregion

        #region Variables/Events          
        #endregion

        #region Properties   
        /// <summary>
        /// Import data path and file name.
        /// </summary>
        public string InputPathFile { get; private set; }

        /// <summary>
        /// Import data file name without the path.
        /// </summary>
        public string InputFile { get; private set; }
                
        /// <summary>
        /// Processed transactions or empty list.
        /// </summary>
        public List<CashTransactionDTO> ValidTransactions { get; set; }

        /// <summary>
        /// Error messages or empty list.
        /// </summary>
        public List<string> ErrorMessages { get; set; }     
        #endregion

        #region Methods
        #endregion
    }
}