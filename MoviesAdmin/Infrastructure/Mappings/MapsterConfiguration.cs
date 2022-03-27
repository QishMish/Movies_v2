using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Poco;
using MoviesAdmin.Models.Movies;
using System.Linq;

namespace MoviesAdmin.Infrastracture.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
            //1. სტანდარტული მეპი

            //TypeAdapterConfig<PersonServiceModel, PersonDTO>
            //.NewConfig()
            //.TwoWays();

            //2. როცა არ ემთხვევა ფროფერთის სახელები ერთმანეთს

            //TypeAdapterConfig<PersonDTO, PersonServiceModel>
            //.NewConfig()
            //.TwoWays()
            //.Map(dest => dest.PersonIdentifier, src => src.Identifier);

            //3. სახელები ემთხვევა მაგრამ ტიპები არა , TwoWays ს არ მუშაობს (ლოგიკურია)
            //DTO->Service
            TypeAdapterConfig<AddMoviesModel, Movie>
               .NewConfig()
               .Map(dest => dest.UserId, src => src.UserId);

            TypeAdapterConfig<EditMoviesModel, Movie>
               .NewConfig()
               .Map(dest => dest.UserId, src => src.UserId)
               .TwoWays();

            //3. Service->DTO 
            //  TypeAdapterConfig<PersonServiceModel, PersonDTO>
            //  .NewConfig()
            //  .Map(dest => dest.CityName, src => src.City.Name)
            //  .Map(dest => dest.Identifier, src => src.PersonIdentifier);


            //  TypeAdapterConfig<CreatePersonRequest, PersonServiceModel>
            // .NewConfig()
            // .Map(dest => dest.City, src => new CityServiceModel { Name = src.City })
            // .Map(dest => dest.PersonIdentifier, src => src.Identifier);



            //  TypeAdapterConfig<PutPersonRequest, PersonServiceModel>
            //.NewConfig()
            ////.Map(dest => dest.City, src => new CityServiceModel { Name = src.City })
            //.Map(dest => dest.PersonIdentifier, src => src.Identifier);


            //4. City-ს რომ ერქვას CItyName(DTO-ში) ავტომატურად მიხვდება, რომ CityServiceModel კლასში 
            //მოძებნოს Name Property და თუ იპოვნის თავად გადაიყვანს CityName-ს(DTO) City.Name - ში (Service)

            //და  .Map(dest => dest.City, src => new CityServiceModel { Name = src.CityName })- ის დაწერა 
            //საჭირო აღარ იქნება 


            //TypeAdapterConfig<PersonServiceModel, Person>
            //.NewConfig()
            //.Map(dest => dest.Identifier, src => src.PersonIdentifier)
            //.Map(dest => dest.PersonPhones, src => src.Phones != null ? src.Phones.Select(x => new PersonPhone { Phone = x.Adapt<Phone>(), PersonId = src.Id, PhoneId = x.Id }) : default);


            //TypeAdapterConfig<Person, PersonServiceModel>
            // .NewConfig()
            // .Map(dest => dest.Phones, src => src.PersonPhones.Select(x => x.Phone));


            //TypeAdapterConfig<UserServiceModel, User>
            //.NewConfig()
            //.TwoWays();

            //TypeAdapterConfig<AccountCreateRequest, UserServiceModel>
            //.NewConfig()
            //.TwoWays();

        }
    }
}
