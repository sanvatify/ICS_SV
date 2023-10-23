using System;
using System.Data;
using System.Data.SqlClient;

class program
{
    static string connectionString = "Server=ICS-LT-C0MV6D3; Database=assignmentDB; Integrated Security=True";
    static void Main()
    {
        Console.WriteLine("1. Using Ado.net classes/methods, insert employee record in the table by invoking the procedure " +
            "\n2. Display all the records (including the newely added record) \n" +
            "3. Exit");
        byte choice = Convert.ToByte(Console.ReadLine());
        switch(choice)
        {
            case 1: InsertEmployeeRecords(); break;
            case 2: DisplayAllRecords(); break;
            case 3: Environment.Exit(0); break;
            default: Console.WriteLine("Invalid Choice"); Main(); break;
        }
    }
    static void InsertEmployeeRecords()
    {
        Console.Write("Enter EmpName: ");
        string empname = Console.ReadLine();
        Console.Write("Enter EmpSalary: ");
        int salary = int.Parse(Console.ReadLine());
        Console.Write("Enter EmpType: ");
        char empType = char.Parse(Console.ReadLine());
        Console.Write("Enter EmpStatus: ");
        string empStatus = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(SqlCommand cmd = new SqlCommand("addEmployee", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empname", empname));
                cmd.Parameters.Add(new SqlParameter("@empsal", salary));
                cmd.Parameters.Add(new SqlParameter("@emptype", empType));
                cmd.Parameters.Add(new SqlParameter("@empstatus", empStatus));
                var empNoParameter = new SqlParameter("@newEmpNo", SqlDbType.Int);
                empNoParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(empNoParameter);
                cmd.ExecuteNonQuery();
                int newEmpNo = (int)empNoParameter.Value;
                Console.WriteLine($"New Employee Number: {newEmpNo}");
            }
        }
        Console.WriteLine("1. Using Ado.net classes/methods, insert employee record in the table by invoking the procedure " +
            "\n2. Display all the records (including the newely added record) \n" +
            "3. Exit");
        byte choice = byte.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: InsertEmployeeRecords(); break;
            case 2: DisplayAllRecords(); break;
            case 3: Environment.Exit(0); break;
            default: Console.WriteLine("Invalid Choice"); InsertEmployeeRecords(); break;
        }
    }
    static void DisplayAllRecords()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"EmpNo: {reader["empno"]}," +
                        $"Name: {reader["empno"]}," +
                        $"Salary: {reader["empsal"]}," +
                        $"Type: {reader["emptype"]}," +
                        $"Status: {reader["empstatus"]}");
                }
            }
        }
        Console.WriteLine("1. Using Ado.net classes/methods, insert employee record in the table by invoking the procedure " +
            "\n2. Display all the records (including the newely added record) \n" +
            "3. Exit");
        byte choice = byte.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: InsertEmployeeRecords(); break;
            case 2: DisplayAllRecords(); break;
            case 3: Environment.Exit(0); break;
            default: Console.WriteLine("Invalid Choice"); DisplayAllRecords(); break;
        }
    }
}