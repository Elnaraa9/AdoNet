using System;
using System.Data.SqlClient;

namespace Adonet
{
    class Program
    {
        private const string connectionStr = "Server=DESKTOP-S9687TC;Database=BDU;Integrated Security=true";
        static void Main(string[] args)
        {
            Insert();
            Delete(2);
            Select();
            Update("GUNAY","VAHABOVA");
        }
        
        public static void Insert()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            Console.Write("Name:");
            string name = Console.ReadLine();

            string query = $"INSERT INTO GROUPS VALUES('{name}')";
            SqlCommand newCommand = new SqlCommand(query, connection);
            try
            {
                var result = newCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                Console.WriteLine("Daxil edilen data movcuddur");
            }
            connection.Close();
        }

        public static void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            string query = $"DELETE FROM GROUPS WHERE ID={id}";
            SqlCommand newCommand = new SqlCommand(query, connection);
            int result = newCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void Select()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            
            string query = $"SELECT * FROM GROUPS";
            SqlCommand newCommand = new SqlCommand(query, connection);
            SqlDataReader result = newCommand.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine($"{result[0]},{result[1]},{result[2]}");
            }
            connection.Close();
        }

        public static void Update(string name, string surname)
        {
            SqlConnection connection = new SqlConnection();
            connection.Open();

            string query = $"UPDATE GROUPS SET { name} = 'ELNARA' WHERE {surname} = 'MEMMEDOVA'";
            SqlCommand newCommand = new SqlCommand(query, connection);
            int result = newCommand.ExecuteNonQuery();

            connection.Close();
        }

    }
}
