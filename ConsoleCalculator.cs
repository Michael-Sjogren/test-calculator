using System;

namespace calculator_dotnet
{
    public class ConsoleCalculator : ICalculatorOperations
    {
        private bool _isRunning = true;

        public void Quit()
        {
            _isRunning = false;
        }
        public void Run()
        {
            Console.WriteLine("Calculator");
            ConsoleCalculator calculator = new ConsoleCalculator();
            const string tutorial = "Addition, enter 1\n" +
                                    "Subtract, enter 2\n" +
                                    "Multiply, enter 3\n" +
                                    "Divide,enter 4\n"+
                                    "To quit the program, enter -1\n";
            while (_isRunning)
            {
                int operation;
                // parse fail error check
                Console.Clear();
                Console.WriteLine(tutorial);
                if (!int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                
                switch (operation)
                {
                    case -1:
                        Quit();
                        break;
                    case 1:
                        Console.WriteLine(calculator.Add(GetNumberFromUser() , GetNumberFromUser()));
                        break;
                    default:
                        Console.WriteLine("Unknown Operation");
                        break;
                }
            }
            Console.WriteLine("Shutting Down...");
        }

        private double GetNumberFromUser()
        {
            Console.Write("Input a number:");
            double num;
            if (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Not a number");
            }
            return num;
        }
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
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