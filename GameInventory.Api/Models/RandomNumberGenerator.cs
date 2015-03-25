using System;
using GameInventory.Api.Models.Interfaces;

namespace GameInventory.Api.Models
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random Rnd = new Random();

        public int GetRandomNumber(int maxValue)
        {
            return Rnd.Next(maxValue);
        }
    }
}
