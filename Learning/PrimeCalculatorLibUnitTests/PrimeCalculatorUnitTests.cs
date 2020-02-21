using System;
using Xunit;
using PrimeCalculatorLib;

namespace PrimeCalculatorLibUnitTests
{
    public class PrimeCalculatorUnitTests
    {
        [Fact]
        public void TestFactoring7()
        {
            string outputString;
            var primeCalc = new PrimeCalculator();
            outputString = primeCalc.PrimeFactors(7);
            Assert.Equal("Prime factors of 7 are: 7", outputString);
        }

        [Fact]
        public void TestFactoring33()
        {
            string outputString;
            var primeCalc = new PrimeCalculator();
            outputString = primeCalc.PrimeFactors(33);
            Assert.Equal("Prime factors of 33 are: 3 x 11", outputString);
        }

        [Fact]
        public void TestFactoring113()
        {
            string outputString;
            var primeCalc = new PrimeCalculator();
            outputString = primeCalc.PrimeFactors(113);
            Assert.Equal("Prime factors of 113 are: 113", outputString);
        }

        [Fact]
        public void TestFactoring125()
        {
            string outputString;
            var primeCalc = new PrimeCalculator();
            outputString = primeCalc.PrimeFactors(125);
            Assert.Equal("Prime factors of 125 are: 5 x 5 x 5", outputString);
        }
    }
}
