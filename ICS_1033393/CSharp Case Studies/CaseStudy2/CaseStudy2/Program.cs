using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy2
{
   public class Enroll
    {
        public Student student { get; set; }
        public Course course { get; set; }
        public DateTime enrollmentDate { get; set; }

        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
    }
    public class Student
    {
        public string name { get; set; }
        public Student(string name)
        {
            this.name = name;
        }
    }
    public class Course
    {
        public string name { get; set; }
        public Course(string name)
        {
            this.name = name;
        }
    }
    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();

        public void introduce(Course course)
        {
            courses.Add(course);
        }
        public void register(Student student)
        {
            students.Add(student);
        }
        public Student[] listOfStudents()
        {
            return students.ToArray();
        }
        public Course[] listOfCourses()
        {
            return courses.ToArray();
        }
        public void enroll(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now;
            Enroll enrollment = new Enroll(student, course, enrollmentDate);
            enrollments.Add(enrollment);
        }
        public Enroll[] listOfEnrollments()
        {
            return enrollments.ToArray();
        }
    }
    public class App
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Name: ");
            string sname = Console.ReadLine();
            Console.WriteLine("Enter Student-2 Name: ");
            string s1name = Console.ReadLine();
            AppEngine ae = new AppEngine();
            Student student1 = new Student(sname);
            Student student2 = new Student(s1name);
            Console.WriteLine("Enter Course Name: ");
            string cname = Console.ReadLine();
            Console.WriteLine("Enter Course-2 Name: ");
            string c1name = Console.ReadLine();
            Course course1 = new Course(cname);
            Course course2 = new Course(c1name);

            ae.register(student1); ae.register(student2);
            ae.introduce(course1); ae.introduce(course2);
            ae.enroll(student1, course1);
            ae.enroll(student2, course2);

            Console.WriteLine("List Of Students: ");
            foreach(Student student in ae.listOfStudents())
            {
                Console.WriteLine(student.name);
            }
            Console.WriteLine("List Of Courses: ");
            foreach(Course course in ae.listOfCourses())
            {
                Console.WriteLine(course.name);
            }
            foreach(Enroll enrollment in ae.listOfEnrollments())
            {
                Console.WriteLine("Student: " + enrollment.student.name);
                Console.WriteLine("Course: " + enrollment.course.name);
                Console.WriteLine("Enrollment Date: " + enrollment.enrollmentDate);
            }
            Console.Read();
        }
    }
}
