using EduCollector.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddEduCollectorPersistenceEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EduCollectorContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EduCollectorConnectionString"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWebinarRepository, WebinaryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
