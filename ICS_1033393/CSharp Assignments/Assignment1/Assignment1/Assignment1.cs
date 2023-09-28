using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Assignment1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Check If Equal  2. Positive or Negative  3. Perform Calculations");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    chkeql();
                    break;
                case 2:
                    posneg();
                    break;
                case 3:
                    calc();
                    break;
            }
        }
        static void chkeql()
        {
            Console.WriteLine("Enter a number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }
            Console.WriteLine("1. Positive or negative 2. Calculations");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1:
                    posneg();
                    break;
                case 2:
                    calc();
                    break;
            }
        }
    


           
            static void posneg()
            {
                Console.WriteLine("Enter a number");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num > 0)
                {
                    Console.WriteLine("Positive");
                }
                else if (num < 0)
                {
                    Console.WriteLine("Negative");
                }
                else
                {
                    Console.WriteLine("Zero");
                }
                Console.WriteLine("1. Check if equal 2. Calculations");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        chkeql();
                        break;
                    case 2:
                        calc();
                        break;
                }
            }
            static void calc()
            {
                Console.WriteLine("Enter a number");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("num1 + num2 = " + (num1 + num2));
                Console.WriteLine("num1 - num2 = " + (num1 - num2));
                Console.WriteLine("num1 * num2 = " + (num1 * num2));
                Console.WriteLine("num1 / num2 = " + (num1 / num2));
                Console.WriteLine("1. Check if equal 2. positive or negative");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        chkeql();
                        break;
                    case 2:
                        posneg();
                        break;
                }
            }
        }
    }



                
             
      