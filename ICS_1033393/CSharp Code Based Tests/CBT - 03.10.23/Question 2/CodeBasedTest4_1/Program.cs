using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBasedTest4_1
{
    delegate int MathOperation(int a, int b);

    public class Calculator
    {
        public int add(int a, int b)
        {
            return a + b;
        }
        public int subtract(int a, int b)
        {
            return a - b;
        }
        public int multiply(int a, int b)
        {
            return a * b;
        }
        public int divide(int a, int b)
        {
            return a / b;
        }
        public int square(int a, int b)
        {
             return a ^ b;
        }
    }
    class Program
    {
        public static void Main()
        {
            int result = 0;
            Calculator calculator = new Calculator();
            MathOperation mathAdd = calculator.add;
            MathOperation mathSubtract = calculator.subtract;
            MathOperation mathMultiply = calculator.multiply;
            MathOperation mathDivide = calculator.divide;
            MathOperation mathSquare = calculator.square;

            Console.Write("Enter A Number: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Another Number: ");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Add\n2. Subtract\n3. Multiply\n4. Divide\n5. Square\n6. All\n7. Exit");
            byte choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: result = mathAdd(n1, n2); Console.WriteLine(result); options(); break;
                case 2: result = mathSubtract(n1, n2); Console.WriteLine(result); options(); break;
                case 3: result = mathMultiply(n1, n2); Console.WriteLine(result); options(); break;
                case 4: result = mathDivide(n1, n2); Console.WriteLine(result); options(); break;
                case 5: result = mathDivide(n1, n2); Console.WriteLine(result); options(); break;
                case 6:
                    Calculator calc = new Calculator(); Console.WriteLine($"Addition: {calc.add(n1, n2)} \n" +
                $"Subtraction: {calc.subtract(n1, n2)} \n" +
                $"Multiplication: {calc.multiply(n1, n2)} \n" +
                $"Division: {calc.divide(n1, n2)}\n" +
                $"Square: {calc.square(n1, n2)}"); options(); break;
                case 7: Environment.Exit(0); break;
                default: Console.WriteLine("Invalid Choice"); options(); break;
            }
            Console.Read();
        }
        public static void options()
        {
            Console.WriteLine("1. Again    2. Exit");
            byte choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: Main(); break;
                case 2: Environment.Exit(0); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }
    }
}

