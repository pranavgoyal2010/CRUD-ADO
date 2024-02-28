﻿using System.Data.SqlClient;

namespace EmployeeADO;

class Runner
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=DESKTOP-9TNLIB5\\SQLEXPRESS;Initial Catalog=ado_db;Integrated Security=true;";

        //SqlConnection conn = new SqlConnection(connectionString);
        //establishing connection

        //Connection(conn);

        bool state = true;
        while (state)
        {
            Console.WriteLine("1. Insert Data");
            Console.WriteLine("2. Delete Data");
            Console.WriteLine("3. Update Data");
            Console.WriteLine("4. Print Data");
            Console.WriteLine("5. Exit");

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Employee employee = new Employee();

                    Console.WriteLine("Enter name");
                    employee.EmployeeName = Console.ReadLine();

                    Console.WriteLine("Enter gender");
                    employee.EmployeeGender = Console.ReadLine();

                    Console.WriteLine("Enter age");
                    employee.EmployeeAge = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter salary");
                    employee.EmployeeSalary = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter city");
                    employee.EmployeeCity = Console.ReadLine();

                    if (InsertData(employee, connectionString))
                        Console.WriteLine("Insertion done successfully.");
                    else
                        Console.WriteLine("Insertion failed");

                    break;

                case 2:
                    Console.WriteLine("Enter ID of Employee to delete");
                    int EmployeeID = int.Parse(Console.ReadLine());

                    if (DeleteData(EmployeeID, connectionString))
                        Console.WriteLine("Deletion done successfully.");
                    else
                        Console.WriteLine("Deletion failed");

                    break;

                default:
                    state = false;
                    break;
            }

        }
    }

    /*static void Connection(SqlConnection conn)
    {
        bool state = false;

        try
        {
            using (conn)
            {
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection with database established");
                }

                state = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }*/

    static bool InsertData(Employee employee, string connectionString)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        int rowsInserted = 0;
        string query = "INSERT INTO Employee VALUES (@name, @gender, @age, @salary, @city)";
        try
        {
            using (conn)
            {
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@name", employee.EmployeeName);
                comm.Parameters.AddWithValue("@gender", employee.EmployeeGender);
                comm.Parameters.AddWithValue("@age", employee.EmployeeAge);
                comm.Parameters.AddWithValue("@salary", employee.EmployeeSalary);
                comm.Parameters.AddWithValue("@city", employee.EmployeeCity);

                conn.Open();

                rowsInserted = comm.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (rowsInserted > 0)
            return true;
        else
            return false;

    }

    static bool DeleteData(int EmployeeID, string connectionString)
    {
        SqlConnection conn = new SqlConnection(connectionString);
        string query = "DELETE FROM Employee WHERE EmployeeID=@id";
        int rowsDeleted = 0;
        try
        {
            using (conn)
            {
                SqlCommand comm = new SqlCommand(query, conn);

                conn.Open();

                comm.Parameters.AddWithValue("@id", EmployeeID);

                rowsDeleted = comm.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (rowsDeleted > 0)
            return true;
        else
            return false;
    }
}
