using System;
using Xunit;
using TestCalculator;
namespace UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calc;


        [Fact]
        public void DivideByZero()
        {
            _calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => _calc.Divide(2 , 0) );
        }

        [Fact]
        public void Divide()
        {
            _calc = new Calculator();
            double result = _calc.Divide(10 , 5);
            Assert.Equal(2 , result , 4);
        }

        [Theory]
        [InlineData( new double[]{} , 0)]
        [InlineData( new double[]{10,2,3} , 5 )]
        [InlineData( new double[]{double.MaxValue,2,3} , double.MaxValue -6 )]
        [InlineData( new double[]{double.MinValue,2,3} , double.MinValue )]
        [InlineData( new double[]{double.NegativeInfinity,double.MaxValue,3} , double.NegativeInfinity )]
        public void SubtractNumbers(double[] numbers , double expected)
        {
            _calc = new Calculator();
            double result = _calc.Subtract(numbers);
            Assert.Equal(expected , result , 4);
        }

        [Fact]
        public void PowerOf()
        {
            _calc = new Calculator();
            double result = _calc.PowerOf(2,2);
            Assert.Equal(4 , result , 4);
        }

        [Fact]
        public void Multiply()
        {
            _calc = new Calculator();
            double result = _calc.Multiply(4,2);
            Assert.Equal(8 , result , 4);
        }

        [Fact]
        public void Addition()
        {
            _calc = new Calculator();
            double result = _calc.Add(2,2);
            Assert.Equal(4 , result , 4);
        }
        
        [Theory]
        [InlineData( new double[]{} , 0 )]
        [InlineData( new double[]{1,2,3} , 6 )]
        [InlineData( new double[]{double.NaN,2,3} , double.NaN )]
        public void AddNumbers(double[] numbers , double expected)
        {
            _calc = new Calculator();
            double result = _calc.Add(numbers);
            Assert.Equal(expected , result , 4);
        }
    }
}
