using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBasedTest2
{
    public abstract class Student
    {
        static string studentName; public static double studentGrade; static int studentID;
        public Student(string studentname, double studentgrade, int studentid)
        {
            studentGrade = studentgrade;
            studentID = studentid;
            studentName = studentname;
        }
        public abstract bool isPassed(double studentgrade);
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string studentname, double studentgrade, int studentid) : base(studentname, studentgrade, studentid)
        {

        }
        public override bool isPassed(double studentgrade)
        {

            return studentgrade >= 70;
        }

    }
    public class Graduate : Student
    {
        public Graduate(string studentname, double studentgrade, int studentid) : base(studentname, studentgrade, studentid)
        {

        }
        public override bool isPassed(double studentgrade)
        {

            return studentgrade >= 80;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Student Name: ");
            string sname = Console.ReadLine();
            Console.Write("Enter Student Grade: ");
            double sgrade = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Student ID: ");
            int sID = Convert.ToInt32(Console.ReadLine());
            Student UG = new Undergraduate(sname, sgrade, sID);
            Console.WriteLine($"Student Name: {sname}, Student Grade: {sgrade}, Student ID: {sID}");
            Console.WriteLine($"Status: {UG.isPassed(Undergraduate.studentGrade)}");
            Console.Read();
        }
    }
}
