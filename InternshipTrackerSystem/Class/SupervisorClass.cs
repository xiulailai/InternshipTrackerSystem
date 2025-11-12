using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InternshipTrackerSystem.Service
{
    /// Service class for Supervisor-related operations
    /// Handles supervisor profile, internship management, evaluations, and reports
    public class SupervisorClass
    {
        #region Supervisor Profile Management

        /// Retrieves supervisor details by user ID
        /// <param name="userId">User ID of the supervisor</param>
        /// <returns>SupervisorModel object containing supervisor details</returns>
        public static SupervisorModel GetSupervisorByUserId(int userId)
        {
            try
            {
                string query = @"
                    SELECT s.SupervisorID, s.UserID, s.FullName, s.Department, s.ContactNumber, s.Specialization,u.Username, u.Email, u.UserRole, u.IsActive, u.CreatedDate
                    FROM Supervisors s
                    INNER JOIN Users u ON s.UserID = u.UserID
                    WHERE s.UserID = @UserId";

                var parameters = new Dictionary<string, object>
                {
                    { "@UserId", userId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return MapToSupervisorModel(dt.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving supervisor profile: {ex.Message}", ex);
            }
        }

        /// Updates supervisor profile information
        /// <param name="supervisor">SupervisorModel with updated information</param>
        /// <returns>True if update successful, false otherwise</returns>
        public static bool UpdateSupervisorProfile(SupervisorModel supervisor)
        {
            try
            {
                string query = @"
                    UPDATE Supervisors 
                    SET FullName = @FullName,
                        Department = @Department,
                        ContactNumber = @ContactNumber,
                        Specialization = @Specialization
                    WHERE SupervisorID = @SupervisorId";

                var parameters = new Dictionary<string, object>
                {
                    { "@FullName", supervisor.FullName },
                    { "@Department", supervisor.Department },
                    { "@ContactNumber", supervisor.ContactNumber },
                    { "@Specialization", supervisor.Specialization },
                    { "@SupervisorId", supervisor.SupervisorId }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating supervisor profile: {ex.Message}", ex);
            }
        }

        #endregion

        #region Internship Management

        /// Retrieves all internships assigned to a specific supervisor
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of InternshipModel objects</returns>
        public static List<InternshipModel> GetInternshipsBySupervisor(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT i.InternshipID, i.ApplicationID, i.StudentID, i.CompanyID, i.SupervisorID, i.StartDate, i.EndDate, i.Status, i.CompletionDate, s.FullName AS StudentName, s.StudentIDNumber, s.Program AS StudentProgram, s.ContactNumber AS StudentContact, s.GPA AS StudentGPA,  u.Email AS StudentEmail, c.CompanyName, c.Industry AS CompanyIndustry, c.Location AS CompanyLocation, p.Title AS PositionTitle, sup.FullName AS SupervisorName
                    FROM Internships i
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Applications a ON i.ApplicationID = a.ApplicationID
                    INNER JOIN InternshipPositions p ON a.PositionID = p.PositionID
                    LEFT JOIN Supervisors sup ON i.SupervisorID = sup.SupervisorID
                    WHERE i.SupervisorID = @SupervisorId
                    ORDER BY i.StartDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<InternshipModel> internships = new List<InternshipModel>();

                foreach (DataRow row in dt.Rows)
                {
                    internships.Add(MapToInternshipModel(row));
                }

                return internships;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving internships: {ex.Message}", ex);
            }
        }

        /// Retrieves ongoing internships for a supervisor
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of ongoing InternshipModel objects</returns>
        public static List<InternshipModel> GetOngoingInternships(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT i.InternshipID, i.ApplicationID, i.StudentID, i.CompanyID,  i.SupervisorID, i.StartDate, i.EndDate, i.Status, i.CompletionDate, s.FullName AS StudentName, s.StudentIDNumber, s.Program AS StudentProgram, s.ContactNumber AS StudentContact, s.GPA AS StudentGPA, u.Email AS StudentEmail,c.CompanyName, c.Industry AS CompanyIndustry, c.Location AS CompanyLocation,p.Title AS PositionTitle, sup.FullName AS SupervisorName
                    FROM Internships i
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Applications a ON i.ApplicationID = a.ApplicationID
                    INNER JOIN InternshipPositions p ON a.PositionID = p.PositionID
                    LEFT JOIN Supervisors sup ON i.SupervisorID = sup.SupervisorID
                    WHERE i.SupervisorID = @SupervisorId AND i.Status = 'Ongoing'
                    ORDER BY i.StartDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<InternshipModel> internships = new List<InternshipModel>();

                foreach (DataRow row in dt.Rows)
                {
                    internships.Add(MapToInternshipModel(row));
                }

                return internships;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving ongoing internships: {ex.Message}", ex);
            }
        }

        /// Retrieves a specific internship by ID
        /// <param name="internshipId">Internship ID</param>
        /// <returns>InternshipModel object</returns>
        public static InternshipModel GetInternshipById(int internshipId)
        {
            try
            {
                string query = @"
                    SELECT i.InternshipID, i.ApplicationID, i.StudentID, i.CompanyID,  i.SupervisorID, i.StartDate, i.EndDate, i.Status, i.CompletionDate, s.FullName AS StudentName, s.StudentIDNumber, s.Program AS StudentProgram, s.ContactNumber AS StudentContact, s.GPA AS StudentGPA, u.Email AS StudentEmail, c.CompanyName, c.Industry AS CompanyIndustry, c.Location AS CompanyLocation, p.Title AS PositionTitle, sup.FullName AS SupervisorName
                    FROM Internships i
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Applications a ON i.ApplicationID = a.ApplicationID
                    INNER JOIN InternshipPositions p ON a.PositionID = p.PositionID
                    LEFT JOIN Supervisors sup ON i.SupervisorID = sup.SupervisorID
                    WHERE i.InternshipID = @InternshipId";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", internshipId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return MapToInternshipModel(dt.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving internship: {ex.Message}", ex);
            }
        }

        #endregion

        #region Student Reports Management

        /// Retrieves all reports for internships supervised by a specific supervisor
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of StudentReportModel objects</returns>
        public static List<StudentReportModel> GetAllReportsBySupervisor(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT sr.ReportID, sr.InternshipID, sr.StudentID, sr.ReportType, sr.SubmissionDate, sr.Content, sr.FilePath, sr.Status, s.FullName AS StudentName, s.StudentIDNumber,c.CompanyName
                    FROM StudentReports sr
                    INNER JOIN Internships i ON sr.InternshipID = i.InternshipID
                    INNER JOIN Students s ON sr.StudentID = s.StudentID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    WHERE i.SupervisorID = @SupervisorId
                    ORDER BY sr.SubmissionDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<StudentReportModel> reports = new List<StudentReportModel>();

                foreach (DataRow row in dt.Rows)
                {
                    reports.Add(MapToStudentReportModel(row));
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving reports: {ex.Message}", ex);
            }
        }

        /// Retrieves pending reports (submitted but not reviewed)
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of pending StudentReportModel objects</returns>
        public static List<StudentReportModel> GetPendingReports(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT sr.ReportID, sr.InternshipID, sr.StudentID, sr.ReportType, sr.SubmissionDate, sr.Content, sr.FilePath, sr.Status, s.FullName AS StudentName, s.StudentIDNumber,c.CompanyName
                    FROM StudentReports sr
                    INNER JOIN Internships i ON sr.InternshipID = i.InternshipID
                    INNER JOIN Students s ON sr.StudentID = s.StudentID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    WHERE i.SupervisorID = @SupervisorId AND sr.Status = 'Submitted'
                    ORDER BY sr.SubmissionDate ASC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<StudentReportModel> reports = new List<StudentReportModel>();

                foreach (DataRow row in dt.Rows)
                {
                    reports.Add(MapToStudentReportModel(row));
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving pending reports: {ex.Message}", ex);
            }
        }

        /// Retrieves reports for a specific internship
        /// <param name="internshipId">Internship ID</param>
        /// <returns>List of StudentReportModel objects</returns>
        public static List<StudentReportModel> GetReportsByInternship(int internshipId)
        {
            try
            {
                string query = @"
                    SELECT sr.ReportID, sr.InternshipID, sr.StudentID, sr.ReportType, sr.SubmissionDate, sr.Content, sr.FilePath, sr.Status, s.FullName AS StudentName, s.StudentIDNumber, c.CompanyName
                    FROM StudentReports sr
                    INNER JOIN Students s ON sr.StudentID = s.StudentID
                    INNER JOIN Internships i ON sr.InternshipID = i.InternshipID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    WHERE sr.InternshipID = @InternshipId
                    ORDER BY sr.SubmissionDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", internshipId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<StudentReportModel> reports = new List<StudentReportModel>();

                foreach (DataRow row in dt.Rows)
                {
                    reports.Add(MapToStudentReportModel(row));
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving internship reports: {ex.Message}", ex);
            }
        }

        /// Updates the status of a student report
        /// <param name="reportId">Report ID</param>
        /// <param name="status">New status (Reviewed, Approved, Rejected)</param>
        /// <returns>True if update successful</returns>
        public static bool UpdateReportStatus(int reportId, string status)
        {
            try
            {
                string query = @"
                    UPDATE StudentReports 
                    SET Status = @Status
                    WHERE ReportID = @ReportId";

                var parameters = new Dictionary<string, object>
                {
                    { "@Status", status },
                    { "@ReportId", reportId }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating report status: {ex.Message}", ex);
            }
        }

        #endregion

        #region Evaluation Management

        /// Creates a new supervisor evaluation for an internship
        /// <param name="evaluation">SupervisorEvaluationModel object</param>
        /// <returns>Evaluation ID if successful, -1 otherwise</returns>
        public static int CreateEvaluation(SupervisorEvaluationModel evaluation)
        {
            try
            {
                // Validate scores before insertion
                if (!evaluation.ValidateScores())
                {
                    throw new Exception("Scores must be between 1 and 10");
                }

                // Calculate overall score
                evaluation.CalculateOverallScore();

                string query = @"
                    INSERT INTO SupervisorEvaluations 
                    (InternshipID, SupervisorID, EvaluationDate, PerformanceScore, 
                     PunctualityScore, CommunicationScore, OverallScore, Comments, Recommendations)
                    VALUES 
                    (@InternshipId, @SupervisorId, @EvaluationDate, @PerformanceScore,
                     @PunctualityScore, @CommunicationScore, @OverallScore, @Comments, @Recommendations);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", evaluation.InternshipId },
                    { "@SupervisorId", evaluation.SupervisorId },
                    { "@EvaluationDate", evaluation.EvaluationDate },
                    { "@PerformanceScore", evaluation.PerformanceScore },
                    { "@PunctualityScore", evaluation.PunctualityScore },
                    { "@CommunicationScore", evaluation.CommunicationScore },
                    { "@OverallScore", evaluation.OverallScore },
                    { "@Comments", evaluation.Comments },
                    { "@Recommendations", evaluation.Recommendations }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating evaluation: {ex.Message}", ex);
            }
        }

        /// Updates an existing evaluation
        /// <param name="evaluation">SupervisorEvaluationModel with updated information</param>
        /// <returns>True if update successful</returns>
        public static bool UpdateEvaluation(SupervisorEvaluationModel evaluation)
        {
            try
            {
                // Validate scores before update
                if (!evaluation.ValidateScores())
                {
                    throw new Exception("Scores must be between 1 and 10");
                }

                // Recalculate overall score
                evaluation.CalculateOverallScore();

                string query = @"
                    UPDATE SupervisorEvaluations 
                    SET PerformanceScore = @PerformanceScore,
                        PunctualityScore = @PunctualityScore,
                        CommunicationScore = @CommunicationScore,
                        OverallScore = @OverallScore,
                        Comments = @Comments,
                        Recommendations = @Recommendations,
                        EvaluationDate = @EvaluationDate
                    WHERE EvaluationID = @EvaluationId";

                var parameters = new Dictionary<string, object>
                {
                    { "@PerformanceScore", evaluation.PerformanceScore },
                    { "@PunctualityScore", evaluation.PunctualityScore },
                    { "@CommunicationScore", evaluation.CommunicationScore },
                    { "@OverallScore", evaluation.OverallScore },
                    { "@Comments", evaluation.Comments },
                    { "@Recommendations", evaluation.Recommendations },
                    { "@EvaluationDate", evaluation.EvaluationDate },
                    { "@EvaluationId", evaluation.EvaluationId }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating evaluation: {ex.Message}", ex);
            }
        }

        /// Retrieves evaluation for a specific internship
        /// <param name="internshipId">Internship ID</param>
        /// <returns>SupervisorEvaluationModel object or null if not found</returns>
        public static SupervisorEvaluationModel GetEvaluationByInternship(int internshipId)
        {
            try
            {
                string query = @"
                    SELECT se.EvaluationID, se.InternshipID, se.SupervisorID, se.EvaluationDate, se.PerformanceScore, se.PunctualityScore, se.CommunicationScore, se.OverallScore, se.Comments, se.Recommendations, s.FullName AS StudentName, s.StudentIDNumber, c.CompanyName, sup.FullName AS SupervisorName
                    FROM SupervisorEvaluations se
                    INNER JOIN Internships i ON se.InternshipID = i.InternshipID
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Supervisors sup ON se.SupervisorID = sup.SupervisorID
                    WHERE se.InternshipID = @InternshipId";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", internshipId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return MapToEvaluationModel(dt.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving evaluation: {ex.Message}", ex);
            }
        }

        /// Retrieves all evaluations by a supervisor
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of SupervisorEvaluationModel objects</returns>
        public static List<SupervisorEvaluationModel> GetAllEvaluationsBySupervisor(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT se.EvaluationID, se.InternshipID, se.SupervisorID, se.EvaluationDate, se.PerformanceScore, se.PunctualityScore, se.CommunicationScore, se.OverallScore, se.Comments, se.Recommendations, s.FullName AS StudentName, s.StudentIDNumber, c.CompanyName, sup.FullName AS SupervisorName
                    FROM SupervisorEvaluations se
                    INNER JOIN Internships i ON se.InternshipID = i.InternshipID
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Supervisors sup ON se.SupervisorID = sup.SupervisorID
                    WHERE se.SupervisorID = @SupervisorId
                    ORDER BY se.EvaluationDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<SupervisorEvaluationModel> evaluations = new List<SupervisorEvaluationModel>();

                foreach (DataRow row in dt.Rows)
                {
                    evaluations.Add(MapToEvaluationModel(row));
                }

                return evaluations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving evaluations: {ex.Message}", ex);
            }
        }

        /// Checks if an evaluation already exists for an internship
        /// <param name="internshipId">Internship ID</param>
        /// <returns>True if evaluation exists, false otherwise</returns>
        public static bool HasEvaluation(int internshipId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM SupervisorEvaluations 
                    WHERE InternshipID = @InternshipId";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", internshipId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking evaluation: {ex.Message}", ex);
            }
        }

        #endregion

        #region Statistics and Dashboard

        /// Retrieves statistics for supervisor dashboard
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>SupervisorStatisticsModel object with summary data</returns>
        public static SupervisorStatisticsModel GetSupervisorStatistics(int supervisorId)
        {
            try
            {
                SupervisorStatisticsModel stats = new SupervisorStatisticsModel();

                // Total internships
                string totalQuery = @"
                    SELECT COUNT(*) 
                    FROM Internships 
                    WHERE SupervisorID = @SupervisorId";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                object totalResult = DatabaseHelper.ExecuteScalar(totalQuery, parameters);
                stats.TotalInternships = totalResult != null ? Convert.ToInt32(totalResult) : 0;

                // Ongoing internships
                string ongoingQuery = @"
                    SELECT COUNT(*) 
                    FROM Internships 
                    WHERE SupervisorID = @SupervisorId AND Status = 'Ongoing'";

                object ongoingResult = DatabaseHelper.ExecuteScalar(ongoingQuery, parameters);
                stats.OngoingInternships = ongoingResult != null ? Convert.ToInt32(ongoingResult) : 0;

                // Completed internships
                string completedQuery = @"
                    SELECT COUNT(*) 
                    FROM Internships 
                    WHERE SupervisorID = @SupervisorId AND Status = 'Completed'";

                object completedResult = DatabaseHelper.ExecuteScalar(completedQuery, parameters);
                stats.CompletedInternships = completedResult != null ? Convert.ToInt32(completedResult) : 0;

                // Pending reports
                string reportsQuery = @"
                    SELECT COUNT(*) 
                    FROM StudentReports sr
                    INNER JOIN Internships i ON sr.InternshipID = i.InternshipID
                    WHERE i.SupervisorID = @SupervisorId AND sr.Status = 'Submitted'";

                object reportsResult = DatabaseHelper.ExecuteScalar(reportsQuery, parameters);
                stats.PendingReports = reportsResult != null ? Convert.ToInt32(reportsResult) : 0;

                // Pending evaluations (ongoing internships without evaluations)
                string evalQuery = @"
                    SELECT COUNT(*) 
                    FROM Internships i
                    LEFT JOIN SupervisorEvaluations se ON i.InternshipID = se.InternshipID
                    WHERE i.SupervisorID = @SupervisorId 
                    AND i.Status = 'Ongoing' 
                    AND se.EvaluationID IS NULL";

                object evalResult = DatabaseHelper.ExecuteScalar(evalQuery, parameters);
                stats.PendingEvaluations = evalResult != null ? Convert.ToInt32(evalResult) : 0;

                // Total students supervised
                string studentsQuery = @"
                    SELECT COUNT(DISTINCT StudentID) 
                    FROM Internships 
                    WHERE SupervisorID = @SupervisorId";

                object studentsResult = DatabaseHelper.ExecuteScalar(studentsQuery, parameters);
                stats.TotalStudentsSupervised = studentsResult != null ? Convert.ToInt32(studentsResult) : 0;

                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving statistics: {ex.Message}", ex);
            }
        }

        #endregion

        #region Notifications

        /// Retrieves notifications for a supervisor
        /// <param name="userId">User ID of the supervisor</param>
        /// <param name="unreadOnly">If true, returns only unread notifications</param>
        /// <returns>List of NotificationModel objects</returns>
        public static List<NotificationModel> GetNotifications(int userId, bool unreadOnly = false)
        {
            try
            {
                string query = @"
                    SELECT TOP 50 NotificationID, UserID, Message, NotificationType, IsRead, CreatedDate
                    FROM Notifications
                    WHERE UserID = @UserId";

                if (unreadOnly)
                {
                    query += " AND IsRead = 0";
                }

                query += " ORDER BY CreatedDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@UserId", userId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<NotificationModel> notifications = new List<NotificationModel>();

                foreach (DataRow row in dt.Rows)
                {
                    notifications.Add(MapToNotificationModel(row));
                }

                return notifications;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving notifications: {ex.Message}", ex);
            }
        }

        /// Marks a notification as read
        /// <param name="notificationId">Notification ID</param>
        /// <returns>True if successful</returns>
        public static bool MarkNotificationAsRead(int notificationId)
        {
            try
            {
                string query = @"
                    UPDATE Notifications 
                    SET IsRead = 1 
                    WHERE NotificationID = @NotificationId";

                var parameters = new Dictionary<string, object>
                {
                    { "@NotificationId", notificationId }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error marking notification as read: {ex.Message}", ex);
            }
        }

        /// Marks all notifications as read for a user
        /// <param name="userId">User ID</param>
        /// <returns>True if successful</returns>
        public static bool MarkAllNotificationsAsRead(int userId)
        {
            try
            {
                string query = @"
                    UPDATE Notifications 
                    SET IsRead = 1 
                    WHERE UserID = @UserId AND IsRead = 0";

                var parameters = new Dictionary<string, object>
                {
                    { "@UserId", userId }
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error marking all notifications as read: {ex.Message}", ex);
            }
        }

        /// Gets count of unread notifications
        /// <param name="userId">User ID</param>
        /// <returns>Count of unread notifications</returns>
        public static int GetUnreadNotificationCount(int userId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM Notifications 
                    WHERE UserID = @UserId AND IsRead = 0";

                var parameters = new Dictionary<string, object>
                {
                    { "@UserId", userId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting unread notification count: {ex.Message}", ex);
            }
        }

        #endregion

        #region Helper/Mapping Methods

        /// Maps DataRow to SupervisorModel object
        private static SupervisorModel MapToSupervisorModel(DataRow row)
        {
            return new SupervisorModel
            {
                SupervisorId = Convert.ToInt32(row["SupervisorID"]),
                UserId = Convert.ToInt32(row["UserID"]),
                FullName = row["FullName"].ToString(),
                Department = row["Department"] != DBNull.Value ? row["Department"].ToString() : null,
                ContactNumber = row["ContactNumber"] != DBNull.Value ? row["ContactNumber"].ToString() : null,
                Specialization = row["Specialization"] != DBNull.Value ? row["Specialization"].ToString() : null,
                Username = row["Username"].ToString(),
                Email = row["Email"].ToString(),
                UserRole = row["UserRole"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }

        /// <summary>
        /// Maps DataRow to InternshipModel object
        /// </summary>
        private static InternshipModel MapToInternshipModel(DataRow row)
        {
            return new InternshipModel
            {
                InternshipId = Convert.ToInt32(row["InternshipID"]),
                ApplicationId = Convert.ToInt32(row["ApplicationID"]),
                StudentId = Convert.ToInt32(row["StudentID"]),
                CompanyId = Convert.ToInt32(row["CompanyID"]),
                SupervisorId = row["SupervisorID"] != DBNull.Value ? (int?)Convert.ToInt32(row["SupervisorID"]) : null,
                StartDate = Convert.ToDateTime(row["StartDate"]),
                EndDate = Convert.ToDateTime(row["EndDate"]),
                Status = row["Status"].ToString(),
                CompletionDate = row["CompletionDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["CompletionDate"]) : null,
                StudentName = row["StudentName"].ToString(),
                StudentIdNumber = row["StudentIDNumber"].ToString(),
                StudentProgram = row["StudentProgram"] != DBNull.Value ? row["StudentProgram"].ToString() : null,
                StudentContact = row["StudentContact"] != DBNull.Value ? row["StudentContact"].ToString() : null,
                StudentEmail = row["StudentEmail"] != DBNull.Value ? row["StudentEmail"].ToString() : null,
                StudentGPA = row["StudentGPA"] != DBNull.Value ? (decimal?)Convert.ToDecimal(row["StudentGPA"]) : null,
                CompanyName = row["CompanyName"].ToString(),
                CompanyIndustry = row["CompanyIndustry"] != DBNull.Value ? row["CompanyIndustry"].ToString() : null,
                CompanyLocation = row["CompanyLocation"] != DBNull.Value ? row["CompanyLocation"].ToString() : null,
                PositionTitle = row["PositionTitle"].ToString(),
                SupervisorName = row["SupervisorName"] != DBNull.Value ? row["SupervisorName"].ToString() : null
            };
        }

        /// Maps DataRow to StudentReportModel object
        private static StudentReportModel MapToStudentReportModel(DataRow row)
        {
            return new StudentReportModel
            {
                ReportId = Convert.ToInt32(row["ReportID"]),
                InternshipId = Convert.ToInt32(row["InternshipID"]),
                StudentId = Convert.ToInt32(row["StudentID"]),
                ReportType = row["ReportType"] != DBNull.Value ? row["ReportType"].ToString() : null,
                SubmissionDate = Convert.ToDateTime(row["SubmissionDate"]),
                Content = row["Content"] != DBNull.Value ? row["Content"].ToString() : null,
                FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : null,
                Status = row["Status"].ToString(),
                StudentName = row["StudentName"].ToString(),
                StudentIdNumber = row["StudentIDNumber"].ToString(),
                CompanyName = row["CompanyName"].ToString()
            };
        }

        /// <summary>
        /// Maps DataRow to SupervisorEvaluationModel object
        /// </summary>
        private static SupervisorEvaluationModel MapToEvaluationModel(DataRow row)
        {
            return new SupervisorEvaluationModel
            {
                EvaluationId = Convert.ToInt32(row["EvaluationID"]),
                InternshipId = Convert.ToInt32(row["InternshipID"]),
                SupervisorId = Convert.ToInt32(row["SupervisorID"]),
                EvaluationDate = Convert.ToDateTime(row["EvaluationDate"]),
                PerformanceScore = Convert.ToInt32(row["PerformanceScore"]),
                PunctualityScore = Convert.ToInt32(row["PunctualityScore"]),
                CommunicationScore = Convert.ToInt32(row["CommunicationScore"]),
                OverallScore = Convert.ToDecimal(row["OverallScore"]),
                Comments = row["Comments"] != DBNull.Value ? row["Comments"].ToString() : null,
                Recommendations = row["Recommendations"] != DBNull.Value ? row["Recommendations"].ToString() : null,
                StudentName = row["StudentName"].ToString(),
                StudentIdNumber = row["StudentIDNumber"].ToString(),
                CompanyName = row["CompanyName"].ToString(),
                SupervisorName = row["SupervisorName"] != DBNull.Value ? row["SupervisorName"].ToString() : null
            };
        }

        /// <summary>
        /// Maps DataRow to NotificationModel object
        /// </summary>
        private static NotificationModel MapToNotificationModel(DataRow row)
        {
            return new NotificationModel
            {
                NotificationId = Convert.ToInt32(row["NotificationID"]),
                UserId = Convert.ToInt32(row["UserID"]),
                Message = row["Message"].ToString(),
                NotificationType = row["NotificationType"] != DBNull.Value ? row["NotificationType"].ToString() : null,
                IsRead = Convert.ToBoolean(row["IsRead"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }

        #endregion

        #region Additional Utility Methods

        /// Retrieves student details by student ID
        /// <param name="studentId">Student ID</param>
        /// <returns>StudentModel object</returns>
        public static StudentModel GetStudentById(int studentId)
        {
            try
            {
                string query = @"
                    SELECT s.StudentID, s.UserID, s.StudentIDNumber, s.FullName, s.Program, s.ContactNumber, s.Address, s.GPA, s.Skills, s.Resume, u.Email, u.Username
                    FROM Students s
                    INNER JOIN Users u ON s.UserID = u.UserID
                    WHERE s.StudentID = @StudentId";

                var parameters = new Dictionary<string, object>
                {
                    { "@StudentId", studentId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new StudentModel
                    {
                        StudentId = Convert.ToInt32(row["StudentID"]),
                        UserId = Convert.ToInt32(row["UserID"]),
                        StudentIdNumber = row["StudentIDNumber"].ToString(),
                        FullName = row["FullName"].ToString(),
                        Program = row["Program"] != DBNull.Value ? row["Program"].ToString() : null,
                        ContactNumber = row["ContactNumber"] != DBNull.Value ? row["ContactNumber"].ToString() : null,
                        Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : null,
                        GPA = row["GPA"] != DBNull.Value ? (decimal?)Convert.ToDecimal(row["GPA"]) : null,
                        Skills = row["Skills"] != DBNull.Value ? row["Skills"].ToString() : null,
                        Resume = row["Resume"] != DBNull.Value ? row["Resume"].ToString() : null,
                        Email = row["Email"].ToString(),
                        Username = row["Username"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student details: {ex.Message}", ex);
            }
        }

        /// Gets list of all supervisors (useful for admin or reports)
        /// <returns>List of SupervisorModel objects</returns>
        public static List<SupervisorModel> GetAllSupervisors()
        {
            try
            {
                string query = @"
                    SELECT s.SupervisorID, s.UserID, s.FullName, s.Department, s.ContactNumber, s.Specialization,u.Username, u.Email, u.UserRole, u.IsActive, u.CreatedDate
                    FROM Supervisors s
                    INNER JOIN Users u ON s.UserID = u.UserID
                    WHERE u.IsActive = 1
                    ORDER BY s.FullName";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                List<SupervisorModel> supervisors = new List<SupervisorModel>();

                foreach (DataRow row in dt.Rows)
                {
                    supervisors.Add(MapToSupervisorModel(row));
                }

                return supervisors;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving supervisors: {ex.Message}", ex);
            }
        }

        /// Searches internships by student name or ID number
        /// <param name="supervisorId">Supervisor ID</param>
        /// <param name="searchTerm">Search term (student name or ID)</param>
        /// <returns>List of matching InternshipModel objects</returns>
        public static List<InternshipModel> SearchInternships(int supervisorId, string searchTerm)
        {
            try
            {
                string query = @"
                    SELECT i.InternshipID, i.ApplicationID, i.StudentID, i.CompanyID, i.SupervisorID, i.StartDate, i.EndDate, i.Status, i.CompletionDate,s.FullName AS StudentName, s.StudentIDNumber, s.Program AS StudentProgram,s.ContactNumber AS StudentContact, s.GPA AS StudentGPA,u.Email AS StudentEmail,c.CompanyName, c.Industry AS CompanyIndustry, c.Location AS CompanyLocation,p.Title AS PositionTitle,sup.FullName AS SupervisorName
                    FROM Internships i
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Applications a ON i.ApplicationID = a.ApplicationID
                    INNER JOIN InternshipPositions p ON a.PositionID = p.PositionID
                    LEFT JOIN Supervisors sup ON i.SupervisorID = sup.SupervisorID
                    WHERE i.SupervisorID = @SupervisorId 
                    AND (LOWER(s.FullName) LIKE @SearchTerm OR LOWER(s.StudentIDNumber) LIKE @SearchTerm)
                    ORDER BY i.StartDate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId },
                    { "@SearchTerm", "%" + searchTerm.ToLower() + "%" }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<InternshipModel> internships = new List<InternshipModel>();

                foreach (DataRow row in dt.Rows)
                {
                    internships.Add(MapToInternshipModel(row));
                }

                return internships;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching internships: {ex.Message}", ex);
            }
        }

        /// Gets internships that need evaluation (ongoing without evaluation)
        /// <param name="supervisorId">Supervisor ID</param>
        /// <returns>List of InternshipModel objects needing evaluation</returns>
        public static List<InternshipModel> GetInternshipsNeedingEvaluation(int supervisorId)
        {
            try
            {
                string query = @"
                    SELECT i.InternshipID, i.ApplicationID, i.StudentID, i.CompanyID, i.SupervisorID, i.StartDate, i.EndDate, i.Status, i.CompletionDate,s.FullName AS StudentName, s.StudentIDNumber, s.Program AS StudentProgram, s.ContactNumber AS StudentContact, s.GPA AS StudentGPA,u.Email AS StudentEmail,c.CompanyName, c.Industry AS CompanyIndustry, c.Location AS CompanyLocation, p.Title AS PositionTitle, sup.FullName AS SupervisorName
                    FROM Internships i
                    INNER JOIN Students s ON i.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN Companies c ON i.CompanyID = c.CompanyID
                    INNER JOIN Applications a ON i.ApplicationID = a.ApplicationID
                    INNER JOIN InternshipPositions p ON a.PositionID = p.PositionID
                    LEFT JOIN Supervisors sup ON i.SupervisorID = sup.SupervisorID
                    LEFT JOIN SupervisorEvaluations se ON i.InternshipID = se.InternshipID
                    WHERE i.SupervisorID = @SupervisorId 
                    AND i.Status = 'Ongoing'
                    AND se.EvaluationID IS NULL
                    ORDER BY i.StartDate ASC";

                var parameters = new Dictionary<string, object>
                {
                    { "@SupervisorId", supervisorId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                List<InternshipModel> internships = new List<InternshipModel>();

                foreach (DataRow row in dt.Rows)
                {
                    internships.Add(MapToInternshipModel(row));
                }

                return internships;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving internships needing evaluation: {ex.Message}", ex);
            }
        }

        /// Validates if a supervisor can access a specific internship
        /// <param name="supervisorId">Supervisor ID</param>
        /// <param name="internshipId">Internship ID</param>
        /// <returns>True if supervisor is assigned to this internship</returns>
        public static bool ValidateSupervisorAccess(int supervisorId, int internshipId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM Internships 
                    WHERE InternshipID = @InternshipId AND SupervisorID = @SupervisorId";

                var parameters = new Dictionary<string, object>
                {
                    { "@InternshipId", internshipId },
                    { "@SupervisorId", supervisorId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error validating supervisor access: {ex.Message}", ex);
            }
        }

        #endregion
    }
}