using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Randomizer
{
    internal class CryptoRandom
    {
        internal static int Next(int max)
        {
            return Next(0, max);
        }

        internal static int Next(int min, int max)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int result = BitConverter.ToInt32(buffer, 0);

            return new Random(result).Next(min, max);
        }
    }
}