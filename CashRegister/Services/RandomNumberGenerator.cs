using System;
using CashRegister.Services.Interfaces;

namespace CashRegister.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomInt(int minValue, int maxValue)
        {
            Random rand = new Random();

            // +1 since maxValue for method is not inclusive
            return rand.Next(minValue, maxValue + 1);
        }
    }
}