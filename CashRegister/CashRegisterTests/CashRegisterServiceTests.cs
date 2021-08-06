using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CashRegister;

namespace CashRegisterTests
{

    [TestClass]
    public class CashRegisterServiceTests
    {
        private CashRegisterService CashRegisterService;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            CashRegisterService = new CashRegisterService();
        }

        // The following tests are not unit tests. They rely on certain resources to be 
        // in certain places and certain resources not to be in certain places.
        [TestMethod]
        public void CalculateChange_WithInvalidInputPath_DirectoryNotFoundException()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "badinputfilepath\\GoodFormat.txt";
                string outputFile = "\\OutputFiles\\GoodFormat.txt";
                Console.SetOut(sw);
                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                string expected = string.Format("Could not find a directory in input file path \"" +
                    inputFile + "\"!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void CalculateChange_WithInvalidInputFileName_ThrowsFileNotFoundException()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "badinputfilename";
                string outputFile = "\\OutputFiles\\GoodFormat.txt";
                Console.SetOut(sw);
                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                string expected = string.Format("Could not find file \"" +
                    inputFile + "\"!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void CalculateChange_WithInvalidOutputPath_DirectoryNotFoundException()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "InputFiles\\GoodFormat.txt";
                string outputFile = "badoutputfilepath\\GoodFormat.txt";
                Console.SetOut(sw);
                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                string expected = string.Format("Could not find a directory in output file path \"" +
                        outputFile + "\"!{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void CalculateChange_WithBadFormatInputFile()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "InputFiles\\BadFormat.txt";
                string outputFile = "OutputFiles\\BadFormat.txt";
                Console.SetOut(sw);
                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                string expected = "\r\n\r\n\r\n\r\n\r\n\r\nError on Line number: 1\r\nRecord causing the problem: afjasd;kljfklamjkl,asfwr,2342343,34342k\r\nComplete exception information: FileHelpers.ConvertException: Error Converting 'afjasd;kljfklamjkl' to type: 'Decimal'. \r\n   at FileHelpers.ConvertHelpers.DecimalConverter.ParseString(String from)\r\n   at FileHelpers.ConvertHelpers.CultureConverter.StringToField(String from)\r\n   at FileHelpers.FieldBase.AssignFromString(ExtractedInfo fieldString, LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 2\r\nRecord causing the problem: asdfkamsd;fklaksdfklalf\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 2 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 3\r\nRecord causing the problem: kljeti34jr3klrmk23m4k342\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 3 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 4\r\nRecord causing the problem: asdlfjklasdfkladf\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 4 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 5\r\nRecord causing the problem: asdfaksdflkaldf\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 5 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 6\r\nRecord causing the problem: asdlfakldkf\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 6 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 7\r\nRecord causing the problem: amountOwed\r\nComplete exception information: amountOwed has more than two decimal places\r\n";
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void CalculateChange_WithGoodFormatInputFile()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "InputFiles\\GoodFormat.txt";
                string outputFile = "OutputFiles\\GoodFormat.txt";

                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                try
                {
                    using (StreamReader sr = new StreamReader(outputFile))
                    {
                        string result = sr.ReadToEnd();
                        string expected = "3 quarters,1 dime,3 pennies\r\n3 pennies\r\n1 dollar,2 quarters,1 dime,1 nickel,3 pennies\r\n13458 dollars,2 dimes,3 pennies\r\n";
                        Assert.AreEqual<string>(expected, result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Assert.Fail("Exceptiion occurned in reading output file.");
                }
            }
        }

        [TestMethod]
        public void CalculateChange_WithMixedGoodAndBadFormatInputFile()
        {
            using (StringWriter sw = new StringWriter())
            {
                string inputFile = "InputFiles\\MixedGoodAndBadFormat.txt";
                string outputFile = "OutputFiles\\MixedGoodAndBadFormat.txt";
                Console.SetOut(sw);

                CashRegisterService.CalculateChangeFromFiles(inputFile, outputFile);

                try
                {
                    using (StreamReader sr = new StreamReader(outputFile))
                    {
                        string resultFileOutput = sr.ReadToEnd();
                        string expectedFileOutput = "3 quarters,1 dime,3 pennies\r\n3 pennies\r\n1 dollar,2 quarters,1 dime,1 nickel,3 pennies\r\n";
                        Assert.AreEqual<string>(expectedFileOutput, resultFileOutput);

                        string resultConsuleOutput = sw.ToString();
                        string expectedConsoleOutput = "\r\n\r\n\r\nError on Line number: 1\r\nRecord causing the problem: This is nonsense\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 1 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 5\r\nRecord causing the problem: More nonsense\r\nComplete exception information: FileHelpers.FileHelpersException: Line: 5 Column: 0. Delimiter ',' not found after field 'AmountOwed' (the record has less fields, the delimiter is wrong or the next field must be marked as optional).\r\n   at FileHelpers.DelimitedField.BasicExtractString(LineInfo line)\r\n   at FileHelpers.DelimitedField.ExtractFieldString(LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 6\r\nRecord causing the problem: 45.667,34.99.0\r\nComplete exception information: FileHelpers.ConvertException: Error Converting '34.99.0' to type: 'Decimal'. \r\n   at FileHelpers.ConvertHelpers.DecimalConverter.ParseString(String from)\r\n   at FileHelpers.ConvertHelpers.CultureConverter.StringToField(String from)\r\n   at FileHelpers.FieldBase.AssignFromString(ExtractedInfo fieldString, LineInfo line)\r\n   at FileHelpers.FieldBase.ExtractFieldValue(LineInfo line)\r\n   at FileHelpers.RecordOperations.StringToRecord(Object record, LineInfo line, Object[] values)\r\n   at FileHelpers.FileHelperEngine`1.ReadStreamAsList(TextReader reader, Int32 maxRecords, DataTable dt)\r\nError on Line number: 7\r\nRecord causing the problem: amountOwed\r\nComplete exception information: amountOwed is greater than amountPaid\r\n";
                        Assert.AreEqual<string>(expectedConsoleOutput, resultConsuleOutput);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Assert.Fail("Exception occurned in reading output file.");
                }
            }
        }

    }
}
