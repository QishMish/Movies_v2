using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Movies.Data;
using Movies.EF;
using Movies.EF.Repository;
using Movies.PersistanceDB.Context;
using Movies.Services.Abstractions;
using Movies.Services.Implementations;
using Movies.Services.Models.JWT;
using MoviesAdmin.Infrastracture.Mappings;
using MoviesAPI.Infrastructure.Extensions;
using MoviesAPI.Infrastructure.Extensions;
using MoviesClient.Infrastracture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Movies API",
                    Version = "V1",
                    Description = "Movies Booking API Service, Developed By TBC IT Academy",
                    Contact = new OpenApiContact
                    {
                        Email = "tbcitacademy@gmail.com",
                        Name = "TBC IT Academy",
                        Url = new Uri("https://www.tbcacademy.ge/")
                    }
                });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTokenAuthentication(Configuration);
            services.Configure<JWTConfiguration>(Configuration.GetSection(nameof(JWTConfiguration)));
            services.AddServices();
            services.RegisterMaps();
            //services.AddScoped<IMovieRepository, MovieRepository>();
            //services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IJwtService, JwtService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1.0.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
