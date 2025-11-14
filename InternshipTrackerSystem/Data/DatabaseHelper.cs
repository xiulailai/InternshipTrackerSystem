using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Sql;

namespace InternshipTrackerSystem.Data
{
    public class DatabaseHelper
    {
        // Connection string to SQL Server database
        private static string connectionString = ConfigurationManager.ConnectionStrings["InternshipTrackerDB"]?.ConnectionString
            ?? @"Server=localhost;Database=InternshipTracker;Integrated Security=True;TrustServerCertificate=True";

        // Alternative connection string with SQL Server authentication:
        // ?? @"Server=localhost;Database=InternshipTracker;User Id=sa;Password=YourPassword;";

        // Function to set connection string
        public static void SetConnectionString(string connString)
        {
            connectionString = connString;
        }

        // Execute queries that return results (SELECT)
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters if provided
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                // Handle NULL values properly
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        // Open connection and fill DataTable
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL Server-specific errors
                LogError($"SQL Server Error in ExecuteQuery: {sqlEx.Message}\nQuery: {query}");
                MessageBox.Show($"Database error occurred: {sqlEx.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                // Log general errors
                LogError($"Error in ExecuteQuery: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"An error occurred while retrieving data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return dataTable;
        }

        // Execute queries that modify data (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters if provided
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                // Handle NULL values properly
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        // Open connection and execute query
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL Server-specific errors
                LogError($"SQL Server Error in ExecuteNonQuery: {sqlEx.Message}\nQuery: {query}");
                MessageBox.Show($"Database error occurred: {sqlEx.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                // Log general errors
                LogError($"Error in ExecuteNonQuery: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"An error occurred while modifying data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return rowsAffected;
        }

        // Execute queries that return a single value
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters if provided
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        connection.Open();
                        result = command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError($"SQL Server Error in ExecuteScalar: {sqlEx.Message}\nQuery: {query}");
                MessageBox.Show($"Database error occurred: {sqlEx.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                LogError($"Error in ExecuteScalar: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return result;
        }

        // Log errors to a file
        private static void LogError(string message)
        {
            try
            {
                string logPath = "ErrorLog.txt";
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n\n";
                System.IO.File.AppendAllText(logPath, logMessage);
            }
            catch
            {
                // Silently fail if logging doesn't work
            }
        }

        //Submit a report with file upload
        public static bool SubmitReport(int applicationId, int studentId, string reportType, byte[] fileData, string fileName)
        {
            string query = @"
        INSERT INTO reports (applicationid, studentid, reporttype, filedata, filename, submissiondate, status)
        VALUES (@applicationid, @studentid, @reporttype, @filedata, @filename, @submissiondate, @status)";

            var parameters = new Dictionary<string, object>
    {
        { "@applicationid", applicationId },
        { "@studentid", studentId },
        { "@reporttype", reportType },
        { "@filedata", fileData },
        { "@filename", fileName },
        { "@submissiondate", DateTime.Now },
        { "@status", "Submitted" }
    };

            try
            {
                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                LogError($"Error in SubmitReport: {ex.Message}");
                return false;
            }
        }
        
    }
}