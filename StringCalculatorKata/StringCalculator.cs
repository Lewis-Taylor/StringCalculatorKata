using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbersToParse)
        {
            var sum = 0;

            if (numbersToParse == string.Empty)
            {
                return sum;
            }

            var separators = new[] { ',','\n' };

            sum = numbersToParse.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Sum(digit => int.Parse(digit));

            return sum;
        }
    }
}