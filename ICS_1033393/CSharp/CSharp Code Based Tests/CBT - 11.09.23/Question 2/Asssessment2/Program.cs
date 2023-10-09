using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asssessment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter position: ");
            int position = Convert.ToInt32(Console.ReadLine());
            int len = word.Length;
            word = word.Remove(position, 1);
            Console.WriteLine(word);
            Console.Read();
        }
    }
}
