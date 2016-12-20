using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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

            sum = numbersToParse.Split(new[]{','},StringSplitOptions.RemoveEmptyEntries)
                .Sum(digit => int.Parse(digit));

            return sum;
        }
    }
}