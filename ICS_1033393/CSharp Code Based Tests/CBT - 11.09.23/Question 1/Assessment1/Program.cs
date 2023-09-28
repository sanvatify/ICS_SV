using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i<=10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
            Console.ReadLine();
        }
    }
}
