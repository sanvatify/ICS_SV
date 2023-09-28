using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy1
{
    public class Student
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public string studentDateOfBirth { get; set; }
        public Student(string studentname, int studentid, string studentdateofbirth)
        {
            studentID = studentid;
            studentName = studentname;
            studentDateOfBirth = studentdateofbirth;  
        }
    }
    public class Info
    {
        public void display(Student student)
        {

            Console.WriteLine($"Name: {student.studentName} \nID: {student.studentID} \nDate Of Birth: {student.studentDateOfBirth}");
            Console.WriteLine();

            App.options();
            
        }
    }
    public class App
    {
        public static int numberOfStudentObjects;
        static string nameStudent;
        static int IDstudent;
        static string nameStudentScenario2;
        static int IDstudentScenario2;
        
        static void Main(string[] args)
        {
            options();
            Console.Read();
        }
        public static void scenario1()
        {

            Console.WriteLine("Number Of Students: ");
            numberOfStudentObjects = Convert.ToInt32(Console.ReadLine());
            Student[] studentObjectCreator = new Student[numberOfStudentObjects];

            for (int i = 0; i<numberOfStudentObjects; i++)
            {
                Console.WriteLine($"*** Student {i + 1} ***");
                Console.Write("Name: ");
                nameStudent = Console.ReadLine();
                Console.Write("ID: ");
                IDstudent = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birth Date (yyyy/mm/dd): ");
                DateTime dateOfBirthStudent = DateTime.Parse(Console.ReadLine());
                string dateOfBirthStudentWithoutTime = string.Format("{0: dd/MM/yyyy}", dateOfBirthStudent);

                studentObjectCreator[i] = new Student(nameStudent, IDstudent, dateOfBirthStudentWithoutTime);
            }
            Console.WriteLine("Display Data (y/n)");
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case 'y': Info info = new Info();
                    for (int i = 0; i < numberOfStudentObjects; i++)
                    {
                        Console.WriteLine("Enter ID:");
                        int id = int.Parse(Console.ReadLine());
                        info.display(studentObjectCreator[id]);
                    }
                    break;
                case 'n': options(); 
                    break;
            }
        }
        public static void scenario2()
        {
            Console.Write("Number Of Students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            
            Student[] studentArray = new Student[numberOfStudents];

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"*** Student {i + 1} ***");
                Console.Write("Name: ");
                nameStudentScenario2 = Console.ReadLine(); 
                Console.Write("ID: ");
                IDstudentScenario2 = int.Parse(Console.ReadLine());
                Console.Write("Enter Birth Date (yyyy/mm/dd): ");
                DateTime dateOfBirthStudentScenario2 = DateTime.Parse(Console.ReadLine());
                string timeRemover = string.Format("{0: dd/MM/yyyy}", dateOfBirthStudentScenario2);

                studentArray[i] = new Student(nameStudentScenario2, IDstudentScenario2, timeRemover);
            }
            Console.WriteLine("Display Data (y/n)");
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case 'y':
                    foreach (Student student in studentArray)
                    {
                        Console.Write($"Student Name: {student.studentName} \n" +
                            $"Student ID: {student.studentID} \n" +
                            $"Date Of Birth: {student.studentDateOfBirth} \n");
                    }
                    break;
                case 'n':
                    options();
                    break;
            }
        }
        public static void options()
        {
            Console.WriteLine("1. Scenario 1    2. Scenario 2");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: scenario1(); break;
                case 2: scenario2(); break;
            }
        }
    }
}
