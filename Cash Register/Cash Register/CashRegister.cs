using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Cash_Register
{
    /// <summary>
    ///  This class tells the cashier how much change is owed, and what denominations should be used. 
    ///  The app will return the minimum amount of physical change in most cases.
    ///  If the amount owed is divisible by 3, the app will randomly generate the change denominations.
    /// </summary>
    public partial class CashRegister : Form
    {
        #region Declare Variables
        /// <summary>
        /// Provides a red circle error and message on the control passed to the
        /// SetError function of the error provider
        /// </summary>
        ErrorProvider error = new ErrorProvider();

        /// <summary>
        /// Provides the coin denominations to create change
        /// </summary>
        List<Coin> coinList = new List<Coin>() 
        {  
            new Coin(100, "dollar", "dollars"),
            new Coin(25, "quarter", "quarters"),
            new Coin(10, "dime", "dimes"),
            new Coin(5, "nickel", "nickels"),
            new Coin(1, "penny", "pennies")
        };
        #endregion Declare Variables

        #region Constructor

        /// <summary>
        /// Default constructor created to initialize GUI elements
        /// </summary>
        public CashRegister()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Button Clicks

        /// <summary>
        /// Occurs when the Browse button is clicked
        /// Allows the user to select a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseBtn_Click(object sender, EventArgs e)
        {
            /// Launches  file dialog for user selection
            OpenFileDialog getFileFD = new OpenFileDialog();
            /// Gets the result of user interaction with the window - OK, Cancel, etc.
            DialogResult result = getFileFD.ShowDialog();

            /// If the user chose OK
            if (result == DialogResult.OK)
            {
                /// Stores the filename in the file textbox for the user to view
                fileTxtBx.Text = getFileFD.FileName;
            }/// end if (result == DialogResult.OK)
        }/// private void browseBtn_Click(object sender, EventArgs e)

        /// <summary>
        /// Occurs when the Get Change button is clicked
        /// Gets the change denominations for the items
        /// in the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getChangeBtn_Click(object sender, EventArgs e)
        {
            /// Used to identify is a file is empty or does not
            /// contain any successful change transaction values
            int numOfLines = 0;
            /// Reads the file that was put into the Select File textbox
            using (StreamReader readFile = new StreamReader(fileTxtBx.Text))
            {   /// While there is data to read in the file
                while (!readFile.EndOfStream)
                {
                    /// Read the line
                    String cashRendered = readFile.ReadLine();

                    /// Ignore empty lines
                    if (!String.IsNullOrEmpty(cashRendered))
                    {    
                        /// If we have a value, process change transction
                        decimal cost;
                        decimal paid;
                        /// Gets the cost and paid values using the line read from the file
                        if (getCostAndPaidNums(cashRendered, out cost, out paid))
                        {
                            /// Subtract the cost from the paid to get the amount of change owed 
                            /// and make it a whole number by multiplying by 100
                            int changeToMake = Convert.ToInt32((paid - cost) * 100);
                            /// Get the amount of each coin denomination needed to make
                            /// the correct amount of change
                            List<int> changeAmounts = getChangeAmounts(cost, changeToMake);
                            /// Get the string to show the user
                            /// based on the coin denominations present
                            String changeToPrint = getPrintChange(changeAmounts);
                            /// Print the change amounts to the screen
                            printChange(changeToPrint);
                            /// Increment our line counter to display a success line process
                            numOfLines++;
                        }/// if (getCostAndPaidNums(cashRendered, out cost, out paid))
                    }/// if (!String.IsNullOrEmpty(cashRendered))
                }/// while (!readFile.EndOfStream)
            }/// using (StreamReader readFile = new StreamReader(fileTxtBx.Text)

            /// If we weren't able to successfully process any lines out of the file
            /// tell the user that they should consider choosing a different file
            if (numOfLines.Equals(0))
                MessageBox.Show(this, "Empty or invalid file. Please choose a different file.", "File Contents", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }/// private void getChangeBtn_Click(object sender, EventArgs e)

        #endregion Button Clicks

        #region Print

        /// <summary>
        /// Writes the change text or error message to the 
        /// change textbox by adding it to the existing
        /// text in that box
        /// </summary>
        /// <param name="changeToPrint">text to print out</param>
        private void printChange(String changeToPrint)
        {
            /// if there is nothing to write to the screen
            /// we can assume that there was no change to make
            if (string.IsNullOrEmpty(changeToPrint))
                changeTxtBx.Text += "Cost and paid values are equal. No change to make." + System.Environment.NewLine;
            else
                /// Write the string to the textbox
                changeTxtBx.Text += changeToPrint + System.Environment.NewLine;
        }/// private void printChange(String changeToPrint)

        /// <summary>
        /// Formats the coin denomination amounts 
        /// </summary>
        /// <param name="changeAmounts">number of each coin to print</param>
        /// <returns>string that includes coin amounts and names</returns>
        private String getPrintChange(List<int> changeAmounts)
        {
            /// Stores the line we are going to pass back
            String lineToPrint = String.Empty;
            /// Prints out line in the format: 3 quarters,1 dime,3 pennies
            for (int i = 0; i < coinList.Count(); i++)
            {
                /// Print only coin denominations that have more than 1 occurence
                if (changeAmounts.ElementAt(i) > 0)
                {   /// If we have something already stored in the line to print out
                    if (!String.IsNullOrEmpty(lineToPrint))
                        /// add a comma to add value separation
                        lineToPrint += ",";
                    /// Store the number of occurences of a coin and the coin name
                    lineToPrint += changeAmounts[i] + " " + coinList[i].CoinName(changeAmounts.ElementAt(i));
                }
            }
            return lineToPrint;
        }/// private String getPrintChange(List<int> changeAmounts)

        /// <summary>
        /// Gets the amount of change to be returned
        /// </summary>
        /// <param name="cost">the amount owed</param>
        /// <param name="changeToMake">the amount to be returned</param>
        /// <returns>the amount of each coin denomination to return</returns>
        private List<int> getChangeAmounts(decimal cost, int changeToMake)
        {
            /// Is the amount owed divisible by 3?
            int modOf3 = Convert.ToInt32(cost % 3);

            List<int> changeAmounts = new List<int>();
            /// If the amount owed is divisible by 3 
            if (modOf3.Equals(0))
            {   /// generate random change amounts
                changeAmounts = getRandomChange(changeToMake);
            }
            else
            {   /// get the smallest amount of physical change
                changeAmounts = getOptimalChange(changeToMake);
            }
            return changeAmounts;
        }/// private List<int> getChangeAmounts(decimal cost, int changeToMake)

        #endregion Print

        /// <summary>
        /// Gets the cost and paid amounts from the cashRendered value
        /// by spliting the line with a comma and returning the cost and 
        /// paid values
        /// </summary>
        /// <param name="cashRendered">cost,paid</param>
        /// <param name="cost">amount owed</param>
        /// <param name="paid">amount paid</param>
        /// <returns>amount owed and amount paid</returns>
        private Boolean getCostAndPaidNums(String cashRendered, out decimal cost, out decimal paid)
        {
            /// Splits a string value using the comma and results in division
            /// of elements in that string
            String[] cashSplit = cashRendered.Split(new char[] { ',' });

            /// Variables passed back to the calling function
            /// that contain the values parsed out of cashSplit
            cost = 0;
            paid = 0;

            /// If there are not 2 strings on the line
            /// return false and move on
            if (!cashSplit.Count().Equals(2))
                return false;

            /// Get the cost and paid amounts by 
            /// trying to parse the values previously split
            decimal.TryParse(cashSplit[0], out cost);
            decimal.TryParse(cashSplit[1], out paid);

            /// If the cost and paid are both positive values
            /// greater than 0, proceed
            if (cost > 0 && paid > 0)
            {
                return true;
            }/// if (cost > 0 && paid > 0)
            /// else we either have negative values or something
            /// non numeric such as text
            else
            {
                changeTxtBx.Text += "Cost and paid values not valid. Values must be positive and numeric." + System.Environment.NewLine;
                return false;
            }/// else
        }/// private Boolean getCostAndPaidNums(String cashRendered, out decimal cost, out decimal paid)

        /// <summary>
        /// Occurs when the selected file text is change
        /// Validates the existence of the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileTxtBx_TextChanged(object sender, EventArgs e)
        {
            /// If there is text in the file textbox and the file exists
            if (!String.IsNullOrEmpty(fileTxtBx.Text) && File.Exists(fileTxtBx.Text))
            {   /// Remove the errorprovider
                setGetChangeBtn(String.Empty);
            }
            else
            {   /// Show the error provider
                setGetChangeBtn("Please enter a valid path");
            }
        }/// private void fileTxtBx_TextChanged(object sender, EventArgs e)

        /// <summary>
        /// Sets the error provider message and
        /// enables/disables the get change button
        /// depending on whether we have a valid file in 
        /// the file textbox
        /// </summary>
        /// <param name="errorMsg">Message to set the the error provider</param>
        private void setGetChangeBtn(String errorMsg)
        {   /// Sets the error provider message
            error.SetError(fileTxtBx, errorMsg);
            /// Enables or disables the get change button
            getChangeBtn.Enabled = (error.GetError(fileTxtBx) == string.Empty);
        }/// private void setGetChangeBtn(String errorMsg)
         
        #region Optimal Change

        /// <summary>
        /// Gets the least amount of physical change to return
        /// </summary>
        /// <param name="changeToMake">amount of change to make</param>
        /// <returns>number of each coin to print</returns>
        private List<int> getOptimalChange(int changeToMake)
        {   /// Store the occurence of each coin
            List<int> changeAmounts = new List<int>();
            /// for each of the coins we are using
            for (int i = 0; i < coinList.Count(); i++)
            {   /// Get the occurence amount of that coin
                int changeAmount = changeToMake / coinList[i].Denomination;
                /// Add the amount to our occurence list
                changeAmounts.Add(changeAmount);
                /// Get the amount of remaining change to make with the
                /// remaining coins
                changeToMake = changeToMake % coinList[i].Denomination;
            }/// for (int i = 0; i < coinList.Count(); i++)

            return changeAmounts;
        }/// private List<int> getOptimalChange(int changeToMake)

        /// <summary>
        /// Gets the least amount of physical change to return for a randomly generated amount
        /// </summary>
        /// <param name="initialAmount">amount we are making change for</param>
        /// <param name="totalChange">the number of occurences of the coins for the given amounts</param>
        /// <returns></returns>
        private List<int> getOptimalChange(int initialAmount, ref List<List<int>> totalChange)
        {
            /// Gets a random amount using the initialAmount as the upper limit
            int randomAmount = getRandomAmount(initialAmount);
            /// get the smallest amount of physical change
            List<int> changeAmounts = getOptimalChange(randomAmount);
            /// Adds the occurences ot the coins for a given amount to our
            /// cumulative storage variable
            totalChange.Add(changeAmounts);

            /// Subtract the amount from the startingChange amount
            initialAmount = initialAmount - randomAmount;

            /// If we still owe more change, recursively call this function 
            /// to get the new coin occurence amounts
            if (initialAmount > 0)
                getOptimalChange(initialAmount, ref totalChange);

            return changeAmounts;
        }/// private List<int> getOptimalChange(int initialAmount, ref List<List<int>> totalChange)

        #endregion Optimal Change

        #region Random Change
        /// <summary>
        /// Gets random physical change amounts to provide to the user
        /// </summary>
        /// <param name="changeToMake">amount of change to make</param>
        /// <returns>number of each coin to print</returns>
        private List<int> getRandomChange(int changeToMake)
        {   /// the number of occurences of the coins for the given amounts
            List<List<int>> totalChange = new List<List<int>>();
            
            /// Gets the an amount of physical change for a randomly generated amount
            getOptimalChange(changeToMake, ref totalChange);

            /// corresponds to the coin index position in the coinlist
            int position = 0;
            ///number of each coin to print
            List<int> changeAmounts = new List<int>();
            /// foreach coin in the list
            foreach (Coin coin in coinList)
            {   /// selects the elements at a specified index (corresponds to coin index) and gets the sum
                /// of all of the values then adds it to be the total number we are printing of that coin
                changeAmounts.Add(totalChange.Select(coinIndex => coinIndex.ElementAt(position)).ToList().Sum());
                /// move to the next coin position
                position++;
            }/// foreach (Coin coin in coinList)
            return changeAmounts;
        }/// private List<int> getRandomChange(int changeToMake)

        /// <summary>
        /// Gets a random change amount passed on the randomUpperLimit passed in
        /// </summary>
        /// <param name="randomUpperLimit">highest amount that can be randomly generated</param>
        /// <returns></returns>
        private int getRandomAmount(int randomUpperLimit)
        {
            /// Variable that says we are generating a random number
            Random r = new Random();

            /// Stores the randomly generated value
            int randomAmount;
            /// Generates a random number from 0 to randomUpperLimit
            randomAmount = r.Next(randomUpperLimit);

            /// If the randomly generated number is 0
            if (randomAmount == 0)
            {   /// Use the upper limit as the random amount
                /// 0 is not valid
                randomAmount = randomUpperLimit;
            }/// if (randomAmount == 0)

            return randomAmount;
        }/// private int getRandomAmount(int randomUpperLimit)
         
        #endregion Random Change
    }/// public partial class CashRegister : Form
    #region Coin Class

    /// <summary>
    /// This class represents a coins value and name
    /// </summary>
    public class Coin : Form
    {
        #region Declare Coin Variables

        /// <summary>
        /// the amount the coin is worth
        /// </summary>
        public int Denomination { get; set; }
        /// <summary>
        /// the name called to 1 coin
        /// </summary>
        public String SingularName { get; set; }
        /// <summary>
        /// the name called to more than 1 coin
        /// </summary>
        public String PluralName { get; set; }

        #endregion Declare Coin Variables

        /// <summary>
        /// Returns the singular or plural name
        /// depedning on the number of items 
        /// passed in
        /// </summary>
        /// <param name="numOfItems">number of items</param>
        /// <returns>either the singular or plural name of the coin</returns>
        public String CoinName(int numOfItems)
        {   /// If there is 1 item
            if (numOfItems.Equals(1))
            {   /// Return the singular name
                return SingularName;
            }/// if (numOfItems.Equals(1))
            else
            {   /// Return the plural name
                return PluralName;
            }/// else
        }/// public String CoinName(int numOfItems)

        /// <summary>
        /// Constructor to create a new coin
        /// </summary>
        /// <param name="denomination">the amount the coin is worth</param>
        /// <param name="singularName">the name called to 1 coin</param>
        /// <param name="pluralName">the name called to more than 1 coin</param>
        public Coin(int denomination, String singularName, String pluralName)
        {
            /// Store the information in Coin variables
            Denomination = denomination;
            SingularName = singularName;
            PluralName = pluralName;
        }/// public Coin(int denomination, String singularName, String pluralName)
    }/// public class Coin : Form
    
    #endregion Coin Class
}/// namespace Cash_Register
