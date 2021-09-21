namespace calculator_dotnet
{
    public interface ICalculatorOperations
    {
        public double Add(double x, double y);
        public double Subtract(double x, double y);
        public double Divide(double x, double y);
        public double Multiply(double x, double y);
        public double PowerOf(double x, double y);
    }
}