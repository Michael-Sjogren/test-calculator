using System;

namespace calculator_dotnet
{
    public class ConsoleCalculator
    {
        private bool _isRunning = true;
        private Calculator _calculator;
        private enum CalcOperations
        {
            Quit = -1,
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4,
            POW = 5,
        }
        public void Quit()
        {
            _isRunning = false;
        }

        private void PrintTutorial()
        {
            Console.WriteLine("Enter a number listed below to use the calculators functions.");
            foreach(var value in Enum.GetValues<CalcOperations>())
            {
                var name = Enum.GetName<CalcOperations>(value);
                Console.WriteLine($"{name} {(int)value}");
            }
        }
        public void Run()
        {
            Console.WriteLine("Calculator");
            _calculator = new Calculator();
            
            while (_isRunning)
            {
                // parse fail error check
                Console.Clear();
                PrintTutorial();
                int operation;
                Console.Write("Select a number:");
                if (!int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                switch ((CalcOperations)operation)
                {
                    case CalcOperations.Quit:
                        Quit();
                        break;
                    case CalcOperations.Add:
                        Addition();
                        break;
                    case CalcOperations.Subtract:
                        Subtraction();
                        break;
                    case CalcOperations.Multiply:
                        Multiplication();
                        break;
                    case CalcOperations.Divide:
                        Division();
                        break;
                    case CalcOperations.POW:
                        PowerOf();
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
        
        public void Addition()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Addition");
            Console.WriteLine("Enter two numbers to add together.");
            x = GetNumberFromUser();
            y = GetNumberFromUser();
            result = _calculator.Add(x, y);
            Console.WriteLine($"{x} + {y} = {result}");
            Console.ReadKey();
            Console.Clear();
        }

        public void Subtraction()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Subtraction");
            Console.WriteLine("Enter two numbers to subtract.");
            x = GetNumberFromUser();
            y = GetNumberFromUser();
            result = _calculator.Subtract(x, y);
            Console.WriteLine($"{x} - {y} = {result}");
            Console.ReadKey();
            Console.Clear();
        }

        public void Multiplication()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Multiplication");
            Console.WriteLine("Enter two numbers to multiply together.");
            x = GetNumberFromUser();
            y = GetNumberFromUser();
            result = _calculator.Multiply(x, y);
            Console.WriteLine($"{x} * {y} = {result}");
            Console.ReadKey();
            Console.Clear();
        }

        public void Division()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Division");
            Console.WriteLine("Enter two numbers to divide.");
            x = GetNumberFromUser();
            y = GetNumberFromUser();
            try
            {
                result = _calculator.Divide(x, y);
                Console.WriteLine($"{x} / {y} = {result}");
            }
            catch (DivideByZeroException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            Console.ReadKey();
        }

        public void PowerOf()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Power of");
            Console.WriteLine("Enter two numbers the first number is the base and the second the exponent.");
            x = GetNumberFromUser();
            y = GetNumberFromUser();
            result = _calculator.PowerOf(x, y);
            Console.WriteLine($"{x}^{y} = {result}");
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}