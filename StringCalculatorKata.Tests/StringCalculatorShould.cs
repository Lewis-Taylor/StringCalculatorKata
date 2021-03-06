﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void ReturnZero_WhenAdding_GivenNoNumbers()
        {
            var NO_NUMBERS = string.Empty;

            var sum = StringCalculator.Add(NO_NUMBERS);

            sum.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("300",300)]
        public void ReturnInteger_WhenAdding_GivenSingleNumber(string singleNumber, int expectedSum)
        {
            var sum = StringCalculator.Add(singleNumber);

            sum.Should().Be(expectedSum);
        }
        
        [TestCase("1,2", 3)]
        [TestCase("2,2", 4)]
        [TestCase("2,3", 5)]
        public void ReturnSum_WhenAdding_GivenSingleDigitCommaSingleDigit(string singleDigitCommaSingleDigit, int expectedSum)
        {
            var sum = StringCalculator.Add(singleDigitCommaSingleDigit);

            sum.Should().Be(expectedSum);
        }

        [TestCase("200,3000", 3200)]
        [TestCase("2000,3000", 5000)]
        [TestCase("3000,3000", 6000)]
        public void ReturnSum_WhenAdding_GivenNumberCommaNumber(string numberCommaNumber, int expectedSum)
        {
            var sum = StringCalculator.Add(numberCommaNumber);

            sum.Should().Be(expectedSum);
        }

        [TestCase("200,200,200", 600)]
        [TestCase("2000,2000,2000", 6000)]
        [TestCase("20000,20000,20000", 60000)]
        [TestCase("100,200,1000,500", 1800)]
        public void ReturnSum_WhenAdding_GivenManyNumbers(string manyNumbers, int expectedSum)
        {
            var sum = StringCalculator.Add(manyNumbers);

            sum.Should().Be(expectedSum);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("2\n4,6", 12)]
        [TestCase("4\n8,12", 24)]
        public void Return_Sum_WhenAdding_GivenManyNumbersAndNewLine(string manyNumbers, int expectedSum)
        {
            var sum = StringCalculator.Add(manyNumbers);

            sum.Should().Be(expectedSum);
        }

        [TestCase("//,\n1,2", 3)]
        [TestCase("//;\n3;6", 9)]
        [TestCase("//*\n5*10", 15)]
        [TestCase("//+\n5+10", 15)]
        public void ReturnSum_WhenAdding_GivenManyNumbersAndNewLineWithSlashes(string manyNumbers, int expectedSum)
        {
            var sum = StringCalculator.Add(manyNumbers);
            sum.Should().Be(expectedSum);
        }

        [TestCase("1,-1", "negatives not allowed")]
        public void ReturnException_WhenAdding_GivenANegativeNumber(string manyNumbers, string expectedErrorMessage)
        {
            Action act = () => StringCalculator.Add(manyNumbers);

            act.ShouldThrow<InvalidOperationException>().WithMessage(expectedErrorMessage);
        }
    }
}