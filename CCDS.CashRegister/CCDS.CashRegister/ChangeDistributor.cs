//distributes change given an amount and currency

using IdentityModel;
using System;
using System.Collections.Generic;

namespace CCDS.CashRegister
{
    public static class ChangeDistributor
    {
        public static long[] DistributeRandomDenominations(long overpay, long[] currency)
        {
            long[] change = new long[currency.Length];
            CryptoRandom rng = new CryptoRandom();
            while (overpay > 0)
            {
                //creates random currency that is <= overpay
                int randomNumber;
                do
                {
                    randomNumber = rng.Next(0, currency.Length);
                } while (currency[randomNumber] > overpay);

                //removes currency amount and increments the number of that currency in the change
                overpay -= currency[randomNumber];
                ++change[randomNumber];
            }

            return change;
        }

        public static long[] DistributeNormalDenominations(long overpay, long[] currency)
        {
            var change = new long[currency.Length];

            for (int i = 0; i < currency.Length; ++i)
            {
                while (overpay >= currency[i])
                {
                    //removes currency amount and increments the number of that currency in the change
                    overpay -= currency[i];
                    ++change[i];
                }
            }

            return change;
        }
    }
}