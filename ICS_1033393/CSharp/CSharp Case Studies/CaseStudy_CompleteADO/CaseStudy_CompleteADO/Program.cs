using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace CaseStudy_CompleteADO
{
    public class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"ID: {student.StudentID}, Name: {student.StudentName}, Date Of Birth: {student.StudentDateOfBirth}");
        }
        public void DisplayCourse(Course course)
        {
            Console.WriteLine($"Course ID: {course.CourseID}, Name: {course.CourseName}, Date Of Creation: {course.CourseDateOfCreation}");
        }
    }
    public class App
    {
        static void Main()
        {
            AppEngine appEngine = new AppEngine();
            Info info = new Info();
            UserInterface userInterface = new ConsoleUserInterface(appEngine, info);
            userInterface.showFirstScreen();
            Console.Read();
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public int EnrolledCourseID { get; set; }
        public Course EnrolledCourses { get; set; }
    }
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseDateOfCreation { get; set; }
        public ICollection<Student> Students { get; set; }
    }
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ICS-LT-C0MV6D3; Database=assignmentDB; Integrated Security=True");
        }
    }
    public class AppEngine
    {
        private SchoolDbContext dbContext;
        public AppEngine()
        {
            dbContext = new SchoolDbContext();
            dbContext.Database.Migrate();
        }
        public void RegisterStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }
        public Student[] GetStudents()
        {
            return dbContext.Students.ToArray();
        }
        public Course[] GetCourses()
        {
            return dbContext.Courses.ToArray();
        }
        public void CreateCourse(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
        }
        public void EnrollStudent(Student student, Course course, DateTime enrollmentDate)
        {
            if(student != null && course != null)
            {
                student.EnrolledCourseID = course.CourseID;
                student.EnrolledCourses = course;
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student Or Course Not Found");
            }
        }
        public void RemoveStudent(int studentID)
        {
            var student = dbContext.Students.FirstOrDefault(s => s.StudentID == studentID);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }
        public void UpdateStudent(int studentID, string newStudentName)
        {
            var student = dbContext.Students.FirstOrDefault(s => s.StudentID == studentID);
            if (student != null)
            {
                student.StudentName = newStudentName;
                dbContext.SaveChanges();
                Console.WriteLine("Student Updated Successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }
        public void RemoveCourse(string courseName)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.CourseName == courseName);
            if (course != null)
            {
                dbContext.Courses.Remove(course);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Course Not Found");
            }
        }
        public void UpdateCourse(string courseName, string newCourseName)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.CourseName == courseName);
            if (course != null)
            {
                course.CourseName = newCourseName;
                dbContext.SaveChanges();
                Console.WriteLine("Course Updated Successfully");
            }
            else
            {
                Console.WriteLine("Course Not Found");
            }
        }
    }
    interface UserInterface
    {
        void showFirstScreen();
        void showStudentScreen();
        void showAdminScreen();
        void showAllStudentsFromDatabase();
        void showStudentRegistrationScreen();
        void introduceNewCourseScreen();
        void showAllCoursesScreen();
    }
    public class ConsoleUserInterface : UserInterface
    {
        private AppEngine appEngine;
        private Info info;
        public ConsoleUserInterface(AppEngine engine, Info info)
        {
            appEngine = engine;
            this.info = info;
        }
        public void showAllCoursesScreen()
        {
            Console.WriteLine("List Of Courses: ");
            Course[] courses = appEngine.GetCourses();
            foreach (Course c in courses)
            {
                info.DisplayCourse(c);
            }
        }
        public void showFirstScreen()
        {
            Console.WriteLine("WELCOME TO SMS (STUDENT MANAGEMENT SYSTEM) v1.0");
            Console.WriteLine("1. Student \n2. Admin");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1: showStudentScreen(); break;
                case 2: showAdminScreen(); break;
                default: Console.WriteLine("Invalid Choice, Please Try Again"); showFirstScreen(); break;
            }
        }
        public void showStudentScreen()
        {
            Console.WriteLine("You Are Now In STUDENT MENU \n1. Enroll In A Course \n2. Deregister From A Course \n" +
                "3. Exit Student Menu");
            byte choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: showAllCoursesScreen();
                    Console.Write("Enter The Name Of The Course You Want To Enroll In: ");
                    string courseName = Console.ReadLine();
                    var courseToEnroll = appEngine.GetCourses().FirstOrDefault(c => c.CourseName == courseName);
                    if (courseToEnroll != null)
                    {
                        appEngine.EnrollStudent(appEngine.GetStudents()[0], courseToEnroll, DateTime.Now);
                        Console.WriteLine("Enrolled Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Course Not Found");
                    }
                    break;
                case 2: showAllCoursesScreen();
                    Console.Write("Enter The Name Of The Course You Want To Deregister From: ");
                    string courseToDeregister = Console.ReadLine();
                    var courseToDeregisterFrom = appEngine.GetCourses().FirstOrDefault(c => c.CourseName == courseToDeregister);
                    if(courseToDeregisterFrom != null)
                    {
                        var student = appEngine.GetStudents()[0];
                        if(student.EnrolledCourseID == courseToDeregisterFrom.CourseID)
                        {
                            student.EnrolledCourseID = -1;
                            student.EnrolledCourses = null;
                            appEngine.UpdateStudent(student.StudentID, student.StudentName);
                            Console.WriteLine("Deregistered Successfully");
                        }
                        else
                        {
                            Console.WriteLine("You Are Not Enrolled In The Selected Course");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Course Not Found");
                    }
                    break;
                case 3: break;
                default: Console.WriteLine("Invalid Choice"); 
                    break;
            }
        }
        public void showAdminScreen()
        {
            Console.WriteLine("Admin Login");
            Console.Write("Enter Admin ID: ");
            string adminID = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string adminPassword = Console.ReadLine();
            if (adminID == "sanidhyav" && adminPassword == "admin1234")
            {
                while (true)
                {
                    Console.WriteLine("Admin Menu: ");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Course");
                    Console.WriteLine("3. Remove Student");
                    Console.WriteLine("4. Remove Course");
                    Console.WriteLine("5. Update Student");
                    Console.WriteLine("6. Update Course");
                    Console.WriteLine("7. Show All Students");
                    Console.WriteLine("8. Show All Courses");
                    Console.WriteLine("9. Exit Admin Menu");
                    byte choice = byte.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: showStudentRegistrationScreen();
                            break;
                        case 2: introduceNewCourseScreen(); 
                            break;
                        case 3: Console.WriteLine("Enter The ID Of The Student To Remove: ");
                            int studentID = int.Parse(Console.ReadLine());
                            appEngine.RemoveStudent(studentID); break;
                        case 4: Console.Write("Enter The Name Of The Course To Remove: ");
                            string courseName = Console.ReadLine();
                            appEngine.RemoveCourse(courseName);
                            break;
                        case 5: Console.Write("Enter The ID Of The Student To Update: ");
                            int studentIDToUpdate = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter The New Name For The Student: ");
                            string newStudentName = Console.ReadLine();
                            appEngine.UpdateStudent(studentIDToUpdate, newStudentName);
                            break;
                        case 6: Console.Write("Enter The Name Of The Course To Update: ");
                            string courseNameToUpdate = Console.ReadLine();
                            Console.Write("Enter The New Name For The Course: ");
                            string newCourseName = Console.ReadLine();
                            appEngine.UpdateCourse(courseNameToUpdate, newCourseName);
                            break;
                        case 7: showAllStudentsFromDatabase();
                            break;
                        case 8: showAllCoursesScreen();
                            break;
                        case 9: return;
                        default: Console.WriteLine("Invalid Choice"); 
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Admin ID Or Password");
                showFirstScreen();
            }
        }
        public void showStudentRegistrationScreen()
        {
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter Student's Date Of Birth (yyyy-mm-dd): ");
            DateTime studentDateOfBirth = DateTime.Parse(Console.ReadLine());
            Student newStudent = new Student
            {
                StudentName = studentName,
                StudentDateOfBirth = studentDateOfBirth,
            };
            appEngine.RegisterStudent(newStudent);
            Console.WriteLine("Student Registered Successfully");
        }
        public void introduceNewCourseScreen()
        {
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();
            Course newCourse = new Course
            {
                CourseName = courseName,
            };
            appEngine.CreateCourse(newCourse);
            Console.WriteLine("Course Introduced Successfully");
        }
        public void showAllStudentsFromDatabase()
        {
            Console.WriteLine("List Of Students In The Database: ");
            Student[] students = appEngine.GetStudents();
            foreach(Student student in students)
            {
                info.Display(student);
            }
        }
    }
   
}