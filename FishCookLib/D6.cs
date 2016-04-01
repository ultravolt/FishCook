using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FishCookLib
{
    public class D6 : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;

        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
       }

        public static double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
       }

        private static int Next(int minValue, int maxValue)
        {
            int mv = maxValue + 1;
            return (int)Math.Round(NextDouble() * (mv - minValue - 1)) + minValue;
       }

        private static int Next()
        {
            return Next(0, Int32.MaxValue);
       }

        private int Next(int maxValue)
        {
            return Next(0, maxValue);
       }

        public static List<int> Roll(int number)
        {
            r=RandomNumberGenerator.Create();
            var cr = new D6();
            var rv = new List<int>();
            for (int i = 0; i < number; i++)
            {
                rv.Add(Next(1, 6));
           }
            return rv;
       }
   }
}
