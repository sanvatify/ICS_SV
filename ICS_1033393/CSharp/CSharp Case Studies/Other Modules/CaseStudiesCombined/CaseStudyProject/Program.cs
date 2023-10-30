using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyProject
{
    public class Student
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public string DateOfBirth { get; set; }
    }
    public class Course
    {
        public int courseID { get; set; }
        public string courseName { get; set; }
    }
    public class Enrollment
    {
        public Student student { get; set; }
        public Course course { get; set; }
        public DateTime enrollmentDate { get; set; }
    }
    public class Info
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enrollment> enrollments = new List<Enrollment>(); 

        public void Introduce(Course course)
        {
            Console.WriteLine("Course ID: " + course.courseID);
            Console.WriteLine("Course Name: " + course.courseName);
        }
        public void Register(Student student)
        {
            Console.WriteLine("Student ID: " + student.studentID);
            Console.WriteLine("Student Name: " + student.studentName);
            Console.WriteLine("Date Of Birth: " + student.DateOfBirth);
        }
        public void Enroll(Student student, Course course)
        {
            Enrollment enrollment = new Enrollment
            {
                student = student,
                course = course,
                enrollmentDate = DateTime.Now,
            };
            enrollments.Add(enrollment);
            Console.WriteLine("Enrollment Date: " + enrollment.enrollmentDate);
            Console.WriteLine();
        }
        public void DisplayEnrollments()
        {
            Console.WriteLine("List Of Enrollments: ");
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine("Student: " + enrollment.student.studentName);
                Console.WriteLine("Course: " + enrollment.course.courseName);
                Console.WriteLine("Enrollment Date: " + enrollment.enrollmentDate);
                Console.WriteLine();
            }
        }
        public void CreateStudent()
        {
            Console.WriteLine("Enter Student ID: ");
            int STUDENTID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name: ");
            string STUDENTName = Console.ReadLine();
            Console.WriteLine("Enter Date Of Birth (YYYY-MM-DD): ");
            string STUDENTDateOfBirth = Console.ReadLine();

            Student student = new Student
            {
                studentID = STUDENTID,
                studentName = STUDENTName,
                DateOfBirth = STUDENTDateOfBirth,
            };
            students.Add(student);
            Console.WriteLine("Student Creation Successfull!");
        }
        public void CreateCourse()
        {
            Console.WriteLine("Enter Course ID: ");
            int COURSEID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name: ");
            string COURSEName = Console.ReadLine();

            Course course = new Course
            {
                courseID = COURSEID,
                courseName = COURSEName,
            };
            courses.Add(course);
            Console.WriteLine("Course Creation Successfull!");
        }
        public void ShowAllStudents()
        {
            Console.WriteLine("List Of Students: ");
            foreach (Student student in students)
            {
                Console.WriteLine("Student ID: " + student.studentID);
                Console.WriteLine("Student Name: " + student.studentName);
                Console.WriteLine("Date Of Birth: " + student.DateOfBirth);
                Console.WriteLine();
            }
        }
        public void ShowAllCourse()
        {
            Console.WriteLine("List Of Courses: ");
            foreach(Course course in courses)
            {
                Console.WriteLine("Course ID: " + course.courseID);
                Console.WriteLine("Course Name: " + course.courseName);
                Console.WriteLine();
            }
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public List<Course> GetCourses()
        {
            return courses;
        }
    }
    public abstract class UserInterface
    {
        protected Info info = new Info();
        
        public void ShowFirstScreen()
        {
            Console.WriteLine("WELCOME TO SMS (STUDENT MANAGEMENT SYSTEM) v1.0");
            Console.WriteLine("Tell Us Who You Are: \n1. Student \n2. Admin");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: ShowStudentScreen(); break;
                case 2: ShowAdminScreen(); break;
                default: Console.WriteLine("Invalid Choice"); ShowFirstScreen(); break;
            }
        }
        public void ShowStudentScreen()
        {

            Console.WriteLine("Student Menu: n1\n1. Register Student \n2. Enroll In A Course \n3. Show All Students \n4. Show All Courses \n5. Back \n6. Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: info.CreateStudent(); 
                    ShowStudentScreen(); 
                    break;
                case 2: info.ShowAllStudents();
                    info.ShowAllCourse(); 
                    Console.WriteLine("Enter Student ID: "); 
                    int sID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Course ID: ");
                    int cID = Convert.ToInt32(Console.ReadLine());

                    List<Student> studentList = info.GetStudents();
                    Student student = studentList.Find(s => s.studentID == sID);
                    List<Course> courseList = info.GetCourses();
                    Course course = courseList.Find(c => c.courseID == cID);
                    if(student != null && course != null)
                    {
                        info.Enroll(student, course);
                    }
                    else
                    {
                        Console.WriteLine("Student/Course Not Found");
                    }
                    ShowStudentScreen();
                    break;
                case 3: info.ShowAllStudents();
                    ShowStudentScreen();
                    break;
                case 4: info.ShowAllCourse();
                    ShowStudentScreen();
                    break;
                case 5: ShowFirstScreen();
                    break;
                case 6: Environment.Exit(0);
                    break;
                default: Console.WriteLine("Invalid Choice"); 
                    ShowStudentScreen();
                    break;
            }
        }
        public void ShowAdminScreen()
        {
            Console.WriteLine("Admin Menu \n1. Create Student \n2. Create Course \n3. Show All Students \n4. Show All Courses \n5. Back \n6. Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1: info.CreateStudent();
                    ShowAdminScreen();
                    break;
                case 2: info.CreateCourse();
                    ShowAdminScreen();
                    break;
                case 3: info.ShowAllStudents();
                    ShowAdminScreen();
                    break;
                case 4: info.ShowAllCourse();
                    ShowAdminScreen();
                    break;
                case 5: ShowFirstScreen();
                    break;
                case 6: Environment.Exit(0);
                    break;
                default: Console.WriteLine("Invalid Choice"); 
                    ShowAdminScreen();
                    break;
            }
        }
        public void Run()
        {
            ShowFirstScreen();
        }
        public abstract void ShowAllStudentsScreen();
        public abstract void ShowStudentRegistrationScreen();
        public abstract void ShowAllCoursesScreen();
    }
    class AppEngine : UserInterface
    {
        public static void Main(string[] args)
        {
            new AppEngine().Run();
            Console.Read();
        }
        public override void ShowAllStudentsScreen()
        {
            info.ShowAllStudents();
            Console.WriteLine("1. Back");
            byte choice = Convert.ToByte(Console.ReadLine());
            if(choice == 1)
            {
                ShowAdminScreen();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                ShowAllStudentsScreen();
            }
        }
        public override void ShowStudentRegistrationScreen()
        {
            info.CreateStudent();
            Console.WriteLine("1. Back");
            byte choice = Convert.ToByte(Console.ReadLine());
            if (choice == 1)
            {
                ShowAdminScreen();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                ShowStudentRegistrationScreen();
            }
        }
        public override void ShowAllCoursesScreen()
        {
            info.ShowAllCourse();
            Console.WriteLine("1. Back");
            byte choice = Convert.ToByte(Console.ReadLine());
            if(choice == 1)
            {
                ShowAdminScreen();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                ShowAllCoursesScreen();
            }
        }
    }
}
