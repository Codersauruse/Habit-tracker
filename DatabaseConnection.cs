using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Habit_Tracker
{
    public  class DatabaseConnection
    {
        private MySqlConnection _connection;
        private string myConnectionString;
        private string query;

       
        public MySqlConnection  SetDataBaseConnection() {

            myConnectionString = "datasource=localhost;port=3306;database=habits;user=code;password=code123";
            try {
                _connection = new MySqlConnection(myConnectionString);
                _connection.Open();
                MessageBox.Show("Created connection between database");
                
        
             }
            catch {
                MessageBox.Show(" Not Created connection between database");

            }
            return _connection;
                                



        }
        public void InsertData(string habitName, DateTime? startDate, bool state, int hours)
        {
            query = "INSERT INTO habits (habitName, startDate, endDate, hours, progress) VALUES (@habitName, @startDate, @endDate, @hours, @progress)";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@habitName", habitName);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", DBNull.Value); // Assuming endDate can be NULL
            cmd.Parameters.AddWithValue("@hours", hours);
            cmd.Parameters.AddWithValue("@progress", state);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
        }
        public void DeleteData(string habitName)
        {
            query = "DELETE FROM habits WHERE habitName = @habitName";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@habitName", habitName);
           

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting data: {ex.Message}");
            }
        }

    }



}
