using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using Movies.EF;
using Movies.EF.Repository;
using Movies.Services.Abstractions;
using Movies.Services.Implementations;

namespace MoviesAPI.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
