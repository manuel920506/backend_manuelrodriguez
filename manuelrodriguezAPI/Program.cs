
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace manuelrodriguezAPI { 
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program));

            var allowedSiteFrontend = builder.Configuration.GetValue<string>("AllowedSiteFrontend")!;
            var allowedSiteBackend = builder.Configuration.GetValue<string>("AllowedSiteBackend")!;

            //only for browsers
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy => {
                    policy.WithOrigins(allowedSiteFrontend, allowedSiteBackend)
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                    });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 39))
                )
             );

            builder.Services.AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // or any other configuration you need
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // To handle circular references
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IExperiencesSvc, ExperiencesSvc>();
            builder.Services.AddScoped<ILearningExperiences, LearningExperiences>();

            // builder.Services.AddAuthentication(/* ... */);
            // builder.Services.AddAuthorization();

          
            var app = builder.Build();

            app.UseCors(); 

            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapControllers();
            app.Run();

        }
    }
}
