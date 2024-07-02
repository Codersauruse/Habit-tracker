using ConsoleTableExt;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace Habit_Logger
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString;
        private string query;
        private MySqlDataAdapter da;

        public DatabaseConnection()
        {
            _connectionString = "datasource=localhost;port=3306;database=habits;user=code;password=code123";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }


        public void insertdata(String habitName,DateTime startDate,int hours) { 
            using(MySqlConnection conn = GetConnection())
            {
                query = "INSERT INTO habits (habitName, startDate,endDate, hours ,progress) VALUES (@habitName, @startDate, @endDate, @hours ,@progress)";
                using(var cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@habitName", habitName);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", DBNull.Value); // Assuming endDate can be NULL
                    cmd.Parameters.AddWithValue("@hours", hours);

                    cmd.Parameters.AddWithValue("@progress", 1);

                    try { 
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        //Console.WriteLine("Record added Successfully");
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Record isn't added");

                    }


                }
            }
            
        
        }
        public void deletedata(String habitName) {

            query = "DELETE FROM habits WHERE habitName = @habitName";

            using (var connection = GetConnection())
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@habitName", habitName);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("record deleted successfully");
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting data: {ex.Message}");
                    }
                }
            }
        }
        public void updateData(String habitName,DateTime endDate,int progress) {
            using (MySqlConnection conn = GetConnection())
            {
                query = "UPDATE habits SET endDate = @endDate,progress = @progress WHERE habitName = @habitName;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@habitName", habitName);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    cmd.Parameters.AddWithValue("@progress", progress);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Record updated Successfully");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Record isn't updated");

                    }


                }
            }


        }

        public void ViewData() {
            query = "SELECT * FROM habits";

            using (var connection = GetConnection())
            {
                
                   

                    try
                    {
                        connection.Open();
                        da = new MySqlDataAdapter(query,connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                         var tableData = new List<List<object>>();
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        tableData.Add(new List<object> { row["habitName"], row["startDate"], row["endDate"], row["hours"], row["progress"] });
                       
                    }
                    ConsoleTableBuilder
                    .From(tableData)
                    .ExportAndWriteLine();

                }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting data: {ex.Message}");
                    }
                
            }

        }  

    }

}

