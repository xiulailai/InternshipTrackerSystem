using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Model;
using InternshipTrackerSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InternshipTrackerSystem.Class
{
    public class CompanyHRClass
    {
        public static CompanyHRModel GetHRByUserId(int userId)
        {
            try
            {
                string query = @"
                    SELECT ch.hrid, ch.userid, ch.companyid, ch.fullname, ch.position,
                           c.companyname, c.industry, c.location, u.email
                    FROM companyhr ch
                    INNER JOIN companies c ON ch.companyid = c.companyid
                    INNER JOIN users u ON ch.userid = u.userid
                    WHERE ch.userid = @userid";

                var parameters = new Dictionary<string, object>
                {
                    { "@userid", userId }
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new CompanyHRModel
                    {
                        HRId = Convert.ToInt32(row["hrid"]),
                        UserId = Convert.ToInt32(row["userid"]),
                        CompanyId = Convert.ToInt32(row["companyid"]),
                        FullName = row["fullname"].ToString(),
                        Position = row["position"].ToString(),
                        CompanyName = row["companyname"].ToString(),
                        Industry = row["industry"].ToString(),
                        Location = row["location"].ToString(),
                        Email = row["email"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching HR data: {ex.Message}");
            }
        }

        /// <summary>
        /// Get statistics for HR dashboard
        /// </summary>
        public static HRStatisticsModel GetHRStatistics(int companyId)
        {
            try
            {
                HRStatisticsModel stats = new HRStatisticsModel();

                // Active Positions
                string queryPositions = @"
                    SELECT COUNT(*) FROM internshippositions 
                    WHERE companyid = @companyid AND status = 'Open'";

                var paramsCompany = new Dictionary<string, object> { { "@companyid", companyId } };
                object result = DatabaseHelper.ExecuteScalar(queryPositions, paramsCompany);
                stats.ActivePositions = result != null ? Convert.ToInt32(result) : 0;

                // Total Applications
                string queryApplications = @"
                    SELECT COUNT(*) FROM applications a
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE ip.companyid = @companyid";

                result = DatabaseHelper.ExecuteScalar(queryApplications, paramsCompany);
                stats.TotalApplications = result != null ? Convert.ToInt32(result) : 0;

                // Pending Reviews
                string queryPending = @"
                    SELECT COUNT(*) FROM applications a
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE ip.companyid = @companyid AND a.status = 'Pending'";

                result = DatabaseHelper.ExecuteScalar(queryPending, paramsCompany);
                stats.PendingReviews = result != null ? Convert.ToInt32(result) : 0;

                // Active Interns
                string queryInterns = @"
                    SELECT COUNT(*) FROM internships 
                    WHERE companyid = @companyid AND status = 'Ongoing'";

                result = DatabaseHelper.ExecuteScalar(queryInterns, paramsCompany);
                stats.ActiveInterns = result != null ? Convert.ToInt32(result) : 0;

                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching statistics: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all internship positions for a company
        /// </summary>
        public static DataTable GetCompanyPositions(int companyId)
        {
            try
            {
                string query = @"
                    SELECT 
                        ip.positionid,
                        ip.title,
                        ip.description,
                        ip.requirements,
                        ip.status,
                        ip.posteddate,
                        COUNT(a.applicationid) AS applications
                    FROM internshippositions ip
                    LEFT JOIN applications a ON ip.positionid = a.positionid
                    WHERE ip.companyid = @companyid
                    GROUP BY ip.positionid, ip.title, ip.description, ip.requirements, 
                             ip.status, ip.posteddate
                    ORDER BY ip.posteddate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@companyid", companyId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching positions: {ex.Message}");
            }
        }

        /// <summary>
        /// Get applications for company positions with filter
        /// </summary>
        public static DataTable GetApplications(int companyId, string statusFilter = "All")
        {
            try
            {
                string query = @"
                    SELECT a.applicationid, s.fullname, s.matricno, s.program, s.cgpa, ip.title AS position, a.applieddate, a.status, s.skills, s.contactno
                    FROM applications a
                    INNER JOIN students s ON a.studentid = s.studentid
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE ip.companyid = @companyid";

                if (statusFilter != "All")
                {
                    query += " AND a.status = @status";
                }

                query += " ORDER BY a.applieddate DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@companyid", companyId }
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
        /// Create new internship position
        /// </summary>
        public static bool CreatePosition(int companyId, int hrId, string title,
                                         string description, string requirements, string status)
        {
            try
            {
                string query = @"
                    INSERT INTO internshippositions 
                    (companyid, postedbyhrid, title, description, requirements, status, posteddate)
                    VALUES (@companyid, @hrid, @title, @description, @requirements, @status, GETDATE())";

                var parameters = new Dictionary<string, object>
                {
                    { "@companyid", companyId },
                    { "@hrid", hrId },
                    { "@title", title },
                    { "@description", description },
                    { "@requirements", requirements },
                    { "@status", status }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating position: {ex.Message}");
            }
        }

        /// <summary>
        /// Update position status (Open/Closed)
        /// </summary>
        public static bool UpdatePositionStatus(int positionId, string status)
        {
            try
            {
                string query = @"
                    UPDATE internshippositions 
                    SET status = @status 
                    WHERE positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId },
                    { "@status", status }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating position status: {ex.Message}");
            }
        }

        /// <summary>
        /// Review application (Accept/Reject)
        /// </summary>
        public static bool ReviewApplication(int applicationId, int hrId, string status, string remarks)
        {
            try
            {
                string query = @"
                    UPDATE applications 
                    SET status = @status, reviewedbyhrid = @hrid, remarks = @remarks
                    WHERE applicationid = @applicationid";

                var parameters = new Dictionary<string, object>
                {
                    { "@applicationid", applicationId },
                    { "@hrid", hrId },
                    { "@status", status },
                    { "@remarks", remarks }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                // If accepted, create internship record
                if (rowsAffected > 0 && status == "Accepted")
                {
                    CreateInternshipRecord(applicationId);
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reviewing application: {ex.Message}");
            }
        }

        /// <summary>
        /// Create internship record when application is accepted
        /// </summary>
        private static void CreateInternshipRecord(int applicationId)
        {
            try
            {
                string query = @"
                    INSERT INTO internships (applicationid, studentid, companyid, startdate, status)
                    SELECT @applicationid, a.studentid, ip.companyid, GETDATE(), 'Ongoing'
                    FROM applications a
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE a.applicationid = @applicationid";

                var parameters = new Dictionary<string, object>
                {
                    { "@applicationid", applicationId }
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating internship record: {ex.Message}");
            }
        }

        /// <summary>
        /// Get unread notification count for HR
        /// </summary>
        public static int GetUnreadNotificationCount(int userId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM notifications 
                    WHERE userid = @userid AND isread = 0";

                var parameters = new Dictionary<string, object>
                {
                    { "@userid", userId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}

