namespace BusinessLogic.DTO.CashRegister
{
    /// <summary>
    /// Represents a cash transaction.
    /// </summary>
    public class CashTransactionDTO
    {
        #region Constructor
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="owed">Amount owed.</param>
        /// <param name="paid">Amount paid.</param>
        /// <param name="change">Change due.</param>
        /// <param name="changeVerbose">Change due as X Quarters, Y Dimes etc.</param>
        public CashTransactionDTO(decimal owed, decimal paid, decimal change, string changeVerbose)
        {
            this.Owed = owed;
            this.Paid = paid;
            this.Change = change;
            this.Change_Formatted_Verbose = changeVerbose;
        }
        #endregion

        #region Variables/Events 
        #endregion

        #region Properties     
        public decimal Owed { get; private set; }

        public string Owed_Formatted { get { return this.Owed.ToString("C"); } }

        public decimal Paid { get; private set; }

        public string Paid_Formatted { get { return this.Paid.ToString("C"); } }

        public decimal Change { get; private set; }

        public string Change_Formatted { get { return this.Change.ToString("C"); } }

        public string Change_Formatted_Verbose { get; private set; }
        #endregion

        #region Methods
        #endregion
    }
}