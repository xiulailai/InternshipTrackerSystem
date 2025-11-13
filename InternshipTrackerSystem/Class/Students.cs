using System;

namespace assignment_student // (或者 InternshipTrackerSystem.Models)
{
    /// <summary>
    /// 静态类，用于在整个应用程序中存储当前登录的用户会话信息
    /// </summary>
    public static class Students
    {
        public static int StudentId { get; set; }
        public static string LoginEmail { get; set; }

        // 你还可以在这里添加更多信息，比如学生姓名
        // public static string StudentName { get; set; }

        /// <summary>
        /// 登出时调用此方法，清除所有会话信息
        /// </summary>
        public static void Clear()
        {
            StudentId = 0;
            LoginEmail = null;
            // StudentName = null;
        }
    }
}