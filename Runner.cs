using System.Data;
using System.Data.SqlClient;

namespace EmployeeADO;

class Runner
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=DESKTOP-9TNLIB5\\SQLEXPRESS;Initial Catalog=ado_db;Integrated Security=true;";

        //establishing connection
        Connection(connectionString);
    }

    static void Connection(string connectionString)
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
    }
}
