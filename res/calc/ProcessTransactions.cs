//This class will process transactions sent from the UI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCDS.res.ctrls.console.io.input;
using CCDS.res.ctrls.console.io.input.exceptions;
using CCDS.res.ctrls.console.io.output;
using CCDS.res.currency.@base;

namespace CCDS.res.calc
{
    internal class ProcessTransactions
    {
        private List<Currency> _money;
        private Validate _validate;
        private Parser _parser;
        private string _operand;
        private bool _userInputIsNothing;
        public ProcessTransactions(Prompt cmd, string input)
        {
            List<Currency> money = new List<Currency>();
            var parser = new Parser();
            var validate = new Validate(); //parse and validate
            input = parser.RemoveAllWhitespaceFromString(input);
            var operands = parser.ParseOperands(input.Trim().Split(','));
            var totalDue = 0m;
            for (int i = 1; i < (operands.Length + 1); i++)
            {
                try
                {
                    _operand = operands[i - 1];
                    if (i % 2 == 0) //break the comma-delimited string into single operations
                    {
                        if (Program.ExceptionThrown)
                        {
                            Program.ExceptionThrown = false;
                            continue;
                        }
                        validate.Substantiation(_operand);
                        var amountPaid = parser.ParseDecimal(_operand);
                        validate.Equation(operands);
                        validate.Subtraction(totalDue, amountPaid);
                        money = new Transaction(cmd.GetConsole(), amountPaid, totalDue).GetMoney().Where(monetaryUnit => monetaryUnit.GetQuantity() > 0).ToList();  //don't include any thing unnecessary
                        StringBuilder dispStr = new StringBuilder(); //string formatting...
                        money.ToList().ForEach(monetaryUnit =>
                        {
                            if (monetaryUnit.GetQuantity() == 1) dispStr.Append(monetaryUnit.GetQuantity() + " " + monetaryUnit.GetSingularName() + ", ");
                            else dispStr.Append(monetaryUnit.GetQuantity() + " " + monetaryUnit.GetPluralName() + ", ");
                        });
                        if (!(money.ToList().Count == 0)) 
                        {
                            if (((operands.Length > 2) || Program.IsFileData) && ((i % 2) == 0) && !(Program.ExceptionThrown)) //Successful single operation among multiple operations (has more?)
                                lineFeedAdjustmentForMultiOperationalInput(cmd, operands, i); //Separate each operation on it's own prompt.
                            dispStr.Remove((dispStr.Length - 2), 2);
                            dispStr.Append(".");
                            cmd.GetConsole().AppendText(Program.CarriageReturnLineFeed);
                            cmd.GetConsole().AppendText(dispStr.ToString());
                        }
                    }
                    else
                    {
                        validate.Substantiation(_operand);
                        totalDue = parser.ParseDecimal(_operand);
                    }
                }
                //Exceptions fall down into here...
                catch (EmptyStringException)
                {
                    _userInputIsNothing = true;
                    Program.ExceptionThrown = true;
                }
                catch (NonCommaDelimitedStringException ncdse)
                {
                    exceptionHandler(cmd, operands, i, $"{ncdse.Message}");
                }
                catch (NegativeNumberException nne)
                {
                    exceptionHandler(cmd, operands, i, $"{nne.Message}");
                }
                catch (MissingOperandException moe)
                {
                    exceptionHandler(cmd, operands, i, $"{moe.Message}");
                }
                catch (OperandFormatException ofe)
                {
                    exceptionHandler(cmd, operands, i, $"{ofe.Message}");
                }
                catch (OperandEquationException)
                {
                    exceptionHandler(cmd, operands, i, $"{Program.CarriageReturnLineFeed}Exact change!");
                }
                catch (InvalidSubtractionException ise)
                {
                    exceptionHandler(cmd, operands, i, $"{ise.Message}");
                }
                catch (OverflowException)
                {
                    exceptionHandler(cmd, operands, i, $"{Program.CarriageReturnLineFeed}{_operand}{Program.CarriageReturnLineFeed}^ is too large.");
                }
                catch (FormatException)
                {
                    exceptionHandler(cmd, operands, i, $"{Program.CarriageReturnLineFeed}{_operand}{Program.CarriageReturnLineFeed}^ is not of type Decimal.");
                }
                catch (ArgumentNullException)
                {
                    ((Action) (() => { }))(); //noop  
                    Program.ExceptionThrown = true;
                }
                if (_userInputIsNothing) _userInputIsNothing = false;
                else
                {
                    if (((operands.Length > 2) || Program.IsFileData) && ((i % 2) != 0) && Program.ExceptionThrown) //multiple operations, exception on 1st operator
                    {
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if (((operands.Length > 2) || Program.IsFileData) && ((i % 2) == 0) && Program.ExceptionThrown) //multiple operation, exception on 2nd operator
                    {
                        cmd.GetConsole().AppendText($"{operands[i - 2]},{operands[i - 1]}");
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if (((operands.Length > 2) || Program.IsFileData) && ((i % 2) == 0) && !(Program.ExceptionThrown) && (operands.Length != i)) //Successful single operation among multiple operations (more to go)
                    {
                        ((Action)(() => { }))(); //noop  
                    }
                    else if (((operands.Length > 2) || Program.IsFileData) && !(Program.ExceptionThrown) && (operands.Length == i))
                    {
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if (((operands.Length > 2) || Program.IsFileData) && !(Program.ExceptionThrown) && (operands.Length == i))
                    {
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if ((operands.Length <= 2) && ((i % 2) == 0) && !(Program.ExceptionThrown)) // successful [single operation]
                    {
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if ((operands.Length <= 2) && ((i % 2) == 0) && Program.ExceptionThrown) // exception thrown on second operand [single operation]
                    {
                        Program.ExceptionThrown = false;
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                    else if ((operands.Length <= 2) && ((i % 2) != 0) && Program.ExceptionThrown) // exception thrown on first operand [single operation]
                    {
                        cmd.reInitializeText();
                        cmd.ResetCursorPosition();
                    }
                }
            }
        }
        public static void exceptionHandler(Prompt cmd, string[] arr, int idx, string msg)
        {
            if ((arr.Length > 2) && (idx >= 2) && ((idx % 2) == 0)) //Unsuccessful single operation, error on second operand, among multiple operations
            {
                lineFeedAdjustmentForMultiOperationalInput(cmd, arr, idx);
                cmd.GetConsole().AppendText(msg);
            }
            else if ((arr.Length > 2) && (idx >= 2) && ((idx % 2) != 0) && (idx != arr.Length)) //Unsuccessful single operation, error on first operand, among multiple operations with more to follow
            {
                lineFeedAdjustmentForMultiOperationalInput(cmd, arr, (idx + 1));
                cmd.GetConsole().AppendText(msg);
                Program.ExceptionThrown = true;
            }
            else
            {
                cmd.GetConsole().AppendText(msg);
                Program.ExceptionThrown = true;
            }
        }
        public static void lineFeedAdjustmentForMultiOperationalInput(Prompt cmd, string[] arr, int idx)
        {
            cmd.reInitializeText();
            cmd.ResetCursorPosition();
            cmd.GetConsole().AppendText($"{arr[idx - 2]},{arr[idx - 1]}");
        }
    }
}