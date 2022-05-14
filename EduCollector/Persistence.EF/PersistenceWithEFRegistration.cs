using EduCollector.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EduCollectorContext>(options => options.UseSqlServer(configuration.GetConnectionString("EduCollectorConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWebinarRepository, WebinaryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
