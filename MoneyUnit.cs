using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class MoneyUnit
    {
        string _name = "";
        string _pluralNmae = ""; 
        float _value = 0.0F;

        public MoneyUnit(string Name, string PluralName, float Value)
        {
            _name = Name;
            _pluralNmae = PluralName;
            _value = Value;
        }

        public string Name { get { return _name; } }
        public string PluralName { get { return _pluralNmae; } }
        public float Value { get { return _value; } }
    }


    interface iChange
    {
        float AmountOwed { get; set; }
        float AmountPaid { get; set; } 
        string ToString();
    }

    class Change:iChange 
    {
        float _amountOwed;
        float _amountPaid;

        public Change()
        {
            _amountOwed = 0;
            _amountPaid = 0;
        }

        public Change(float AmountOwed, float AmountPaid)
        {
            _amountOwed = AmountOwed;
            _amountPaid = AmountPaid;
        }

        public float AmountOwed
        {
            get { return _amountOwed; }
            set { _amountOwed = value; }
        }

        public float AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; }
        }

        public string ToString()
        {
            List<string> ChangeList = new List<string>();
            List<MoneyUnit> Denominations = new List<MoneyUnit>(new MoneyUnit[]
            {
            new MoneyUnit("Twenty","Twenties",20.00F),
            new MoneyUnit("Ten","Tens",10.00F),
            new MoneyUnit("Five","Five",5.00F),
            new MoneyUnit("Dollar","Dollars",1.00F),
            new MoneyUnit("Half Dollar","Half Dollars",0.50F),
            new MoneyUnit("Quarter","Quarters",0.25F),
            new MoneyUnit("Dime","Dimes",0.10F),
            new MoneyUnit("Nickel","Nickels",0.05F),
            new MoneyUnit("Penny","Pennies",0.01F)
            });

            int[] UnitCount = new int[Denominations.Count];

            double remainder = Math.Round(_amountPaid - _amountOwed, 2);

            if (remainder.Equals(0.0F))
            {
                return "No change returned.";
            }

            if (remainder < 0.0F)
            { 
                return "Insufficient amount paid.";
            }

            for (int idx = 0; idx < Denominations.Count; idx++)
            {
                UnitCount[idx] = 0;

                while (remainder >= Denominations[idx].Value)
                {
                    UnitCount[idx]++;
                    remainder = Math.Round(remainder - Denominations[idx].Value,2);
                }
            }

            for (int idx = 0; idx < Denominations.Count; idx++)
            {
                switch (UnitCount[idx])
                {
                    case 0:
                        break;
                    case 1:
                        ChangeList.Add("1 " + Denominations[idx].Name);
                        break;
                    default:
                        ChangeList.Add(String.Format("{0} {1}", UnitCount[idx], Denominations[idx].PluralName));
                        break;
                }
            }

            return String.Join(", ", ChangeList.ToArray());
        }
    }

    class ChangeRandomDinominations:iChange 
    {
        float _amountOwed;
        float _amountPaid;

        public ChangeRandomDinominations()
        {
            _amountOwed = 0;
            _amountPaid = 0;
        }

        public ChangeRandomDinominations(float AmountOwed, float AmountPaid)
        {
            _amountOwed = AmountOwed;
            _amountPaid = AmountPaid;
        }

        public float AmountOwed
        {
            get { return _amountOwed; }
            set { _amountOwed = value; }
        }

        public float AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; }
        }

        public string ToString()
        {
            List<string> ChangeList = new List<string>();
            List<MoneyUnit> Denominations = new List<MoneyUnit>(new MoneyUnit[]
            {
            new MoneyUnit("Twenty","Twenties",20.00F),
            new MoneyUnit("Ten","Tens",10.00F),
            new MoneyUnit("Five","Five",5.00F),
            new MoneyUnit("Dollar","Dollars",1.00F),
            new MoneyUnit("Half Dollar","Half Dollars",0.50F),
            new MoneyUnit("Quarter","Quarters",0.25F),
            new MoneyUnit("Dime","Dimes",0.10F),
            new MoneyUnit("Nickel","Nickels",0.05F),
            new MoneyUnit("Penny","Pennies",0.01F)
            });

            int[] UnitCount = new int[Denominations.Count];

            double remainder = Math.Round(_amountPaid - _amountOwed, 2);

            if (remainder.Equals(0.0F))
            {
                return "No change returned.";
            }

            if (remainder < 0.0F)
            {
                return "Insufficient amount paid.";
            }

            Random GenRandomNumber = new Random();

            while (remainder > 0)
            {
                int rndIdx = GenRandomNumber.Next(Denominations.Count);
                 
                if (remainder >= Denominations[rndIdx].Value)
                {
                    UnitCount[rndIdx]++;
                    remainder = Math.Round(remainder - Denominations[rndIdx].Value, 2);
                }
            }

            for (int idx = 0; idx < Denominations.Count; idx++)
            {
                switch (UnitCount[idx])
                {
                    case 0:
                        break;
                    case 1:
                        ChangeList.Add("1 " + Denominations[idx].Name);
                        break;
                    default:
                        ChangeList.Add(String.Format("{0} {1}", UnitCount[idx], Denominations[idx].PluralName));
                        break;
                }
            }

            return String.Join(", ", ChangeList.ToArray());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
            { 
                System.Console.WriteLine("No input file specified.");
                return;
            }

            FileInfo inputFile = new FileInfo(args[0]);
            FileInfo outputFile = new FileInfo("ChangeOut.txt");
            TextReader fileReader = null;
            TextWriter fileWriter = null;

            if (!inputFile.Exists)
            {
                System.Console.WriteLine("Cannot find input file: " + inputFile.FullName);
                return;
            }

            try
            {
                fileReader = inputFile.OpenText();
            }
            catch
            {
                System.Console.WriteLine("Cannot open input file: " + inputFile.FullName);
                return;
            }

            try
            {
                fileWriter = outputFile.CreateText();
            }
            catch
            {
                System.Console.WriteLine("Cannot open output file: " + outputFile.FullName);
                return;
            }

            string lineIn = fileReader.ReadLine();

            while (!string.IsNullOrEmpty(lineIn))
            {
                float AmountOwed = 0;
                float AmountPaid = 0;
                string[] values = lineIn.Split(",".ToCharArray());
                iChange ChangeValue = null;

                if (values.Count() != 2 || !float.TryParse(values[0], out AmountOwed) || !float.TryParse(values[1], out AmountPaid))
                {
                    fileWriter.WriteLine("Invalid amounts in line: " + lineIn);
                    continue;
                }
                int differance = (int)(Math.Round(AmountPaid - AmountOwed, 2) * 100);

                if (differance % 3 != 0)
                {
                    ChangeValue = new Change(AmountOwed, AmountPaid);
                }
                else
                {
                    ChangeValue = new ChangeRandomDinominations(AmountOwed, AmountPaid);
                }

                string ChangeReturned = ChangeValue.ToString();

                fileWriter.WriteLine(ChangeReturned);
                lineIn = fileReader.ReadLine();

                ChangeValue = null;
            }

            fileReader.Close();
            fileWriter.Close();
        }
    }

}
