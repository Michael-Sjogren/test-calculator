using System;
using System.Collections.Generic;
using System.IO;

namespace TestCalculator
{
    public class UserInput 
    {
        public String GetUserInput()
        {
            try
            {
                var s = Console.ReadLine();
                if(s != null)
                {
                    return s.Trim();
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(OutOfMemoryException)
            {
                Console.WriteLine("String is too large");
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return "";
        }

        public double[] GetNumbersFromString(String input , char delimiter)
        {
            var options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            var entries = input.Split(delimiter , options);
            
            if(entries.Length == 0)
            {
                return new double[]{};
            }

            var numbers = new List<double>(entries.Length);
            foreach(var entry in entries)
            {
                double num;
                if(double.TryParse(entry , out num))
                {
                    numbers.Add(num);
                }
            }
            return numbers.ToArray();
        }

        public double GetNumberFromString(String input)
        {
            double num;
            if (!double.TryParse(input, out num))
            {
                num = double.NaN;
            }
            return num;
        }
    }
}