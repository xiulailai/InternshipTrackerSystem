using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTrackerSystem.Model
{
    public class CompanyHRModel
    {
        public int HRId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
    }
    public class HRStatisticsModel
    {
        public int ActivePositions { get; set; }
        public int TotalApplications { get; set; }
        public int PendingReviews { get; set; }
        public int ActiveInterns { get; set; }
    }
    public class InternshipPositionModel
    {
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
        public int PostedByHRId { get; set; }
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
        public DateTime PostedDate { get; set; }

        // Additional properties for display
        public string CompanyName { get; set; }
        public string PostedBy { get; set; }
        public int ApplicationCount { get; set; }
    }

    public class ApplicationDetailsModel
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string ReviewNotes { get; set; }

        // Student Information
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentIdNumber { get; set; }
        public string Program { get; set; }
        public decimal GPA { get; set; }
        public string Skills { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        // Position Information
        public string PositionTitle { get; set; }
    }

    public class PositionDetailsModel : InternshipPositionModel
    {
        public int TotalApplications { get; set; }
        public int PendingApplications { get; set; }
        public int AcceptedApplications { get; set; }
        public int RejectedApplications { get; set; }
    }

}
