using System;
using System.IO;


namespace CodeBasedTestFour
{
    class Program
    {
        static void Main()
        {
            string filePath = "1033393.txt"; 
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                Console.WriteLine("Enter text to append to the file (Ctrl+Z to finish):");
                while (true)
                {
                    string toAppend = Console.ReadLine();
                    if (toAppend == null)
                        break;
                    streamWriter.WriteLine(toAppend);
                }
                Console.WriteLine("Text appended successfully.");
                Console.Read();
            }
        }
    }
}