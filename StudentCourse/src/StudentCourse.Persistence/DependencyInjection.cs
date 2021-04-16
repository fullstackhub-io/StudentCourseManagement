﻿namespace UserCourse.Persistence
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Data;
    using System.Data.SqlClient;
    using StudentCourse.Domain.UnitOfWork;
    using StudentCourse.Application.Common.Interfaces;
    using StudentCourse.Persistence.Constant;
    using StudentCourse.Persistence.UnitOfWork;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddSingleton<IDbConnection>(conn => new SqlConnection(conn.GetService<IConfigConstants>().CourseConnection));
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork(uof.GetService<IDbConnection>()));
            return services;
        }
    }
}
