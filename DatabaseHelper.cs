using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;

namespace ElevatorControlSystem.Database
{
    public class DatabaseHelper
    {
        private static string connectionString =
            "server=localhost;user=root;password=Luffy@98;database=elevator_db;";

        public static bool InsertLog(string operation, int floor, BackgroundWorker worker = null)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO logs (operation, current_floor, timestamp) VALUES (@op, @floor, @time)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@op", operation);
                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database Error: {ex.Message}");
                return false;
            }
        }

        public static DataTable GetLogs(BackgroundWorker worker = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                    id as 'ID',
                                    DATE(timestamp) as 'Date',
                                    TIME(timestamp) as 'Time',
                                    operation as 'Action'
                                    FROM logs 
                                    ORDER BY timestamp DESC 
                                    LIMIT 100";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading logs: {ex.Message}");
            }

            return dt;
        }

        public static bool ClearLogs(BackgroundWorker worker = null)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM logs";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result >= 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error clearing logs: {ex.Message}");
                return false;
            }
        }
    }
}