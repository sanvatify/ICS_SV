using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Square : IShape
    {
        public void GetArea(int radius)
        {
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"Area: {area}");
            Console.Write("Display Perimeter? (y/n): ");
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case 'y': GetPerimeter(radius); break;
                case 'n': Program.mainMenu(); ; break;
            }
        }

        public void GetPerimeter(int radius)
        {
            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"Perimeter: {perimeter}");
            Program.mainMenu();
        }

        public string GetShapeType()
        {
            return "Square";
        }
        public void GetArea(int len, int brd)
        {
            double Area = len * brd;
            Console.WriteLine($"Area: {Area}");
            Program.mainMenu();
        }
    }
}
