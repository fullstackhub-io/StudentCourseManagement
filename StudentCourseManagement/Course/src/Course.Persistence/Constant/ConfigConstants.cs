namespace Course.Persistence.Constant
{
    using Course.Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string CourseConnection => this.Configuration.GetConnectionString("CourseConnection");

        public string TestFullStackConnection => this.Configuration.GetConnectionString("TestFullStackConnection");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);

        public string MSG_COURSE_COURSENAME => this.Configuration["AppSettings:MSG_COURSE_COURSENAME"];

        public string MSG_COURSE_NULLCREDITHOUR => this.Configuration["AppSettings:MSG_COURSE_NULLCREDITHOUR"];

        public string MSG_COURSE_COURSEID => this.Configuration["AppSettings:MSG_COURSE_COURSEID"];

    }
}
