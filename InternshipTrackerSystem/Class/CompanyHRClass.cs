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
                    FROM CompanyHR ch
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
        public static HRStatisticsModel GetHRStatistics(int companyId)
        {
            try
            {
                HRStatisticsModel stats = new HRStatisticsModel();

                // Active Positions
                string queryPositions = @"
                    SELECT COUNT(*) FROM InternshipPositions 
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
        public static string GetCompanyName(int companyId)
        {
            try
            {
                string query = "SELECT companyname FROM companies WHERE companyid = @companyid";

                var parameters = new Dictionary<string, object>
                {
                    { "@companyid", companyId }
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                return result != null ? result.ToString() : "Unknown Company";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching company name: {ex.Message}");
            }
        }

        public static bool CreatePosition(int companyId, int hrId, string title, string description, string requirements, string status)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(title) || title.Length < 5)
                {
                    throw new Exception("Position title must be at least 5 characters long");
                }

                if (string.IsNullOrWhiteSpace(description) || description.Length < 20)
                {
                    throw new Exception("Description must be at least 20 characters long");
                }

                if (string.IsNullOrWhiteSpace(requirements) || requirements.Length < 10)
                {
                    throw new Exception("Requirements must be at least 10 characters long");
                }

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

        public static DataTable GetCompanyPositions(int companyId, string statusFilter = "All")
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
                    WHERE ip.companyid = @companyid";

                if (statusFilter != "All")
                {
                    query += " AND ip.status = @status";
                }

                query += @"
                    GROUP BY ip.positionid, ip.title, ip.description, ip.requirements, 
                             ip.status, ip.posteddate
                    ORDER BY ip.posteddate DESC";

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
                throw new Exception($"Error fetching positions: {ex.Message}");
            }
        }

        public static bool UpdatePositionStatus(int positionId, string status)
        {
            try
            {
                // Validate status
                if (status != "Open" && status != "Closed")
                {
                    throw new Exception("Invalid status. Must be 'Open' or 'Closed'");
                }

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

        public static bool DeletePosition(int positionId)
        {
            try
            {
                // First delete related applications
                string deleteApplications = @"
                    DELETE FROM applications 
                    WHERE positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId }
                };

                DatabaseHelper.ExecuteNonQuery(deleteApplications, parameters);

                // Then delete the position
                string deletePosition = @"
                    DELETE FROM internshippositions 
                    WHERE positionid = @positionid";

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(deletePosition, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting position: {ex.Message}");
            }
        }

        public static DataTable GetPositionById(int positionId)
        {
            try
            {
                string query = @"
                    SELECT 
                        positionid,
                        title,
                        description,
                        requirements,
                        status,
                        posteddate
                    FROM internshippositions
                    WHERE positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching position by ID: {ex.Message}");
            }
        }

        public static bool UpdatePosition(int positionId, string title, string description, string requirements, string status)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(title) || title.Length < 5)
                {
                    throw new Exception("Position title must be at least 5 characters long");
                }

                if (string.IsNullOrWhiteSpace(description) || description.Length < 20)
                {
                    throw new Exception("Description must be at least 20 characters long");
                }

                if (string.IsNullOrWhiteSpace(requirements) || requirements.Length < 10)
                {
                    throw new Exception("Requirements must be at least 10 characters long");
                }

                if (status != "Open" && status != "Closed")
                {
                    throw new Exception("Invalid status. Must be 'Open' or 'Closed'");
                }

                string query = @"
                    UPDATE internshippositions 
                    SET title = @title, 
                        description = @description, 
                        requirements = @requirements, 
                        status = @status
                    WHERE positionid = @positionid";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId },
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
                throw new Exception($"Error updating position: {ex.Message}");
            }
        }

        public static DataTable GetPositionDetails(int positionId)
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
                        c.companyname,
                        ch.fullname AS postedby,
                        COUNT(a.applicationid) AS totalapplications,
                        SUM(CASE WHEN a.status = 'Pending' THEN 1 ELSE 0 END) AS pendingapplications,
                        SUM(CASE WHEN a.status = 'Accepted' THEN 1 ELSE 0 END) AS acceptedapplications,
                        SUM(CASE WHEN a.status = 'Rejected' THEN 1 ELSE 0 END) AS rejectedapplications
                    FROM internshippositions ip
                    INNER JOIN companies c ON ip.companyid = c.companyid
                    INNER JOIN companyhr ch ON ip.postedbyhrid = ch.hrid
                    LEFT JOIN applications a ON ip.positionid = a.positionid
                    WHERE ip.positionid = @positionid
                    GROUP BY ip.positionid, ip.title, ip.description, ip.requirements, 
                             ip.status, ip.posteddate, c.companyname, ch.fullname";

                var parameters = new Dictionary<string, object>
                {
                    { "@positionid", positionId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching position details: {ex.Message}");
            }
        }

        public static DataTable GetCompanyPositionsList(int companyId)
        {
            try
            {
                string query = @"
                    SELECT DISTINCT title
                    FROM internshippositions
                    WHERE companyid = @companyid
                    ORDER BY title";

                var parameters = new Dictionary<string, object>
                {
                    { "@companyid", companyId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching positions list: {ex.Message}");
            }
        }

        public static DataTable GetApplicationsByCompany(int companyId, string statusFilter = "All", string positionFilter = "All")
        {
            try
            {
                string query = @"
                    SELECT 
                        a.applicationid,
                        a.studentid,
                        s.fullname AS studentname,
                        ip.positionid,
                        ip.title AS positiontitle,
                        a.applieddate,
                        a.status
                    FROM applications a
                    INNER JOIN students s ON a.studentid = s.studentid
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE ip.companyid = @companyid";

                // Add status filter
                if (statusFilter != "All")
                {
                    query += " AND a.status = @status";
                }

                // Add position filter
                if (positionFilter != "All")
                {
                    query += " AND ip.title = @position";
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

                if (positionFilter != "All")
                {
                    parameters.Add("@position", positionFilter);
                }

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching applications: {ex.Message}");
            }
        }

        public static DataTable GetApplicationDetails(int applicationId)
        {
            try
            {
                string query = @"
                    SELECT 
                        a.applicationid,
                        a.applieddate,
                        a.status,
                        a.remarks,
                        s.studentid,
                        s.fullname AS studentname,
                        s.matricno,
                        s.program,
                        s.cgpa,
                        s.skills,
                        s.contactno,
                        u.email,
                        ip.title AS positiontitle
                    FROM applications a
                    INNER JOIN students s ON a.studentid = s.studentid
                    INNER JOIN users u ON s.userid = u.userid
                    INNER JOIN internshippositions ip ON a.positionid = ip.positionid
                    WHERE a.applicationid = @applicationid";

                var parameters = new Dictionary<string, object>
                {
                    { "@applicationid", applicationId }
                };

                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching application details: {ex.Message}");
            }
        }

        public static bool UpdateApplicationStatus(int applicationId, int hrId, string status, string remarks)
        {
            try
            {
                // Validate status
                if (status != "Accepted" && status != "Rejected" && status != "Pending")
                {
                    throw new Exception("Invalid status. Must be 'Accepted', 'Rejected', or 'Pending'");
                }

                string query = @"
                    UPDATE applications 
                    SET status = @status,
                        reviewedbyhrid = @hrid,
                        remarks = @remarks
                    WHERE applicationid = @applicationid";

                var parameters = new Dictionary<string, object>
                {
                    { "@applicationid", applicationId },
                    { "@hrid", hrId },
                    { "@status", status },
                    { "@remarks", string.IsNullOrWhiteSpace(remarks) ? DBNull.Value : (object)remarks }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating application status: {ex.Message}");
            }
        }
    }
}

