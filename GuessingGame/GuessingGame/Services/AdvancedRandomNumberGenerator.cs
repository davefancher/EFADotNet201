using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GuessingGame.Services
{
    // http://www.lastaddress.net/2010/04/cryptographically-strong-random-number.html
    public class AdvancedRandomNumberGenerator
        : IRandomNumberGenerator
    {
        private readonly RNGCryptoServiceProvider _crypto =
            new RNGCryptoServiceProvider();

        int IRandomNumberGenerator.GetNext(int min, int max)
        {
            var buffer = new byte[4];
            _crypto.GetBytes(buffer);
            var rand = Math.Abs(BitConverter.ToInt32(buffer, 0));

            return Math.Abs(min + (rand % (max - min + 1)));
        }
    }
}
