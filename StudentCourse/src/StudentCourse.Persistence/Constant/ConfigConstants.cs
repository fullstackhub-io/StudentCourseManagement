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
        public string CourseConnection => this.Configuration.GetConnectionString("StudentCourseConnection");

        public string TestFullStackConnection => this.Configuration.GetConnectionString("TestFullStackConnection");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);

        public string MSG_USER_NULLUSERID => throw new System.NotImplementedException();

        public string MSG_USER_NULLFIRSTNAME => throw new System.NotImplementedException();

        public string MSG_USER_NULLLASTNAME => throw new System.NotImplementedException();

        public string MSG_USER_NULLDOB => throw new System.NotImplementedException();

        public string MSG_USER_NULLGENDER => throw new System.NotImplementedException();

        public string MSG_USER_GENDER_LEN => throw new System.NotImplementedException();

        public string MSG_USER_NULLEMAILADDR => throw new System.NotImplementedException();

        public string MSG_USER_NULLPHNUM => throw new System.NotImplementedException();

        public string MSG_USER_NULLCITY => throw new System.NotImplementedException();

        public string MSG_USER_NULLSTATE => throw new System.NotImplementedException();

        public string MSG_USER_NULLCOUNTRY => throw new System.NotImplementedException();
    }
}
