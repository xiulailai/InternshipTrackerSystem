using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BCrypt.Net; 
using InternshipTrackerSystem.Models; 
using NpgsqlTypes; 
namespace InternshipTrackerSystem.Data
{
       public enum RegistrationResult
    {
        Success,
        EmailExists,
        StudentIdExists,
        UnknownError
    }

    public class DatabaseHelper
    {
        // ✅ PostgreSQL connection string
        private static string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

        // Allow changing connection string if needed
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

        public static RegistrationResult RegisterStudent(Student student, string password)
        {
            string passwordHash = BCrypt.HashPassword(password);
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string checkEmailSql = "SELECT COUNT(*) FROM users WHERE email = @em;";
                            using (var checkCmd = new NpgsqlCommand(checkEmailSql, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@em", student.Email);
                                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                                {
                                    return RegistrationResult.EmailExists;
                                }
                            }
                            
                            string checkStudentSql = "SELECT COUNT(*) FROM students WHERE studentidnumber = @id;";
                            using (var checkCmd = new NpgsqlCommand(checkStudentSql, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@id", student.StudentIdNumber);
                                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                                {
                                    return RegistrationResult.StudentIdExists;
                                }
                            }
                            
                            int newUserId;
                            string insertUserSql = @"INSERT INTO users (username, email, passwordhash, userrole)
                                             VALUES (@user, @em, @pass, @role)
                                             RETURNING userid;";
                            using (var cmdUser = new NpgsqlCommand(insertUserSql, conn, transaction))
                            {
                                cmdUser.Parameters.AddWithValue("@user", student.Username);
                                cmdUser.Parameters.AddWithValue("@em", student.Email);
                                cmdUser.Parameters.AddWithValue("@pass", passwordHash);
                                cmdUser.Parameters.AddWithValue("@role", "Student");
                                newUserId = Convert.ToInt32(cmdUser.ExecuteScalar());
                            }
                           
                            string insertStudentSql = @"INSERT INTO students 
                                                (studentidnumber, fullname, program, contactnumber, address, userid)
                                                VALUES (@id, @name, @prog, @contact, @addr, @uid);";
                            using (var cmdStudent = new NpgsqlCommand(insertStudentSql, conn, transaction))
                            {
                                cmdStudent.Parameters.AddWithValue("@id", student.StudentIdNumber);
                                cmdStudent.Parameters.AddWithValue("@name", student.FullName);
                                cmdStudent.Parameters.AddWithValue("@prog", student.Program);
                                cmdStudent.Parameters.AddWithValue("@contact", student.ContactNumber);
                                cmdStudent.Parameters.AddWithValue("@addr", student.Address);
                                cmdStudent.Parameters.AddWithValue("@uid", newUserId);
                                cmdStudent.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            return RegistrationResult.Success;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            LogError($"Error in RegisterStudent Transaction: {ex.Message}");
                            return RegistrationResult.UnknownError;
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    LogError($"Database connection error in RegisterStudent: {ex.Message}");
                    return RegistrationResult.UnknownError;
                }
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