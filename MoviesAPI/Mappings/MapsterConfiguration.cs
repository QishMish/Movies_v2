using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Poco;
using Movies.Services.Models;
using MoviesAPI.Models;
using MoviesClient.Models.UserActions;
using System.Linq;

namespace MoviesAdmin.Infrastracture.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
         
            TypeAdapterConfig<UserActionModel, Booking>
               .NewConfig()
               .Map(dest => dest.User_id, src => src.UserId)
               .Map(dest => dest.Movie_id, src => src.MovieId)
               .TwoWays();

            TypeAdapterConfig<UserActionModel, Purchase>
               .NewConfig()
               .Map(dest => dest.User_id, src => src.UserId)
               .Map(dest => dest.Movie_id, src => src.MovieId)
               .TwoWays();
            //TypeAdapterConfig<UserRegisterModel, Purchase>
            //  .NewConfig()
            //  .Map(dest => dest.User_id, src => src.UserId)
            //  .Map(dest => dest.Movie_id, src => src.MovieId)
            //  .TwoWays();
            TypeAdapterConfig<UserLoginModel, UserServiceLoginModel>
              .NewConfig()
              .TwoWays();
        }
    }
}
