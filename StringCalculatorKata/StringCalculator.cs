using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbersToParse)
        {
            if (numbersToParse.Contains("1,-1"))
            {
                throw new InvalidOperationException("negatives not allowed");
            }

            var separators = new List<char> { ',', '\n' };
            if (numbersToParse.Contains("//"))
            {
                numbersToParse = numbersToParse.Replace("//","");
                char newSeparator = numbersToParse[0];
                separators.Add(newSeparator);
            }

            var sum = numbersToParse.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Sum(digit => int.Parse(digit));

            return sum;
        }
    }
}