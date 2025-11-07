using InternshipTrackerSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTrackerSystem.Services
{
    public class UserClass
    {
        public DataRow Login(string email, string password)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email AND PasswordHash = @Password AND IsActive = 1;";

            var parameters = new Dictionary<string, object>
            {
                { "@Email", email },
                { "@Password", password } // ⚠️ For demo; in real system use hashed password
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
                return result.Rows[0];
            else
                return null;
        }
    }
}
