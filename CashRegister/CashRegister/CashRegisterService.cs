using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public interface ICashRegisterService
    {
        // Parameters are file paths, not the file name by itelf.
        void CalculateChangeFromFiles(string inputFilePath, string outputFilePath);
    }

    // Class defining the service that makes calls to the FileIOService, takes
    // the returned data and runs it through a register, and writes it to the output
    // file via the FileIOService. It serves as the highest layer, the opening to
    // the wild blue yonder. The inputs are file paths, not file names.
    public class CashRegisterService : ICashRegisterService
    {
        private ICashRegister CashRegister;
        private ICashTransactionFileIOService CashTransactionFileIOService;

        public CashRegisterService()
        {
            CashRegister = new SimpleCashRegister();
            CashTransactionFileIOService = new CashTransactionFileIOService();
        }

        public void CalculateChangeFromFiles(string inputFilePath, string outputFilePath)
        {
            try
            {
                List<CashTransaction> cashTransactions;
                cashTransactions = CashTransactionFileIOService.ReadFile(inputFilePath);
                CashRegister.CalculateChange(cashTransactions);
                try
                {
                    CashTransactionFileIOService.WriteFile(outputFilePath, cashTransactions);
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    Console.WriteLine("Could not find a directory in output file path \"" +
                        outputFilePath + "\"!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Could not find a directory in input file path \"" +
                    inputFilePath + "\"!");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Could not find file \"" +
                    inputFilePath + "\"!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }

}

