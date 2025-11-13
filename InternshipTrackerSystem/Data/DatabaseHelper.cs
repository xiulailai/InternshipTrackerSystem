using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using NpgsqlTypes; 

namespace InternshipTrackerSystem.Data
{
    public class DatabaseHelper
    {        
        private static string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

     
        public static void SetConnectionString(string connString)
        {
            connectionString = connString;
        }

       
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error in ExecuteQuery: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return dataTable;
        }

        
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rowsAffected = 0;
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error in ExecuteNonQuery: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return rowsAffected;
        }

       
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error in ExecuteScalar: {ex.Message}\nQuery: {query}");
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return result;
        }

      
        private static void LogError(string message)
        {
            try
            {
                string logPath = "ErrorLog.txt";
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n\n";
                File.AppendAllText(logPath, logMessage);
            }
            catch
            {

            }
        }

       
        public static bool SubmitReport(int internshipId, int studentId, string reportType, byte[] fileData, string fileName)
        {
            string sql = @"
                INSERT INTO reports 
                (internshipid, studentid, reporttype, submissiondate, content, filepath, status) 
                VALUES 
                (@internshipid, @studentid, @reporttype, @submissiondate, @content, @filepath, @status)";
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@internshipid", internshipId);
                        cmd.Parameters.AddWithValue("@studentid", studentId);
                        cmd.Parameters.AddWithValue("@reporttype", reportType);
                        cmd.Parameters.AddWithValue("@submissiondate", DateTime.Now);                       
                        cmd.Parameters.Add(new NpgsqlParameter("@content", NpgsqlDbType.Bytea) { Value = fileData });
                        cmd.Parameters.AddWithValue("@filepath", fileName);
                        cmd.Parameters.AddWithValue("@status", "Submitted");
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error in SubmitReport: {ex.Message}\nQuery: {sql}");
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}