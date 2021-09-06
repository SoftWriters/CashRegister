using CashDrawer.Core.ChangeCalculatorFactories;
using CashDrawer.Core.Readers;
using CashDrawer.Core.Writers;

namespace CashDrawer.Core
{
    public class ChangeProcessor
    {
        private readonly IChangeCalculatorFactory _changeCalculatorFactory;


        public ChangeProcessor(IChangeCalculatorFactory changeCalculatorFactory)
        {
            _changeCalculatorFactory = changeCalculatorFactory;
        }


        public void Process(IInputReader reader, IOutputWriter writer)
        {
            while(reader.HaveMore)
            {
                var input = reader.Next();

                if (input.HasError)
                {
                    writer.WriteError(input.Error);
                }
                else if (input.Paid < input.Due)
                {
                    writer.WriteError("Underpayment");
                }
                else
                {
                    var calculator = _changeCalculatorFactory.GetChangeCalculator(input.Due);
                    var change = calculator.GetChange(input.Due, input.Paid);
                    writer.Write(change);
                }
            }
        }

    }
}
