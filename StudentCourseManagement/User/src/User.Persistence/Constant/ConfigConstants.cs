namespace User.Persistence.Constant
{
    using Microsoft.Extensions.Configuration;
    using User.Application.Common.Interfaces;
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string UserConnection => this.Configuration.GetConnectionString("UserConnection");

        public string TestFullStackConnection => this.Configuration.GetConnectionString("TestFullStackConnection");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);

        public string MSG_USER_NULLUSERID => this.Configuration["AppSettings:MSG_USER_NULLUSERID"];
        public string MSG_USER_NULLFIRSTNAME => this.Configuration["AppSettings:MSG_USER_NULLFIRSTNAME"];
        public string MSG_USER_NULLLASTNAME => this.Configuration["AppSettings:MSG_USER_NULLLASTNAME"];
        public string MSG_USER_NULLDOB => this.Configuration["AppSettings:MSG_USER_NULLDOB"];
        public string MSG_USER_NULLGENDER => this.Configuration["AppSettings:MSG_USER_NULLGENDER"];
        public string MSG_USER_GENDER_LEN => this.Configuration["AppSettings:MSG_USER_GENDER_LEN"];
        public string MSG_USER_NULLEMAILADDR => this.Configuration["AppSettings:MSG_USER_NULLEMAILADDR"];
        public string MSG_USER_NULLPHNUM => this.Configuration["AppSettings:MSG_USER_NULLPHNUM"];
        public string MSG_USER_NULLCITY => this.Configuration["AppSettings:MSG_USER_NULLCITY"];
        public string MSG_USER_NULLSTATE => this.Configuration["AppSettings:MSG_USER_NULLSTATE"];
        public string MSG_USER_NULLCOUNTRY => this.Configuration["AppSettings:MSG_USER_NULLCOUNTRY"];
    }
}
