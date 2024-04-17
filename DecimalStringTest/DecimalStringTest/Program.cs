using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace DecimalStringTest
{
    public enum TaxEngineTaxJournalType { Normal = 0, CustomerSettlement = 1, VendorSettlement = 2 }

    public enum NoYes
    {
        [Description("The name of No")]
        No = 0,
        [Description("The name of Yes")]
        Yes = 1
    }



    class Program
    {
        public static NoYes TryParseNoYes(string _value)
        {
            if (_value != null)
            {
                return (NoYes)Enum.Parse(typeof(NoYes), _value);
            }
            else
            {
                return NoYes.No;
            }
        }

        static void Main(string[] args)
        {
            //int PRECISION = 16;
            //decimal d = new decimal(1.22345);
            //System.Console.WriteLine(d.ToString());

            //string str = "1.223423123";
            //System.Console.WriteLine(Convert.ToDecimal(str));
            //decimal d1 = new decimal((double)1 / (double)3);
            //System.Console.WriteLine(d1);

            //string str1 = "0.0909090909090909";
            //decimal d2 = Convert.ToDecimal(str1);
            //System.Console.WriteLine(d2);
            //System.Console.WriteLine(str1);

            //decimal d3 = 1M / 3M;
            //System.Console.WriteLine(d3);

            //System.Console.WriteLine("===========================");

            //string str2 = "14815.3846153846153846?";
            //if (str2.IndexOf('.') > 0)
            //{
            //    int length = str2.IndexOf('.') + PRECISION + 1;
            //    str2 = str2.Substring(0, length < str2.Length ? length : str2.Length);
            //}
            //decimal d4 = Convert.ToDecimal(str2);
            //System.Console.WriteLine(d4);
            //System.Console.WriteLine(str2);

            //TaxEngineTaxJournalType test = (TaxEngineTaxJournalType) 0;
            //System.Console.WriteLine(test);

            //string yes = "Yes";

            //NoYes test; 
            ////bool result = Enum.TryParse<NoYes>(null, out test);

            //test = (NoYes)Enum.Parse(typeof(NoYes), yes);
            //System.Console.WriteLine(Enum.Parse(typeof(NoYes), null));

            //TaxEngineTaxJournalType test2 = TaxEngineTaxJournalType.CustomerSettlement;
            ////System.Console.WriteLine(test2.GetType() is Enum);
            //System.Console.WriteLine(Enum.GetName(typeof(TaxEngineTaxJournalType), test2));

            //NoYes test = TryParseNoYes(yes);
            //System.Console.WriteLine(test.ToString());
            //SerializeTest.ToJsonString();

            // test decimal to string with local
            //Decimal d = 109923.12234m;
            //Console.WriteLine("Decimal is: " + d);
            //String str = d.ToString();
            //Console.WriteLine("Decimal string is: " + str);
            //Console.WriteLine("Decimal string invariant is: " + d.ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine("Culture Info: " + Thread.CurrentThread.CurrentCulture);

            System.Console.WriteLine(NoYes.Yes);
        }
    }
}
