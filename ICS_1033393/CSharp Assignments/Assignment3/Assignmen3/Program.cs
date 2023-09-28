using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmen3
{
    class Program
    {
        static void Main(string[] args)
        {
            mainMenu();
        }
        public static void mainMenu() { 
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            Console.WriteLine("1. Display length of your string");
            Console.WriteLine("2. Reverse your string");
            Console.WriteLine("3. Check if two strings are equal");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: int len = str.Length; Console.Write($"Length of your string is: {len}"); options(); break;
                case 2: string reversed = string.Empty; for(int i = str.Length-1; i>=0; i--)
                    {
                        reversed += str[i];
                    }
                    Console.WriteLine($"Reversed: {reversed}");
                    options();
                    break;
                case 3: Console.Write("Enter another string to be compared: "); string newstr = Console.ReadLine(); if (newstr.Equals(str))
                    {
                        Console.WriteLine("They are equal");
                    }
                    else
                    {
                        Console.Write("They are not equal");
                    }
                    options();
                    break;

            }
        }
        public static void options()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Mainmenu");
            Console.WriteLine("2 - Exit");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: mainMenu(); break;
                case 2: Environment.Exit(0); break;
            }
        }
    }
}
