using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Forms;
using InternshipTrackerSystem.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace InternshipTrackerSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUserLogin());
        }
    }
}