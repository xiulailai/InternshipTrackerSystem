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
}
