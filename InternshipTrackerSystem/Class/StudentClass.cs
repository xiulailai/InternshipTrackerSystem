using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Models;
using System;
using System.Data;
using System.Collections.Generic;

namespace InternshipTrackerSystem.Class
{
    public class StudentClass
    {
        // =============================================
        // STUDENT PROFILE METHODS
        // =============================================

        /// <summary>
        /// Get student profile information by UserID
        /// </summary>
        public static StudentProfileModel GetStudentProfile(int userId)
        {
            try
            {
                string query = @"
                    SELECT s.studentid, s.userid, s.studentidnumber, s.fullname, s.program, 
                           s.contactnumber, s.address, s.gpa, s.skills, s.resume, u.email
                    FROM Students s
                    INNER JOIN Users u ON s.userid = u.userid
                    WHERE s.userid = @userid";

                var parameters = new Dictionary<string, object>
                {
                    { "@userid", userId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new StudentProfileModel
                    {
                        StudentId = Convert.ToInt32(row["studentid"]),
                        UserId = Convert.ToInt32(row["userid"]),
                        StudentIdNumber = row["studentidnumber"].ToString(),
                        FullName = row["fullname"].ToString(),
                        Program = row["program"].ToString(),
                        ContactNumber = row["contactnumber"].ToString(),
                        Address = row["address"].ToString(),
                        GPA = row["gpa"] != DBNull.Value ? Convert.ToDecimal(row["gpa"]) : 0.00m,
                        Skills = row["skills"].ToString(),
                        Resume = row["resume"].ToString(),
                        Email = row["email"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching student profile: {ex.Message}");
            }
        }

        /// <summary>
        /// Get student statistics for dashboard
        /// </summary>
        public static StudentStatisticsModel GetStudentStatistics(int studentId)
        {
            try
            {
                StudentStatisticsModel stats = new StudentStatisticsModel();

                var parameters = new Dictionary<string, object> { { "@studentid", studentId } };

                // Total Applications
                string queryApplications = @"
                    SELECT COUNT(*) FROM Applications WHERE studentid = @studentid";
                object result = DatabaseHelper.ExecuteScalar(queryApplications, parameters);
                stats.TotalApplications = result != null ? Convert.ToInt32(result) : 0;

                // Pending Applications
                string queryPending = @"
                    SELECT COUNT(*) FROM Applications 
                    WHERE studentid = @studentid AND status = 'Pending'";
                result = DatabaseHelper.ExecuteScalar(queryPending, parameters);
                stats.PendingApplications = result != null ? Convert.ToInt32(result) : 0;

                // Active Internships
                string queryInternships = @"
                    SELECT COUNT(*) FROM Internships 
                    WHERE studentid = @studentid AND status = 'Ongoing'";
                result = DatabaseHelper.ExecuteScalar(queryInternships, parameters);
                stats.ActiveInternships = result != null ? Convert.ToInt32(result) : 0;

                // Reports Submitted
                string queryReports = @"
                    SELECT COUNT(*) FROM StudentReports 
                    WHERE studentid = @studentid";
                result = DatabaseHelper.ExecuteScalar(queryReports, parameters);
                stats.ReportsSubmitted = result != null ? Convert.ToInt32(result) : 0;

                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching student statistics: {ex.Message}");
            }
        }

        // =============================================
        // INTERNSHIP SEARCH & APPLICATION METHODS
        // =============================================

        /// <summary>
        /// Search available internship positions with filters
        /// </summary>
        public static DataTable SearchInternships(string searchText = "", string locationFilter = "All", string companyFilter = "All")
        {
            try
            {
                string query = @"
                    SELECT ip.positionid, ip.title, ip.description, ip.location, ip.duration, 
                           ip.stipend, ip.startdate, ip.enddate, ip.applicationdeadline, 
                           ip.availableslots, c.companyname, c.industry
                    FROM InternshipPositions ip
                    INNER JOIN Companies c ON ip.companyid = c.companyid
                    WHERE ip.status = 'Open' AND ip.applicationdeadline >= GETDATE()";

                var parameters = new Dictionary<string, object>();

                // Search by title or description
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += " AND (ip.title LIKE @search OR ip.description LIKE @search)";
                    parameters.Add("@search", $"%{searchText}%");
                }

                // Filter by location
                if (locationFilter != "All")
                {
                    query += " AND ip.location = @location";
                    parameters.Add("@location", locationFilter);
                }

                // Filter by company
                if (companyFilter != "All")
                {
                    query += " AND c.companyname = @company";
                    parameters.Add("@company", companyFilter);
                }

                query += " ORDER BY ip.posteddate DESC";

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching internships: {ex.Message}");
            }
        }

        /// <summary>
        /// Get detailed information about a specific position
        /// </summary>
        public static InternshipDetailsModel GetInternshipDetails(int positionId)
        {
            try
            {
                string query = @"
                    SELECT ip.positionid, ip.title, ip.description, ip.requirements, ip.location, 
                           ip.duration, ip.stipend, ip.startdate, ip.enddate, ip.applicationdeadline, 
                           ip.availableslots, ip.status, c.companyid, c.companyname, c.industry, 
                           c.contactemail, c.contactphone, c.website
                    FROM InternshipPositions ip
                    INNER JOIN Companies c ON ip.companyid = c.companyid
                    WHERE ip.positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new InternshipDetailsModel
                    {
                        PositionId = Convert.ToInt32(row["positionid"]),
                        Title = row["title"].ToString(),
                        Description = row["description"].ToString(),
                        Requirements = row["requirements"].ToString(),
                        Location = row["location"].ToString(),
                        Duration = Convert.ToInt32(row["duration"]),
                        Stipend = row["stipend"].ToString(),
                        StartDate = Convert.ToDateTime(row["startdate"]),
                        EndDate = Convert.ToDateTime(row["enddate"]),
                        ApplicationDeadline = Convert.ToDateTime(row["applicationdeadline"]),
                        AvailableSlots = Convert.ToInt32(row["availableslots"]),
                        Status = row["status"].ToString(),
                        CompanyId = Convert.ToInt32(row["companyid"]),
                        CompanyName = row["companyname"].ToString(),
                        Industry = row["industry"].ToString(),
                        ContactEmail = row["contactemail"].ToString(),
                        ContactPhone = row["contactphone"].ToString(),
                        Website = row["website"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching internship details: {ex.Message}");
            }
        }

        /// <summary>
        /// Check if student has already applied for a position
        /// </summary>
        public static bool HasApplied(int studentId, int positionId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM Applications 
                    WHERE studentid = @studentid AND positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId },
                    { "@positionid", positionId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking application status: {ex.Message}");
            }
        }

        /// <summary>
        /// Apply for an internship position
        /// </summary>
        public static bool ApplyForInternship(int studentId, int positionId, string coverLetter)
        {
            try
            {
                // Check if already applied
                if (HasApplied(studentId, positionId))
                {
                    throw new Exception("You have already applied for this position");
                }

                // Check if position is still open
                string checkQuery = @"
                    SELECT status, applicationdeadline FROM InternshipPositions 
                    WHERE positionid = @positionid";

                var checkParams = new Dictionary<string, object>
                {
                    { "@positionid", positionId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Position not found");
                }

                DataRow row = dt.Rows[0];
                if (row["status"].ToString() != "Open")
                {
                    throw new Exception("This position is no longer accepting applications");
                }

                DateTime deadline = Convert.ToDateTime(row["applicationdeadline"]);
                if (DateTime.Now > deadline)
                {
                    throw new Exception("Application deadline has passed");
                }

                // Submit application
                string query = @"
                    INSERT INTO Applications (studentid, positionid, applicationdate, status, coverletter)
                    VALUES (@studentid, @positionid, GETDATE(), 'Pending', @coverletter)";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId },
                    { "@positionid", positionId },
                    { "@coverletter", coverLetter }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error applying for internship: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all applications for a student
        /// </summary>
        public static DataTable GetStudentApplications(int studentId, string statusFilter = "All")
        {
            try
            {
                string query = @"
                    SELECT a.applicationid, a.applicationdate, a.status, ip.title AS positiontitle, 
                           c.companyname, ip.location, ip.startdate, a.reviewnotes
                    FROM Applications a
                    INNER JOIN InternshipPositions ip ON a.positionid = ip.positionid
                    INNER JOIN Companies c ON ip.companyid = c.companyid
                    WHERE a.studentid = @studentid";

                if (statusFilter != "All")
                {
                    query += " AND a.status = @status";
                }

                query += " ORDER BY a.applicationdate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId }
                };

                if (statusFilter != "All")
                {
                    parameters.Add("@status", statusFilter);
                }

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching applications: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancel/Withdraw an application (only if status is Pending)
        /// </summary>
        public static bool CancelApplication(int applicationId)
        {
            try
            {
                // Check if application status is Pending
                string checkQuery = "SELECT status FROM Applications WHERE applicationid = @applicationid";
                var checkParams = new Dictionary<string, object>
                {
                    { "@applicationid", applicationId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Application not found");
                }

                string status = dt.Rows[0]["status"].ToString();
                if (status != "Pending")
                {
                    throw new Exception($"Cannot cancel application with status: {status}");
                }

                // Update status to Withdrawn
                string query = @"
                    UPDATE Applications 
                    SET status = 'Withdrawn' 
                    WHERE applicationid = @applicationid";

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, checkParams);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error canceling application: {ex.Message}");
            }
        }

        /// <summary>
        /// Get list of unique locations for filter
        /// </summary>
        public static DataTable GetAvailableLocations()
        {
            try
            {
                string query = @"
                    SELECT DISTINCT location 
                    FROM InternshipPositions 
                    WHERE status = 'Open' AND applicationdeadline >= GETDATE()
                    ORDER BY location";

                return DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching locations: {ex.Message}");
            }
        }

        /// <summary>
        /// Get list of companies for filter
        /// </summary>
        public static DataTable GetAvailableCompanies()
        {
            try
            {
                string query = @"
                    SELECT DISTINCT c.companyname 
                    FROM Companies c
                    INNER JOIN InternshipPositions ip ON c.companyid = ip.companyid
                    WHERE ip.status = 'Open' AND ip.applicationdeadline >= GETDATE()
                    ORDER BY c.companyname";

                return DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching companies: {ex.Message}");
            }
        }

        // =============================================
        // REPORT MANAGEMENT METHODS
        // =============================================

        /// <summary>
        /// Get student's active internships for report submission
        /// </summary>
        public static DataTable GetActiveInternships(int studentId)
        {
            try
            {
                string query = @"
                    SELECT i.internshipid, c.companyname, ip.title AS positiontitle, 
                           i.startdate, i.enddate, i.status
                    FROM Internships i
                    INNER JOIN Companies c ON i.companyid = c.companyid
                    INNER JOIN Applications a ON i.applicationid = a.applicationid
                    INNER JOIN InternshipPositions ip ON a.positionid = ip.positionid
                    WHERE i.studentid = @studentid AND i.status = 'Ongoing'
                    ORDER BY i.startdate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching active internships: {ex.Message}");
            }
        }

        /// <summary>
        /// Submit a new report
        /// </summary>
        public static bool SubmitReport(int internshipId, int studentId, string reportType, string content, string filePath)
        {
            try
            {
                // Validate report type
                if (reportType != "Weekly" && reportType != "Monthly" && reportType != "Final")
                {
                    throw new Exception("Invalid report type. Must be 'Weekly', 'Monthly', or 'Final'");
                }

                // Validate content
                if (string.IsNullOrWhiteSpace(content) || content.Length < 50)
                {
                    throw new Exception("Report content must be at least 50 characters long");
                }

                string query = @"
                    INSERT INTO StudentReports (internshipid, studentid, reporttype, submissiondate, content, filepath, status)
                    VALUES (@internshipid, @studentid, @reporttype, GETDATE(), @content, @filepath, 'Submitted')";

                var parameters = new Dictionary<string, object>
                {
                    { "@internshipid", internshipId },
                    { "@studentid", studentId },
                    { "@reporttype", reportType },
                    { "@content", content },
                    { "@filepath", string.IsNullOrWhiteSpace(filePath) ? DBNull.Value : (object)filePath }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error submitting report: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all reports submitted by student
        /// </summary>
        public static DataTable GetStudentReports(int studentId, string statusFilter = "All")
        {
            try
            {
                string query = @"
                    SELECT sr.reportid, sr.internshipid, sr.reporttype, sr.submissiondate, 
                           sr.status, c.companyname, ip.title AS positiontitle
                    FROM StudentReports sr
                    INNER JOIN Internships i ON sr.internshipid = i.internshipid
                    INNER JOIN Companies c ON i.companyid = c.companyid
                    INNER JOIN Applications a ON i.applicationid = a.applicationid
                    INNER JOIN InternshipPositions ip ON a.positionid = ip.positionid
                    WHERE sr.studentid = @studentid";

                if (statusFilter != "All")
                {
                    query += " AND sr.status = @status";
                }

                query += " ORDER BY sr.submissiondate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId }
                };

                if (statusFilter != "All")
                {
                    parameters.Add("@status", statusFilter);
                }

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching reports: {ex.Message}");
            }
        }

        /// <summary>
        /// Get detailed information about a specific report
        /// </summary>
        public static ReportDetailsModel GetReportDetails(int reportId)
        {
            try
            {
                string query = @"
                    SELECT sr.reportid, sr.internshipid, sr.reporttype, sr.submissiondate, 
                           sr.content, sr.filepath, sr.status, c.companyname, ip.title AS positiontitle
                    FROM StudentReports sr
                    INNER JOIN Internships i ON sr.internshipid = i.internshipid
                    INNER JOIN Companies c ON i.companyid = c.companyid
                    INNER JOIN Applications a ON i.applicationid = a.applicationid
                    INNER JOIN InternshipPositions ip ON a.positionid = ip.positionid
                    WHERE sr.reportid = @reportid";

                var parameters = new Dictionary<string, object>
                {
                    { "@reportid", reportId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new ReportDetailsModel
                    {
                        ReportId = Convert.ToInt32(row["reportid"]),
                        InternshipId = Convert.ToInt32(row["internshipid"]),
                        ReportType = row["reporttype"].ToString(),
                        SubmissionDate = Convert.ToDateTime(row["submissiondate"]),
                        Content = row["content"].ToString(),
                        FilePath = row["filepath"] != DBNull.Value ? row["filepath"].ToString() : string.Empty,
                        Status = row["status"].ToString(),
                        CompanyName = row["companyname"].ToString(),
                        PositionTitle = row["positiontitle"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching report details: {ex.Message}");
            }
        }

        /// <summary>
        /// Resubmit a rejected report
        /// </summary>
        public static bool ResubmitReport(int reportId, string content, string filePath)
        {
            try
            {
                // Check if report status is Rejected
                string checkQuery = "SELECT status FROM StudentReports WHERE reportid = @reportid";
                var checkParams = new Dictionary<string, object>
                {
                    { "@reportid", reportId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Report not found");
                }

                string status = dt.Rows[0]["status"].ToString();
                if (status != "Rejected")
                {
                    throw new Exception($"Can only resubmit rejected reports. Current status: {status}");
                }

                // Validate content
                if (string.IsNullOrWhiteSpace(content) || content.Length < 50)
                {
                    throw new Exception("Report content must be at least 50 characters long");
                }

                // Update report
                string query = @"
                    UPDATE StudentReports 
                    SET content = @content, 
                        filepath = @filepath, 
                        submissiondate = GETDATE(), 
                        status = 'Submitted'
                    WHERE reportid = @reportid";

                var parameters = new Dictionary<string, object>
                {
                    { "@reportid", reportId },
                    { "@content", content },
                    { "@filepath", string.IsNullOrWhiteSpace(filePath) ? DBNull.Value : (object)filePath }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error resubmitting report: {ex.Message}");
            }
        }

        /// <summary>
        /// Get student's evaluations
        /// </summary>
        public static DataTable GetStudentEvaluations(int studentId)
        {
            try
            {
                string query = @"
                    SELECT se.evaluationid, se.evaluationdate, se.performancescore, 
                           se.punctualityscore, se.communicationscore, se.overallscore, 
                           se.comments, c.companyname, s.fullname AS supervisorname
                    FROM SupervisorEvaluations se
                    INNER JOIN Internships i ON se.internshipid = i.internshipid
                    INNER JOIN Companies c ON i.companyid = c.companyid
                    INNER JOIN Supervisors s ON se.supervisorid = s.supervisorid
                    WHERE i.studentid = @studentid
                    ORDER BY se.evaluationdate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@studentid", studentId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching evaluations: {ex.Message}");
            }
        }
    }

    // =============================================
    // MODEL CLASSES
    // =============================================

    public class StudentProfileModel
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string StudentIdNumber { get; set; }
        public string FullName { get; set; }
        public string Program { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public decimal GPA { get; set; }
        public string Skills { get; set; }
        public string Resume { get; set; }
        public string Email { get; set; }
    }

    public class StudentStatisticsModel
    {
        public int TotalApplications { get; set; }
        public int PendingApplications { get; set; }
        public int ActiveInternships { get; set; }
        public int ReportsSubmitted { get; set; }
    }

    public class InternshipDetailsModel
    {
        public int PositionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public string Stipend { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public int AvailableSlots { get; set; }
        public string Status { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Website { get; set; }
    }

    public class ReportDetailsModel
    {
        public int ReportId { get; set; }
        public int InternshipId { get; set; }
        public string ReportType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
    }
}