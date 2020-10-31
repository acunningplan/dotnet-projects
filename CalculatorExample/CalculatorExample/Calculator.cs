using System;
namespace CalculatorExample
{
    public class Calculator
    {
        public decimal Value { get; set; } = 0;

        public Calculator()
        {
        }

        public decimal Add(decimal num1)
        {
            Value += num1;
            return Value;
        }

        public decimal Multiply(decimal num1)
        {
            Value *= num1;
            return Value;
        }
    }
}
