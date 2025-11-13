namespace InternshipTrackerSystem.Models
{
    // 这个 Model 用来封装一个学生注册时需要的所有信息
    public class Student
    {
        // 来自 students 表
        public string StudentIdNumber { get; set; }
        public string FullName { get; set; }
        public string Program { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        // 来自 users 表
        public string Username { get; set; }
        public string Email { get; set; }

        // 密码 (password) 我们是单独传递的，所以不需要放在 Model 里
    }

    // ---
    // 注意:
    // 我们在 Form 5 (申请实习) 时用到的 ApplicationResult enum，
    // 因为你觉得太复杂，我们最后没有使用它，
    // 所以这个文件里不需要包含 ApplicationResult enum。
    //
    // 另外，RegistrationResult enum (用于注册) 被我们放在 DatabaseHelper.cs
    // 文件里了，所以这里也不需要。
    // ---
}