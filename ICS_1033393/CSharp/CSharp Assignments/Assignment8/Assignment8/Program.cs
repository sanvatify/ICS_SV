using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Program
    {
        public static int radius = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("*** WELCOME ***");
        }
        public static void mainMenu()
        {
            Console.Write("Enter Shape: ");
            string shapeType = Console.ReadLine();

            IShape cc = ShapeFactory.GetShape(shapeType);


            if (cc != null)
            {

            }
            else
            {
                Console.WriteLine("Invalid Shape.. please give correct type");
            }
            Console.Read();
        }
        public static void options()
        {
            Console.WriteLine("1. Main Menu    2. Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch(choice)
            {
                case 1: Program.mainMenu(); break;
                case 2: Environment.Exit(0); break;
            }
        }
    }

}
