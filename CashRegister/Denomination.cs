namespace CashRegister
{
    /// <summary>
    /// Class that defines denominations of money to be used to give change
    /// </summary>
    public class Denomination
    {
        private int _count = 0;
        private readonly int _value;
        private readonly string _stringForOne;
        private readonly string _stringForMore;
        private string _display;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value of this denomination in cents</param>
        /// <param name="stringForOne">The label for one of this denomination</param>
        /// <param name="stringForMore">The label for two or more of this denomination</param>
        public Denomination(int value, string stringForOne, string stringForMore)
        {
            _value = value;
            _stringForOne = stringForOne;
            _stringForMore = stringForMore;
            _display = stringForMore;
        }

        /// <summary>
        /// The count of this denomination contained in the change
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                _display = value == 1 ? StringForOne : StringForMore;
            }
        }

        /// <summary>
        /// The value of this denomination in cents
        /// </summary>
        public int Value
        {
            get { return _value; }
        }

        /// <summary>
        /// The label for one of this denomination
        /// </summary>
        public string StringForOne
        {
            get { return _stringForOne; }
        }

        /// <summary>
        /// The label for two or more of this denomination
        /// </summary>
        public string StringForMore
        {
            get { return _stringForMore; }
        }

        /// <summary>
        /// The display value for the count and label of this denomination contained in the change
        /// </summary>
        public string Display
        {
            get { return string.Format("{0} {1}", _count, _display); }
        }
    }
}
