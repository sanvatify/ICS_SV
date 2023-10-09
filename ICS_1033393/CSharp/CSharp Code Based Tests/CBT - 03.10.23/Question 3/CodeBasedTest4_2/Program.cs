using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBasedTest4_2
{
    class Employee
    {
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateOfJoining { get; set; }
        public string city { get; set; }
    }
    class Program
    {
        static List<Employee> empList = new List<Employee>
            {
                new Employee
                {
                    employeeID = 1001,
                    firstName = "Malcom",
                    lastName = "Daruwalla",
                    title = "Manager",
                    dateOfBirth = new DateTime(1984,11,16),
                    dateOfJoining = new DateTime(2011,6,8),
                    city = "Mumbai"
                },
                new Employee
                {
                    employeeID = 1002,
                    firstName = "Asdin",
                    lastName = "Dhalla",
                    title = "AsstManager",
                    dateOfBirth = new DateTime(1984,8,20),
                    dateOfJoining = new DateTime(2012,7,7),
                    city = "Mumbai"
                },
                new Employee
                {
                    employeeID = 1003,
                    firstName = "Madhavi",
                    lastName = "Oza",
                    title = "Consultant",
                    dateOfBirth = new DateTime(1987,11,14),
                    dateOfJoining = new DateTime(2015,4,12),
                    city = "Pune"
                },
                new Employee
                {
                    employeeID = 1004,
                    firstName = "Saba",
                    lastName = "Shaikh",
                    title = "SE",
                    dateOfBirth = new DateTime(1990,6,3),
                    dateOfJoining = new DateTime(2016,2,2),
                    city = "Pune"
                },
                new Employee
                {
                    employeeID = 1005,
                    firstName = "Nazia",
                    lastName = "Shaikh",
                    title = "SE",
                    dateOfBirth = new DateTime(1991,03,08),
                    dateOfJoining = new DateTime(2016,02,02),
                    city = "Mumbai"
                },

                new Employee
                {
                    employeeID = 1006,
                    firstName = "Amit",
                    lastName = "Pathak",
                    title = "Consultant",
                    dateOfBirth = new DateTime(1989,11,07),
                    dateOfJoining = new DateTime(2014,08,08),
                    city = "Chennai"
                },
                new Employee
                {
                    employeeID = 1007,
                    firstName = "Vijay",
                    lastName = "Natrajan",
                    title = "Consultant",
                    dateOfBirth = new DateTime(1989,12,02),
                    dateOfJoining = new DateTime(2015,06,01),
                    city = "Mumbai"
                },
                new Employee
                {
                    employeeID = 1008,
                    firstName = "Rahuk",
                    lastName = "Dubey",
                    title = "Associate",
                    dateOfBirth = new DateTime(1993,11,11),
                    dateOfJoining = new DateTime(2016,11,06),
                    city = "Chennai"
                },
                new Employee
                {
                    employeeID = 1009,
                    firstName = "Suresh",
                    lastName = "Mistry",
                    title = "Associate",
                    dateOfBirth = new DateTime(1992,08,12),
                    dateOfJoining = new DateTime(2014,12,03),
                    city = "Chennai"
                },
                new Employee
                {
                    employeeID = 1010,
                    firstName = "Sumit",
                    lastName = "Shah",
                    title = "SE",
                    dateOfBirth = new DateTime(1991,04,12),
                    dateOfJoining = new DateTime(2016,01,02),
                    city = "Pune"
                },
            };
        static void Main()
        {
            Options();
            Console.Read();
        }
        public static void AllEmployees(List<Employee> employees)
        {
            foreach(var emp in employees)
            {
                Console.WriteLine($"{emp.employeeID}, {emp.firstName}, {emp.lastName}, {emp.title}, {emp.dateOfBirth}, {emp.dateOfJoining}, {emp.city}");
            }
            Options();
            
        }
        public static void LocationNotMumbai(List<Employee> employees)
        {
            foreach(var emp in employees)
            {
                if (emp.city != "Mumbai")
                {
                    Console.WriteLine($"{emp.employeeID}, {emp.firstName}, {emp.lastName}, {emp.title}, {emp.dateOfBirth}, {emp.dateOfJoining}, {emp.city}");
                }
            }
            Options();
        }
        public static void AsstManager(List<Employee> employees)
        {
            foreach(var emp in employees)
            {
                if(emp.title == "AsstManager")
                {
                    Console.WriteLine($"{emp.employeeID}, {emp.firstName}, {emp.lastName}, {emp.title}, {emp.dateOfBirth}, {emp.dateOfJoining}, {emp.city}");
                }
            }
            Options();
        }
        public static void StartsWithS(List<Employee> employees)
        {
            foreach(var emp in employees)
            {
                if (emp.lastName.StartsWith("S"))
                {
                    Console.WriteLine($"{emp.employeeID}, {emp.firstName}, {emp.lastName}, {emp.title}, {emp.dateOfBirth}, {emp.dateOfJoining}, {emp.city}");
                }
            }
            Options();
        }
        public static void Options()
        {
            Console.WriteLine("1. Display Details Of All Employees \n2. Display Details Of All The Employees Whose Location Is Not Mumbai \n" +
                "3. Display Details Of All Employees Whose Title Is AsstManager \n4. Display Details OF All The Employees Whose Name Starts With S \n" +
                "5. Exit");
            byte choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: AllEmployees(empList); break;
                case 2: LocationNotMumbai(empList); break;
                case 3: AsstManager(empList); break;
                case 4: StartsWithS(empList); break;
                case 5: Environment.Exit(0); break;
                default: Console.WriteLine("Invalid Choice"); Program.Main(); break;
            }
        }
    }
}
