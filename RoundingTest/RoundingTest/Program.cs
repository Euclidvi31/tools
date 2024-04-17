using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingTest
{
    class Program
    {
        private const char Zero = '0';
        private const char Point = '.';
        private const string TrimTemplate = "0.###########";

        private const decimal RoundingTo = 0.01m;


        static void Main(string[] args)
        {
            //Console.WriteLine("Rouding 0.025 = " + Math.Round(0.025, 2));
            //Console.WriteLine("Rouding 0.0251 = " + Math.Round(0.0251, 2));
            //Console.WriteLine("Rouding 0.015 = " + Math.Round(0.015, 2));

            //Console.WriteLine("Rouding -0.025 = " + Math.Round(-0.025, 2));
            //Console.WriteLine("Rouding -0.0251 = " + Math.Round(-0.0251, 2));
            //Console.WriteLine("Rouding -0.015 = " + Math.Round(-0.015, 2));

            //Console.WriteLine("Rouding 0.025 = " + Round(0.025m));
            //Console.WriteLine("Rouding 0.0251 = " + Round(0.0251m));
            //Console.WriteLine("Rouding 0.015 = " + Round(0.015m));

            //Console.WriteLine("Rouding -0.025 = " + Round(-0.025m));
            //Console.WriteLine("Rouding -0.0251 = " + Round(-0.0251m));
            //Console.WriteLine("Rouding -0.015 = " + Round(-0.015m));

            //Console.WriteLine("RoundUp 0.025 = " + RoundUp(0.025m));
            //Console.WriteLine("RoundUp 0.0251 = " + RoundUp(0.0251m));
            //Console.WriteLine("RoundUp 0.015 = " + RoundUp(0.015m));

            //Console.WriteLine("RoundUp -0.025 = " + RoundUp(-0.025m));
            //Console.WriteLine("RoundUp -0.0251 = " + RoundUp(-0.0251m));
            //Console.WriteLine("RoundUp -0.015 = " + RoundUp(-0.015m));

            //Console.WriteLine("Rouding 105 = " + Round(105m));
            //Console.WriteLine("Rouding 105.1 = " + Round(105.1m));
            //Console.WriteLine("Rouding 115 = " + Round(115m));

            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);

            //foreach (var item in bag)
            //{
            //    Console.WriteLine(item);
            //}
            int a;
            while (bag.TryTake(out a))
            {
                Console.WriteLine(a);
            }
        }

        public static int IntPow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        public static decimal Round(decimal _value)
        {
            decimal ret = _value;

            if (!RoundingTo.Equals(Decimal.Zero))
            {
                int digit = GetPresicionNum();
                if (digit >= 0)
                {
                    // The default round beheavior is MidpointRounding.ToEven
                    // For example, if we set rounding to 1, then 1.5 will round to 2, 2.5 will round to 2
                    ret = Math.Round(_value, digit);
                }
                else
                {
                    int time = IntPow(10, (uint)Math.Abs(digit));
                    ret = Math.Round(_value / time) * time;
                }
            }

            return ret;
        }

        public static decimal RoundUp(decimal _value)
        {
            decimal ret = _value;

            if (!RoundingTo.Equals(Decimal.Zero))
            {
                int digit = GetPresicionNum();
                int time = IntPow(10, (uint)Math.Abs(digit));
                if (digit >= 0)
                {
                    ret = Math.Ceiling(_value * time) / time;
                }
                else
                {
                    ret = Math.Ceiling(_value / time) * time;
                }
            }

            return ret;
        }

        protected static int GetPresicionNum()
        {
            decimal value = Math.Abs(RoundingTo);
            Int32 ret = 0;

            String trimString = value.ToString(TrimTemplate, CultureInfo.InvariantCulture);
            int pointIdx = trimString.IndexOf(Point);

            if (pointIdx >= 0)
            {
                ret = trimString.Length - pointIdx - 1;
            }
            else
            {
                bool allzero = true;
                foreach (char c in trimString.Reverse())
                {
                    if (c.Equals(Zero))
                    {
                        ret--;
                    }
                    else
                    {
                        allzero = false;
                        break;
                    }
                }

                if (allzero)
                {
                    ret = 0;
                }
            }

            return ret;
        }
    }
}
