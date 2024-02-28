using System.Data;
using System.Data.SqlClient;

namespace EmployeeADO;

class Runner
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=DESKTOP-9TNLIB5\\SQLEXPRESS;Initial Catalog=ado_db;Integrated Security=true;";

        //establishing connection
        SqlConnection conn = Connection(connectionString);

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

                    InsertData(employee);
            }

        }
    }

    static SqlConnection Connection(string connectionString)
    {
        SqlConnection conn = null;

        try
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection with database established");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return conn;
    }

    static bool InsertData(Employee employee, SqlConnection conn)
    {
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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }
}
