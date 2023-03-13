using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_GAME_APPLICATION.Data;
using CRUD_GAME_APPLICATION.Services;

namespace CRUD_GAME_APPLICATION
{
    public class Startup
    {
        private static readonly string corsP="corsP";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GamesContext>();

            services.AddScoped<IDevelopersGames_DevelopersRepository, DevelopersGames_DevelopersRepository>();
            services.AddScoped<IGamesGames_developersRepository, GamesGames_developersRepository>();
            services.AddScoped<IGamesGames_platformsRepository, GamesGames_platformsRepository>();
            services.AddScoped<IGamesUsersRepository, GamesUsersRepository>();
            services.AddScoped<IPlatformsGames_PlatformsRepository, PlatformsGames_PlatformsRepository>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD_GAME_APPLICATION", Version = "v1" });
            });

            services.AddCors(options => options.AddPolicy(corsP, policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(corsP);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD_GAME_APPLICATION v1"));
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
