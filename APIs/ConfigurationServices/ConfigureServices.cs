using Core.Common;
using Core.Common.Helper;
using Core.Interfaces;
using Core.Interfaces.IMobileServices;
using Core.Interfaces.IMobileServices.ICurrentUserService;
using Core.Interfaces.ISecurityService;
using Core.Interfaces.Resposnes;
using Core.Settings;
using Infastructure;
using Infastructure.Data.Context;
using Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;
using Application.Common.AutoMapper;
using Application.Services;
using Application.Common.SecurityService;
using Application.Services.CurrentUserService;

namespace Jizan.Voting.APIs.ConfigurationServices;
public static class ConfigureServices
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PaySkyDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly(typeof(PaySkyDbContext).Assembly.FullName))); 
        services.AddMemoryCache();
        ConfigureAuthentication(services, configuration);
        services.AddHttpContextAccessor();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        AddSwaggerDocumentation(services);
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        ConfigureSettings(services, configuration);
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IServiceSaveResponse<>), typeof(ServiceSaveResponse<>));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IResourceHandler, ResourceHandler>();
        services.AddScoped<IapplicantRegesterService, ApplicantRegesterService>();
        services.AddScoped<IEmployerRegesterService, EmployerRegesterService>();
        services.AddScoped<IVacancyService, VacancyService>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<IMobileUserService, MobileUserService>();
        services.AddScoped<IApplicationService, ApplicatioService>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
                builder.SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

        return services;
    }
    
    static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
    {
        CultureInfo[] supportedCultures = new[]
           {
            new CultureInfo("ar-EG"),

        };
        services.Configure<TokenSetting>(configuration.GetSection("TokenSetting"));
        services.Configure<AppSetting>(configuration.GetSection("AppSetting"));

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("ar-EG");
            options.SupportedCultures = supportedCultures;

            options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };

        });
      

    }

    
    static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["TokenSetting:Issuer"],
            ValidAudience = configuration["TokenSetting:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSetting:Key"]))
        };

    });


    }
    static void AddSwaggerDocumentation(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            //This is to generate the Default UI of Swagger Documentation  
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Paysky.APIs",
                Description = "PaySky.APIs"

            });
            // To Enable authorization using Swagger (JWT)  
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    },

                });

        });
    }

}








