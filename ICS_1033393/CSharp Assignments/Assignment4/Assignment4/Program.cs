using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Student
    {
        static double studentrRollNumber;
        static string studentName;
        static string studentSection;
        static int studentSemester;
        static string studentBranch;
        static int[] studentMarks = new int[5];
        static double studentAverageMarks;
        static int studentTotal = 0;
        static string subjectGrade;
        static int studentMarksMax;
        static int studentMarksMin;
        static int failure; static string G;
        static string studentOverallGrade;
       
         public static void mainMenu()
        {
            Console.Write("Enter Your Name: ");
            studentName = Console.ReadLine();
            Console.Write("Enter Roll Number: ");
            studentrRollNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Your Section: ");
            studentSection = Console.ReadLine();
            Console.Write("Enter Semester: ");
            studentSemester = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Branch: ");
            studentBranch = Console.ReadLine();
            Console.WriteLine("1 - Enter Your Marks    2 - Display Result    3 - My Details    5 - Exit");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: getMarks(); break;
                case 2: displayResult(); break;
                case 3: displayData(); break;
                case 4: Environment.Exit(0); break;
            }

        }
        static void getGrade()
        {

            for (int i = 0; i < studentMarks.Length; i++)
            {
                if (studentMarks[i] < 35)
                {
                    Console.Write("F");
                    ++failure;
                }
                else if (studentMarks[i] > 35)
                {
                    Console.Write("P");
                }
            }
        }
        static void getMarks()
        {
            Console.WriteLine("Enter Marks");
            for(int i = 0; i<studentMarks.Length; i++)
            {
                Console.Write($"Enter Subject-{i+1} Marks: ");
                studentMarks[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("1 - Main Menu    2 - Enter Marks Again    3 - Display Result    4 - My Details    5 - Exit");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: mainMenu(); break;
                case 2: getMarks(); break;
                case 3: displayResult(); break;
                case 4: displayData(); break;
                case 5: Environment.Exit(0); break;
            }
        }
        static void displayResult()
        {
           
            Console.WriteLine("Your Marks are");
            for(int i =0; i<studentMarks.Length; i++)
            {
                
                if (studentMarks[i] > 35 && studentAverageMarks < 50)
                {
                    studentOverallGrade = "FAIL";
                }
                else if(studentMarks[i] < 35 && studentAverageMarks < 50)
                {
                    studentOverallGrade = "FAIL";
                }
                else if(studentMarks[i] > 35 && studentAverageMarks > 50)
                {
                    studentOverallGrade = "FAIL";
                }
                else if (studentMarks[i] > 35 && studentAverageMarks > 50)
                {
                    studentOverallGrade = "PASS";
                }
                Console.WriteLine($"Subject-{i+1} -> {studentMarks[i]}");
                
                
            }
            studentTotal = studentMarks.Sum();
            studentAverageMarks = studentMarks.Average();
            studentMarksMax = studentMarks.Max();
            studentMarksMin = studentMarks.Min();
            Console.WriteLine($"Total -> {studentTotal}/500    Average -> {studentAverageMarks}    Max/Min -> {studentMarksMax}/{studentMarksMin}");
            Console.WriteLine($"Overall Grade -> {studentOverallGrade}");
            Console.WriteLine("1 - Main Menu    2 - Enter Marks Again   3 - My Details    4 - Exit");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: mainMenu(); break;
                case 2: getMarks(); break;
                case 3: displayData(); break;
                case 4: Environment.Exit(0); break;
            }
        }

        static void displayData()
        {
            if (failure > 0)
            {
                G = "FAIL";
            }
            else
            {
                G = "PASS";
            }
            Console.WriteLine($"Name: {studentName}");
            Console.WriteLine($"Roll Number: {studentrRollNumber}");
            Console.WriteLine($"Branch and Section: {studentBranch} {studentSection}");
            Console.WriteLine($"Semester: {studentSemester}");
            Console.WriteLine($"Average: {studentAverageMarks}    Total: {studentTotal}");
            Console.WriteLine($"Grade: {G}");
            Console.WriteLine("1 - Main Menu    2 - Enter Marks Again    3 - Display Result");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: mainMenu(); break;
                case 2: getMarks(); break;
                case 3: displayResult(); break;
            }
        }

      
        
    }
    class Accounts
    {
        Student obj = new Student();
        static double accountNumber;
        static string customerName;
        static string accountType;
        static string transactionType;
        static double accountBalance;
        static int transactionNumber = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("***** W E L C O M E *****");
            mainMenu();
            Console.Read();
            Student.mainMenu();
        }
        static void mainMenu()
        {
            Console.WriteLine("1 - Program 1        2 - Program 2");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: program1(); break;
                case 2: Student.mainMenu(); break;
                
            }
        }
        static void program1()
        {
            Console.Write("Enter Your Name: ");
            customerName = Console.ReadLine();
            Console.Write("Enter Your Account Number: ");
            accountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Account Type -> 1. Savings  2. Current");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: accountType = "Savings"; break;
                case 2: accountType = "Current"; break;
            }
            Console.WriteLine("1 - Deposit    2 - Withdraw    3 - View Balance    4 - My Details");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1: Console.Write("Enter Deposit Amount: "); int depositAmount = Convert.ToInt32(Console.ReadLine()); deposit(depositAmount); options(); break;
                case 2: Console.Write("Enter Withdraw Amount: "); int withdrawAmount = Convert.ToInt32(Console.ReadLine()); withdraw(withdrawAmount); options(); break;
                case 3: Console.Write($"Your Balance is: {accountBalance}"); options(); break;
                case 4: myDetails(); options(); break;
            }
        }
        static void deposit(int depositAmount)
        {
            accountBalance = accountBalance + depositAmount;
            transactionNumber++;
            Console.WriteLine($"{depositAmount} Deposited");
        }
        static void withdraw(int withdrawAmount)
        {
            if (withdrawAmount > accountBalance)
            {
                Console.WriteLine("Insufficient Funds");
            }
            else
            {
                accountBalance = accountBalance - withdrawAmount;
                transactionNumber++;
                Console.WriteLine($"{withdrawAmount} Withdrawn");
            }
        }
        static void myDetails()
        {
            Console.Write($"Name: {customerName}    Account Number: {accountNumber}    Account Type: {accountType}    Available Balance: {accountBalance}    Number Of Transactions: {transactionNumber}");
            Console.WriteLine();
        }
        static void options()
        {
            Console.WriteLine("1 - Main Menu    2 - Deposit    3 - Withdraw    4 - View Balance    5 - My Details");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: mainMenu(); break;
                case 2: Console.Write("Enter Deposit Amount: "); int depositAmount = Convert.ToInt32(Console.ReadLine()); deposit(depositAmount); options(); break;
                case 3: Console.Write("Enter Withdraw Amount: "); int withdrawAmount = Convert.ToInt32(Console.ReadLine()); withdraw(withdrawAmount); options(); break;
                case 4: Console.Write($"Your Balance is: {accountBalance}"); options(); break;
                case 5: myDetails(); options(); break;
            }
        }
      
    }
   
}
