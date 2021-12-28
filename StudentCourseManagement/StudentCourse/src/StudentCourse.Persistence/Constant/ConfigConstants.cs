using Microsoft.Extensions.Configuration;
using StudentCourse.Application.Common.Interfaces;

namespace StudentCourse.Persistence.Constant
{
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string StudentCourseConnection => this.Configuration.GetConnectionString("StudentCourseConnection");

        public string TestFullStackConnection => this.Configuration.GetConnectionString("TestFullStackConnection");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);

        public string MSG_COURSE_COURSENAME => this.Configuration["AppSettings:MSG_COURSE_COURSENAME"];

        public string MSG_COURSE_NULLCREDITHOUR => this.Configuration["AppSettings:MSG_COURSE_NULLCREDITHOUR"];

        public string MSG_COURSE_COURSEID => this.Configuration["AppSettings:MSG_COURSE_COURSEID"];

        public string MSG_SC_NULLStdCourseID => this.Configuration["AppSettings:MSG_SC_NULLStdCourseID"];
    }
}
