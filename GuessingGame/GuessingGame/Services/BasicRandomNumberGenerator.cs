using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessingGame.Services
{
    public class BasicRandomNumberGenerator
        : IRandomNumberGenerator
    {
        private readonly Random _rand = new Random();

        int IRandomNumberGenerator.GetNext(int min, int max) =>
            _rand.Next(min, max);
    }
}
