using System;

namespace TestCalculator
{
    public class ConsoleCalculator
    {
        private bool _isRunning = true;
        private Calculator _calculator;
        private UserInput _input;
        private enum CalcOperations
        {
            Quit = 6,
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4,
            POW = 5,
        }

        public ConsoleCalculator()
        {
            _calculator = new Calculator();
            _input = new UserInput();
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
                Console.WriteLine($"{(int)value}.\t{name}");
            }
        }
        public void Run()
        {
            Console.WriteLine("Calculator");
            
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
        
        public void Addition()
        {
            double result;
            Console.Clear();
            Console.WriteLine("Addition");
            Console.WriteLine("Enter two or more numbers to add. Example: '1,2,3,4'");
            var nums = GetNumbers();
            result = _calculator.Add(nums);
            Console.WriteLine($"{result}");
            Console.ReadKey();
            Console.Clear();
        }

        public void Subtraction()
        {
            double result;
            Console.Clear();
            Console.WriteLine("Subtraction");
            Console.WriteLine("Enter two or more numbers to subtract. Example: '1,2,3,4'");
            var nums = GetNumbers();
            
            result = _calculator.Subtract(nums);
            Console.WriteLine($"{result}");
            Console.ReadKey();
            Console.Clear();
        }

        private double[] GetNumbers()
        {
            return _input.GetNumbersFromString(_input.GetUserInput() , ',');
        }
        private double GetNumber()
        {
            Console.Write("Enter a number: ");
            return _input.GetNumberFromString(_input.GetUserInput());
        }
        public void Multiplication()
        {
            double x, y , result;
            Console.Clear();
            Console.WriteLine("Multiplication");
            Console.WriteLine("Enter two numbers with to multiply together.");
            x = GetNumber();
            y = GetNumber();
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
            x = GetNumber();
            y = GetNumber();
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
            x = GetNumber();
            y = GetNumber();
            result = _calculator.PowerOf(x, y);
            Console.WriteLine($"{x}^{y} = {result}");
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}