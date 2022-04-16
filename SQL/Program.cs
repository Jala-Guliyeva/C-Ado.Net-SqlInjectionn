
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetByName();
            //GetAllStudents();
        }

        private static string ConnectionString = "Data Source=.; Initial Catalog=KURS;Integrated Security=true;";


        public static void GetByName()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string command = "SELECT Name FROM STUDENTS";
                SqlCommand com = new SqlCommand(command, connection);
                string result = com.ExecuteScalar().ToString();
                {
                    Console.WriteLine(result);




                }
            }



        }
        //public async static Task GetAllStudents()
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();
        //        string command = "SELECT * FROM STUDENTS ";
        //        using (SqlConnection com = new SqlConnection(command, connection))
        //        {
        //            SqlDataReader reader = await com.ExecuteReaderAsync();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    Console.WriteLine($"Name:{reader["Name"]}");
        //                }
        //            }
        //        }
        //    }
        //}

       
    }
}
