using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StrFmt
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 10000;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < times; i++)
            {
                StrFmtV1("This is a test %1, %2, %3", "first", "second", "third");
            }
            sw.Stop();
            Console.WriteLine(string.Format("StrFmtV1 cost: {0}ms", sw.ElapsedMilliseconds));

            sw.Restart();
            for (int i = 0; i < times; i++)
            {
                StrFmtV2("This is a test %1, %2, %3", "first", "second", "third");
            }
            sw.Stop();
            Console.WriteLine(string.Format("StrFmtV2 cost: {0}ms", sw.ElapsedMilliseconds));

            sw.Restart();
            for (int i = 0; i < times; i++)
            {
                StrFmtV3("This is a test %1, %2, %3", "first", "second", "third");
            }
            sw.Stop();
            Console.WriteLine(string.Format("StrFmtV3 cost: {0}ms", sw.ElapsedMilliseconds));

            sw.Restart();
            for (int i = 0; i < times; i++)
            {
                string.Format("This is a test {0}, {1}, {2}", "first", "second", "third");
            }
            sw.Stop();
            Console.WriteLine(string.Format("System format cost: {0}ms", sw.ElapsedMilliseconds));
        }

        #region StrFmtV1
        public static string StrFmtV1(string format, params object[] parameters)
        {
            // abc%1, abc
            if (format == null)
            {
                return null;
            }
            string csharpFormat = format
                .Replace("{", "{{")
                .Replace("}", "}}");

            Regex reg = new Regex(@"%(\d+)");

            Match m = reg.Match(csharpFormat);
            int i = 0;
            while (m.Success && i < parameters.Length)
            {
                int xppIndex = int.Parse(m.Groups[1].Value);
                csharpFormat = csharpFormat.Replace("%" + xppIndex, "{" + (xppIndex - 1) + "}");
                m = reg.Match(csharpFormat);
                i++;
            }
            return string.Format(csharpFormat, parameters.Select(PreProcessObjectBeforeFormatting).ToArray());
        }
        #endregion

        #region StrFmtV2

        readonly static Regex ReplaceQuot = new Regex(@"%(\d+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static string StrFmtV2(string format, params object[] parameters)
        {
            if (format == null)
            {
                return null;
            }
            string csharpFormat = format
                .Replace("{", "{{")
                .Replace("}", "}}");

            Match m = ReplaceQuot.Match(csharpFormat);
            int i = 0;
            while (m.Success && i < parameters.Length)
            {
                int xppIndex = int.Parse(m.Groups[1].Value);
                csharpFormat = csharpFormat.Replace("%" + xppIndex, "{" + (xppIndex - 1) + "}");
                m = ReplaceQuot.Match(csharpFormat);
                i++;
            }
            return string.Format(csharpFormat, parameters.Select(PreProcessObjectBeforeFormatting).ToArray());
        }
        #endregion

        #region StrFmtV3
        public static string StrFmtV3(string format, params object[] parameters)
        {
            if (format == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder(format.Length + parameters.Length * 8);

            int pos = 0;
            int len = format.Length;
            char ch = '\x0';

            while (true)
            {
                while (pos < len)
                {
                    ch = format[pos];
                    pos++;

                    if (ch == '%' && pos < len && format[pos] >= '0' && format[pos] <= '9')
                    {
                        break;
                    }

                    sb.Append(ch);
                }

                if (pos == len)
                {
                    break;
                }

                int index = 0;
                int i = pos;
                while (pos < len && (ch = format[pos]) >= '0' && ch <= '9')
                {
                    index = index * 10 + ch - '0';
                    pos++;
                }

                // X++ index start from 1
                if (index > parameters.Length)
                {
                    sb.Append('%');
                    for (; i < pos; i++)
                    {
                        sb.Append(format[i]);
                    }
                }
                else
                {
                    sb.Append(PreProcessObjectBeforeFormatting(parameters[index - 1]));
                }
            }

            return sb.ToString();
        }
        #endregion


        private static object PreProcessObjectBeforeFormatting(object parameter)
        {
            if (parameter is Enum)
            {
                return ((Enum)parameter).ToString();
            }
            else if (parameter is Decimal || parameter is Double)
            {
                return ((Decimal)parameter).ToString("F");
            }
            else
            {
                return parameter;
            }
            //return parameter.ToString();
        }
    }
}
