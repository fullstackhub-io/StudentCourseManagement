namespace Course.Persistence
{
    using Course.Application.Common.Interfaces;
    using Course.Domain.UnitOfWork;
    using Course.Persistence.Constant;
    using Microsoft.Extensions.DependencyInjection;
    using System.Data;
    using System.Data.SqlClient;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddSingleton<IDbConnection>(conn => new SqlConnection(conn.GetService<IConfigConstants>().CourseConnection));
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork.UnitOfWork(uof.GetService<IDbConnection>()));
            return services;
        }
    }
}