using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class ShapeFactory
    {
        public static IShape GetShape(string shapeType)
        {
            IShape Icc = null;
            if (shapeType == "Rectangle")
            {
                Console.Write("Enter Length: ");
                int len = int.Parse(Console.ReadLine());
                Console.Write("Enter Breadth: ");
                int brd = int.Parse(Console.ReadLine());
                Icc = new Rectangle();
                Icc.GetArea(len, brd);
            }
            else if (shapeType == "Circle")
            {
                Console.Write("Enter Radius: ");
                int radius = int.Parse(Console.ReadLine());
                Icc = new Circle();
                Icc.GetArea(radius);
            }
            else if (shapeType == "Square")
            {
                Console.Write("Enter Length Of A Side: ");
                int side = int.Parse(Console.ReadLine());
                int sameSide = side;
                Icc = new Square();
                Icc.GetArea(side, sameSide);
            }
            return Icc;
        }
    }
}
