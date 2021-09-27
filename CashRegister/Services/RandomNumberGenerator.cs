using System;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomInt(int minValue, int maxValue)
        {
            Random rand = new Random();

            return rand.Next(minValue, maxValue);
        }
    }
}