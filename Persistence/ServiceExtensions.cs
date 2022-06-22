using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            var local = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(local,
                b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
        }
    }
}
