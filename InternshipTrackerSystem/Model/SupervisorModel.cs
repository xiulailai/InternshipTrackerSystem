using System;

namespace InternshipTrackerSystem.Models
{
    /// Represents a Supervisor in the system
    public class SupervisorModel
    {
        // Primary properties from Supervisors table
        public int SupervisorId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Specialization { get; set; }

        // User account properties (from Users table via foreign key)
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        /// Default constructor
        public SupervisorModel()
        {
            IsActive = true;
            UserRole = "Supervisor";
            CreatedDate = DateTime.Now;
        }

        /// Constructor with essential parameters
        public SupervisorModel(int supervisorId, int userId, string fullName, string email)
        {
            SupervisorId = supervisorId;
            UserId = userId;
            FullName = fullName;
            Email = email;
            IsActive = true;
            UserRole = "Supervisor";
        }

        /// Returns supervisor's display name with department
        public string DisplayName
        {
            get
            {
                return string.IsNullOrEmpty(Department)
                    ? FullName
                    : $"{FullName} ({Department})";
            }
        }

        /// Validates if all required fields are filled
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(FullName) &&
                   !string.IsNullOrWhiteSpace(Email);
        }
    }

    /// Represents an Internship with student and company details
    /// Used for supervisor to view assigned interns
    public class InternshipModel
    {
        // Internship properties
        public int InternshipId { get; set; }
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public int CompanyId { get; set; }
        public int? SupervisorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Ongoing, Completed, Terminated
        public DateTime? CompletionDate { get; set; }

        // Student information (from Students table)
        public string StudentName { get; set; }
        public string StudentIdNumber { get; set; }
        public string StudentProgram { get; set; }
        public string StudentContact { get; set; }
        public string StudentEmail { get; set; }
        public decimal? StudentGPA { get; set; }

        // Company information (from Companies table)
        public string CompanyName { get; set; }
        public string CompanyIndustry { get; set; }
        public string CompanyLocation { get; set; }

        // Position information (from InternshipPositions table)
        public string PositionTitle { get; set; }

        // Supervisor information
        public string SupervisorName { get; set; }

        // Calculated properties
        public int DurationInDays
        {
            get { return (EndDate - StartDate).Days; }
        }

        public bool IsOngoing
        {
            get { return Status == "Ongoing"; }
        }

        public bool IsCompleted
        {
            get { return Status == "Completed"; }
        }

        /// Default constructor
        public InternshipModel()
        {
            Status = "Ongoing";
        }
    }

    /// Represents a student report/logbook submission
    public class StudentReportModel
    {
        public int ReportId { get; set; }
        public int InternshipId { get; set; }
        public int StudentId { get; set; }
        public string ReportType { get; set; } // Weekly, Monthly, Final
        public DateTime SubmissionDate { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; } // Submitted, Reviewed, Approved, Rejected

        // Additional student info for display
        public string StudentName { get; set; }
        public string StudentIdNumber { get; set; }
        public string CompanyName { get; set; }

        /// Default constructor
        public StudentReportModel()
        {
            SubmissionDate = DateTime.Now;
            Status = "Submitted";
        }

        /// Checks if report is pending review
        public bool IsPendingReview
        {
            get { return Status == "Submitted"; }
        }

        /// Gets report type display name
        public string ReportTypeDisplay
        {
            get
            {
                return ReportType switch
                {
                    "Weekly" => "Weekly Report",
                    "Monthly" => "Monthly Report",
                    "Final" => "Final Report",
                    _ => "Report"
                };
            }
        }
    }

    /// Represents a supervisor evaluation of a student's internship performance
    public class SupervisorEvaluationModel
    {
        public int EvaluationId { get; set; }
        public int InternshipId { get; set; }
        public int SupervisorId { get; set; }
        public DateTime EvaluationDate { get; set; }
        public int PerformanceScore { get; set; } // 1-10
        public int PunctualityScore { get; set; } // 1-10
        public int CommunicationScore { get; set; } // 1-10
        public decimal OverallScore { get; set; }
        public string Comments { get; set; }
        public string Recommendations { get; set; }

        // Additional student info for display
        public string StudentName { get; set; }
        public string StudentIdNumber { get; set; }
        public string CompanyName { get; set; }
        public string SupervisorName { get; set; }

        /// Default constructor
        public SupervisorEvaluationModel()
        {
            EvaluationDate = DateTime.Now;
            PerformanceScore = 5;
            PunctualityScore = 5;
            CommunicationScore = 5;
        }

        /// Calculates overall score based on individual scores
        public void CalculateOverallScore()
        {
            OverallScore = Math.Round(
                (PerformanceScore + PunctualityScore + CommunicationScore) / 3.0m,
                2
            );
        }

        /// Validates that all scores are within range (1-10)
        public bool ValidateScores()
        {
            return PerformanceScore >= 1 && PerformanceScore <= 10 &&
                   PunctualityScore >= 1 && PunctualityScore <= 10 &&
                   CommunicationScore >= 1 && CommunicationScore <= 10;
        }

        /// Gets performance rating based on overall score
        public string PerformanceRating
        {
            get
            {
                if (OverallScore >= 9) return "Excellent";
                if (OverallScore >= 7.5m) return "Very Good";
                if (OverallScore >= 6) return "Good";
                if (OverallScore >= 5) return "Satisfactory";
                if (OverallScore >= 3) return "Needs Improvement";
                return "Poor";
            }
        }
    }

    /// Represents a notification for a user
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; } // Application, Internship, Report, Evaluation
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }

        /// Default constructor
        public NotificationModel()
        {
            IsRead = false;
            CreatedDate = DateTime.Now;
        }

        /// Constructor with message
        public NotificationModel(int userId, string message, string type)
        {
            UserId = userId;
            Message = message;
            NotificationType = type;
            IsRead = false;
            CreatedDate = DateTime.Now;
        }

        /// Gets display time (e.g., "2 hours ago", "Yesterday")
        public string TimeAgo
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - CreatedDate;

                if (timeSpan.TotalMinutes < 1)
                    return "Just now";
                if (timeSpan.TotalMinutes < 60)
                    return $"{(int)timeSpan.TotalMinutes} minute(s) ago";
                if (timeSpan.TotalHours < 24)
                    return $"{(int)timeSpan.TotalHours} hour(s) ago";
                if (timeSpan.TotalDays < 7)
                    return $"{(int)timeSpan.TotalDays} day(s) ago";
                if (timeSpan.TotalDays < 30)
                    return $"{(int)(timeSpan.TotalDays / 7)} week(s) ago";

                return CreatedDate.ToString("MMM dd, yyyy");
            }
        }
    }

    /// Represents a Student in the system
    /// Used when supervisor needs to view student details
    public class StudentModel
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string StudentIdNumber { get; set; }
        public string FullName { get; set; }
        public string Program { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public decimal? GPA { get; set; }
        public string Skills { get; set; }
        public string Resume { get; set; }

        // User account properties
        public string Email { get; set; }
        public string Username { get; set; }

        /// Gets formatted GPA display
        public string GPADisplay
        {
            get
            {
                return GPA.HasValue ? GPA.Value.ToString("0.00") : "N/A";
            }
        }
    }

    /// Represents a Company in the system
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        /// Default constructor
        public CompanyModel()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
    }

    /// Summary statistics for supervisor dashboard
    public class SupervisorStatisticsModel
    {
        public int TotalInternships { get; set; }
        public int OngoingInternships { get; set; }
        public int CompletedInternships { get; set; }
        public int PendingReports { get; set; }
        public int PendingEvaluations { get; set; }
        public int TotalStudentsSupervised { get; set; }
    }
}