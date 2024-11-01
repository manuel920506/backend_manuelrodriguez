
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Interfaces;
using Services;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace manuelrodriguezAPI { 
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddOutputCache(options => {
                options.DefaultExpirationTimeSpan = TimeSpan.FromDays(1);
            });

            var allowedSiteFrontend = builder.Configuration.GetValue<string>("AllowedSiteFrontend")!;
            var allowedSiteBackend = builder.Configuration.GetValue<string>("AllowedSiteBackend")!;
            var allowedSiteBackendRun = builder.Configuration.GetValue<string>("AllowedSiteBackendRun")!;

            //only for browsers
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy => {
                    policy.WithOrigins(allowedSiteFrontend, allowedSiteBackend, allowedSiteBackendRun)
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                    });
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); 

            builder.Services.AddAuthentication().AddJwtBearer(options => {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),
                    ClockSkew = TimeSpan.Zero
                };
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
            builder.Services.AddScoped<IEducationSvc, EducationSvc>();
            builder.Services.AddScoped<IEducation, Education>();
            builder.Services.AddScoped<ISkillSvc, SkillSvc>();
            builder.Services.AddScoped<ISkill, Skill>();
            builder.Services.AddScoped<ICommonDataSvc, CommonDataSvc>();
            builder.Services.AddScoped<ICommonData, CommonData>();

            // builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseCors(); 

            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseOutputCache();

            // app.UseAuthorization();

            app.MapControllers();
            app.Run(allowedSiteBackendRun);

        }
    }
}
