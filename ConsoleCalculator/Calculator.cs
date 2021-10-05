using System;
using System.Linq;
namespace TestCalculator
{
    public class Calculator : ICalculatorOperations
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Add(double [] numbers)
        {
            if(numbers.Length == 0)
            {
                return 0;
            }
            return numbers.Aggregate( (x , y) => Add(x,y));
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Subtract(double [] numbers)
        {
            if(numbers.Length == 0)
            {
                return 0;
            }
            return numbers.Aggregate((x,y) => Subtract(x,y) );
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return x / y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double PowerOf(double x, double y)
        {
            return Math.Pow(x,y);
        }
    }
}