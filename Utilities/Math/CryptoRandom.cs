using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Randomizer
{
    public class CryptoRandom: Random
    {
        public override int Next()
        {
            return CryptoNext(0, System.Int32.MaxValue);
        }

        public override int Next(int maxValue)
        {
            return CryptoNext(0, maxValue);
        }

        public override int Next(int minValue, int maxValue)
        {
            return CryptoNext(minValue, maxValue);
        }

        public override double NextDouble()
        {
            int nextInt = CryptoNext(0, System.Int32.MaxValue);
            return 1.0f * System.Int32.MaxValue / nextInt;
        }

        public override void NextBytes(byte[] buffer)
        {
            throw new NotImplementedException("NextBytes");
        }

        internal static int CryptoNext(int min, int max)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int result = BitConverter.ToInt32(buffer, 0);

            return new Random(result).Next(min, max);
        }
    }
}