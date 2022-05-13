using System.Reflection;
using Formation.Infrastructure.Repositories;

namespace Formation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlite(configuration.GetSection("Sqlite").Value));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<AuthorRepository, AuthorRepositoryImp>();
            services.AddScoped<BookRepository, BookRepositoryImp>();
            return services;
        }
    }
}
