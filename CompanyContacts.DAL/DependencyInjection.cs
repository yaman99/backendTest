using CompanyContacts.Core.Interfaces;
using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.DAL.Common;
using CompanyContacts.DAL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(options => {
                options.ConnectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
                options.DatabaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
            });

            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            return services;
        }
    }
}
