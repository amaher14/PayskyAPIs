
using FluentValidation.AspNetCore;
using Core.Constants;
using Core.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.ConfigurationServices
{
    public static class ConfigureServices
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                    var res = new List<ErrorResponseObject>()
                    {
                      new ErrorResponseObject
                     {
                        Code = ValidationErrorCodes.Mandatory,
                        Message = errors?.Select(x => x.ErrorMessage).FirstOrDefault()
                      }
                    };
                  return new BadRequestObjectResult(new EndpointResult( res));
                  
                };
            }).AddFluentValidation(options =>
            {
                // Validate child properties and root collection elements
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                // Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                options.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("AR");
            });

            return services;
            }
    }
}
