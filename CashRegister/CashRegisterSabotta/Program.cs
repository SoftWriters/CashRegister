namespace CashRegisterSabotta
{
    /// <summary>
    /// Author:  Brian Sabotta
    /// Created: 10/29/2019
    /// Notes:   Created a separate project for application so that CashRegister dll can be easily referenced in other projects, as desired.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CashRegisterManager.RunCashRegisterProcessor(args);
        }
    }
}
