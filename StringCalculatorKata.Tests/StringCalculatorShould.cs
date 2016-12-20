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
    }
}