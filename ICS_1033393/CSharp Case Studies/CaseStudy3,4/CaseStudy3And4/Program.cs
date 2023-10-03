using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy3And4
{
   public class Enroll
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public Student(string name)
        {
            Name = name;
        }
    }
    public class Course
    {
        public string Name { get; set; }
        public Course(string name)
        {
            Name = name;
        }
    }
    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();
        public void Introduce(Course course)
        {
            courses.Add(course);
        }
        public void Register(Student student)
        {
            students.Add(student);
        }
        public List<Student> ListOfStudents()
        {
            return students;
        }
        public List<Course> ListOfCourses()
        {
            return courses;
        }
        public void Enroll(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now;
            Enroll enrollment = new Enroll(student, course, enrollmentDate);
            enrollments.Add(enrollment);
        }
        public List<Enroll> ListOfEnrollements()
        {
            return enrollments;
        }
    }

    public interface UserInterface
    {
        void ShowFirstScreen();
        void ShowStudentScreen();
        void ShowAdminScreen();
        void ShowAllStudentScreen();
        void ShowStudentRegistrationScreen();
        void IntroduceNewCourseScreen();
        void ShowAllCoursesScreen();
    }
    public class ConsoleUserInterface : UserInterface
    {
        private AppEngine ae;
        public ConsoleUserInterface(AppEngine ae)
        {
            this.ae = ae;
        }
        public void ShowFirstScreen()
        {
            Console.WriteLine("WELCOME TO SMS - STUDENT MANAGEMENT SYSTEM v1.0");
            Console.WriteLine("Tell Us Who You Are:\n1. Student\n2. Admin");
            Console.WriteLine("Enter Your Choice (1 or 2): ");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: ShowStudentScreen(); break;
                case 2: ShowAdminScreen(); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }
        public void ShowStudentScreen()
        {
            Console.WriteLine("WELCOME TO STUDENT MENU");
            Console.WriteLine("1. View All Courses \n2. Enroll In A Course \n3. Exit \nPlease Enter Your Choice");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: ShowAllCoursesScreen(); break;
                case 2: ShowStudentRegistrationScreen(); break;
                case 3: Environment.Exit(0); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
            Options();
        }
        public void ShowAdminScreen()
        {
            Console.WriteLine("WELCOME TO ADMIN MENU");
            Console.WriteLine("1. Introduce New Course \n2. View All Students \n3. View All Courses \n" +
                "4. Exit \nPlease Enter Your Choice");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: IntroduceNewCourseScreen(); break;
                case 2: ShowAllStudentScreen(); break;
                case 3: ShowAllCoursesScreen(); break;
                case 4: Environment.Exit(0); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
            Options();
        }
        public void ShowAllStudentScreen()
        {
            Console.WriteLine("List Of Students: ");
            foreach(var student in ae.ListOfStudents())
            {
                Console.WriteLine(student.Name);
            }
            Options();
        }
        public void ShowStudentRegistrationScreen()
        {
            Console.WriteLine("Enter Student Name: ");
            string sname = Console.ReadLine();
            Student newStudent = new Student(sname);
            ae.Register(newStudent);
            Console.WriteLine($"{sname} Has Been Registered");
            Options();
        }
        public void IntroduceNewCourseScreen()
        {
            Console.WriteLine("Enter Course Name");
            string cname = Console.ReadLine();
            Course newCourse = new Course(cname);
            ae.Introduce(newCourse);
            Console.WriteLine($"{cname} Has Been Introduced");
            Options();
        }
        public void ShowAllCoursesScreen()
        {
            Console.WriteLine("List Of Courses: ");
            foreach(var course in ae.ListOfCourses())
            {
                Console.WriteLine(course.Name);
            }
        }
        public void Options()
        {
            Console.WriteLine("1. Switch To Admin \n2. Switch To Student");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: ShowAdminScreen(); break;
                case 2: ShowAllStudentScreen(); break;
                default: Console.WriteLine("Invalid Choice"); Options(); break;
            }
        }
    }
    public class App
    {
        public static void Main(string[] args)
        {
            AppEngine ae = new AppEngine();
            UserInterface ui = new ConsoleUserInterface(ae);
            ui.ShowFirstScreen();
            Console.Read();
        }
    }
}
