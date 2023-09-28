using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program //Firstname and Secondname program, it also includes the second program of counting occurences
    {
        static string firstName; static string secondName; static string inputString;
        static void Main(string[] args)
        {
            option();
            Console.Read();
        }
        public static void option()
        {
            Console.WriteLine("1. Program 1    2. Program 2    3. Program 3    4. Program 4    5. Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: p1(); break;
                case 2: p2(); break;
                case 3: SaleDetails.Mmain(); break;
                case 4: Customer.Mmain(); break;
                case 5: Environment.Exit(0); break;
            }
        }
        public static void p1()
        {
            Console.Write("Enter First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter Second Name: ");
            secondName = Console.ReadLine();
            display(firstName, secondName);
            option();
        }
        static void display(string fname, string sname)
        {
            Console.WriteLine(fname.ToUpper());
            Console.WriteLine(sname.ToUpper());
        }
        public static void p2() //2nd program of counting occurences
        {
            int count = 0;
            Console.Write("Enter A String: ");
            inputString = Console.ReadLine();
            Console.Write("Enter Target: ");
            char target = Console.ReadLine().FirstOrDefault();
            foreach (char c in inputString)
            {
                if (c == target)
                {
                    count++;
                }
            }
            Console.Write($"In The Given String '{inputString}', the letter '{target}' occurs {count} times \n");
            Console.Write($"The Total Number Of Characters Are {inputString.Count()}\n");
            option();
        }
    }
    public class SaleDetails //3rd program of saledetails
    {
        static int salesNumber; static int productNumber; static int Price; static DateTime currentDateTime = DateTime.Now;
        static int Quantity; static int totalAmount;

        public static void Mmain()
        {
            Console.Write("Enter Sale Number: ");
            salesNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Number: ");
            productNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price of Product: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());
            SaleDetails sd = new SaleDetails(salesNumber, productNumber, Price, currentDateTime, Quantity);
        }
        public SaleDetails(int salesnumber, int productnumber, int price, DateTime dateofsale, int quantity)
        {
            salesNumber = salesnumber;
            productNumber = productnumber;
            Price = price;
            Quantity = quantity;
            sales(quantity, price);
            showData(salesnumber, productnumber, price, dateofsale, quantity, totalAmount);
            options();
        }
        static int sales(int qty, int price)
        {
            totalAmount = price * qty;
            return totalAmount;
        }
        static void showData(int salesnumber, int productnumber, int price, DateTime dateofsale, int quantity, int totalamount)
        {
            Console.WriteLine($"Sale Number: {salesnumber}    Product Number: {productNumber} \n" +
                $"Price: {price}    Quantity: {quantity} \n" +
                $"Date Of Sale: {dateofsale} \n" +
                $"TOTAL: {totalamount} ");
        }
        static void options()
        {
            Console.WriteLine("1. Add Another Sale    2. Program 1    3.    Program 2    4. Program 3    5. Program 4    5. Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: Mmain(); break;
                case 2: Program.p1(); break;
                case 3: Program.p2(); break;
                case 4: Mmain(); break;
                case 5: Customer.Mmain(); break;
            }
        }
    }

    public class Customer //4th program of customer and a destructor has been added in the end
    {
        static double customerID; static int customerAge; static string customerName; static double customerPhoneNumber;
        static string customerCity;

        public static void Mmain()
        {
            Console.Write("Enter Customer ID: ");
            customerID = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            customerName = Console.ReadLine();
            Console.Write("Enter Customer Age: ");
            customerAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Phone Number: ");
            customerPhoneNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Customer City: ");
            customerCity = Console.ReadLine();
            Customer transfer = new Customer(customerID, customerName, customerAge, customerPhoneNumber, customerCity);
        }
        public Customer()
        {
            //Empty Constructor
        }
        public Customer(double cID, string cName, int cAge, double cPhoneNumber, string cCity)
        {
            customerID = cID;
            customerName = cName;
            customerAge = cAge;
            customerPhoneNumber = cPhoneNumber;
            customerCity = cCity;
            displayCustomer();
        }
        static void displayCustomer()
        {
            Console.WriteLine($"Hello {customerName}, Your Customer ID Is {customerID} And Your Age Is {customerAge} \n" +
                $"Your Phone Number Is {customerPhoneNumber} And You Live In {customerCity}");
            Program.option();
        }
        ~Customer() //Destructor
        {
            Console.WriteLine("Destructor Is Activated");
        }
    }
}
