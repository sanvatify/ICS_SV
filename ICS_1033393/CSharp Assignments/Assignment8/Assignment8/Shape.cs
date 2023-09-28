using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public interface IShape
    {
        string GetShapeType();
        void GetPerimeter(int radius);
        void GetArea(int radius);
        void GetArea(int length, int breadth);
    }
}
