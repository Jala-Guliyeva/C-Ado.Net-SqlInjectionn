
using SQL.Utils;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1

            Console.WriteLine("Id daxil edin:");
            int id = Convert.ToInt32(Console.ReadLine());
            await GetEmployeeById(id);

            //2

            await GetAllEmployees();

            //3

            Console.WriteLine("Fullname daxil edin:");
            string fullname = Console.ReadLine();
            await AddEmployee(fullname);

            //4

            Console.WriteLine("Id daxil edin:");
            int id1 = Convert.ToInt32(Console.ReadLine());
            await DeleteEmployee(id1);

            //5

            Console.WriteLine("Search daxil edin:");
            string search = Console.ReadLine();
            await FilterByName(search);

        }

        //1.
        public async static Task GetEmployeeById(int id )
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();
              
                string command = $"SELECT Fullname FROM  Employee WHERE Id={id}";
                //string command = $"SELECT * FROM  Employee WHERE Id={id}";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

        //2.

        public async static Task GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
               
                    connection.Open();

                    string command = $"SELECT Fullname  FROM Employee ";
                 // string command = $"SELECT *  FROM Employee ";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                        }
                    }
                
            }
        }

        //3.
        public async static Task AddEmployee(string fullname)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();
                
                string command = $"INSERT INTO Employee VALUES('{fullname}')";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@fullname", fullname);
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

        //4.
        public async static Task DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();
                
                string command = $"DELETE FROM Employee WHERE Id= {id}";
              

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

        //5.
        public async static Task FilterByName(string search)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();
                string command = $"SELECT * FROM Employee WHERE Fullname LIKE '%{search}%'";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@search", search);
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

    }
}
