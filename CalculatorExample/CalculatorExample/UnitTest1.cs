using System;
using Xunit;
using System.Collections.Generic;

namespace CalculatorExample
{
    public class UnitTest1
    {
        private readonly Calculator _sut;

        public UnitTest1()
        {
            _sut = new Calculator();
        }

        [Fact]
        public void AddTwoNumbersShouldEqual()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }

        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(4, -7, 11)]
        public void AddTwoNumbersShouldEqualTheory(decimal expected, decimal in1, decimal in2)
        {
            _sut.Add(in1);
            _sut.Add(in2);
            Assert.Equal(expected, _sut.Value);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void AddTwoNumbersShouldEqualMember(decimal expected, params decimal[] valuesToAdd)
        {
            foreach(var value in valuesToAdd)
            {
                _sut.Add(value);
            }
            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] { 5, 10 } };
            yield return new object[] { 12, new decimal[] { 7, -4, 9 } };
        } 
    }
}
