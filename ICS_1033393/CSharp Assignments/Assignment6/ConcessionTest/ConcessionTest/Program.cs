using System;
using System.Collections.Generic
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concession;
using System.Windows.Forms;

namespace ConcessionTest
{
    public class Program
    {
        static double tickietFare = 2500;
        static string userName;
        static int age;
        static void Main(string[] args)
        {
            Console.WriteLine("*** WELCOME ***");
            Console.Write,Line("1. Book Ticket    2. Exit")
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: mainMenu(); break;
                case 2: Environment.Exit(0); break;
            }
            Console.Read()
        }
        public static void mainMenu()
        {
            Console.Write("Enter Name: ");
            userName = Console.ReadLine();
            Console.Write("Enter Age: ");
            age = int.Parse(Console.ReadLine());
            ConcessionCalculator cc = new ConcessionCalculator();
            cc.concessionAmount(age);
            cc.showUserDetails(userName, age);
            cc.showOfThanks();
        }
    }
}
