using CourseBasket.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CourseBasket.Persistence.Constant
{
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string RedisConnection => this.Configuration.GetConnectionString("Redis");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);
    }
}
