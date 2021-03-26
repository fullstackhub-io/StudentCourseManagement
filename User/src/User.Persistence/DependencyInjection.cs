namespace User.Persistence
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Data;
    using System.Data.SqlClient;
    using User.Application.Common.Interfaces;
    using User.Domain.UnitOfWork;
    using User.Persistence.Constant;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddSingleton<IDbConnection>(conn => new SqlConnection(conn.GetService<IConfigConstants>().UserConnection));
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork.UnitOfWork(uof.GetService<IDbConnection>()));
            return services;
        }
    }
}