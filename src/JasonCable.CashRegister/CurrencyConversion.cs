using System;
using System.Collections.Generic;
using System.Text;

namespace JasonCable.CashRegister
{
    public static class CurrencyConversion
    {
        public const int PenniesToDollar = 100;
        public const int PenniesToQuarter = 25;
        public const int PenniesToDime = 10;
        public const int PenniesToNickel = 5;
        public const int NickelsToDime = 2;
        public const int NickelsToQuarter = 5;
        public const int NickelsToDollar = 20;
        public const int DimesToDollar = 10;
        public const int QuartersToDollar = 4;
        public const int OnesToFive = 5;
        public const int OnesToTen = 10;
        public const int OnesToTwenty = 20;
        public const int OnesToFifty = 50;
        public const int OnesToHundred = 100;
        public const int FivesToTen = 2;
        public const int FivesToTwenty = 4;
        public const int FivesToFifty = 10;
        public const int FivesToHundred = 20;
        public const int TensToTwenty = 2;
        public const int TensToFifty = 5;
        public const int TensToHundred = 10;
        public const int TwentiesToHundred = 5;
        public const int FiftiesToHundred = 2;

        public const int PenniesToFive = PenniesToDollar * OnesToFive;
        public const int PenniesToTen = PenniesToDollar * OnesToTen;
        public const int PenniesToTwenty = PenniesToDollar * OnesToTwenty;
        public const int PenniesToFifty = PenniesToDollar * OnesToFifty;
        public const int PenniesToHundred = PenniesToDollar * OnesToHundred;
    }
}
