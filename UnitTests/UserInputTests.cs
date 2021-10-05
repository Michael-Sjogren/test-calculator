using System;
using Xunit;
using TestCalculator;
namespace UnitTests
{
    public class UserInputTests
    {
        private UserInput _input;

        [Theory]
        [InlineData("",new double[]{})]
        [InlineData("12   , , 23, 45,ad",new double[]{12,23,45})]
        [InlineData("12.3,23.45,|ad",new double[]{12.3,23.45})]
        [InlineData("12\n",new double[]{12})]
        public void DelimitedStringToNumbers(string input , double[] expected)
        {
            _input = new UserInput();
            var delimiter = ',';
            var result = _input.GetNumbersFromString(input , delimiter);
            Assert.Equal(expected,result);
        }

    }
}
