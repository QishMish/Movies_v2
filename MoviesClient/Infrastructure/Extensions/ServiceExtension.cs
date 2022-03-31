using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using Movies.EF.Repository;
using Movies.Services.Abstractions;
using Movies.Services.Implementations;

namespace MoviesAdmin.Infrastructure.Extensions
{
    static public class ServiceExtentions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddRepositories();
        }
    }
}
