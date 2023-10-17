using System.Text.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Core.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Application.ConfigurationServices
{
    public  class CustomFluentValidation : IValidatorInterceptor
    {
      
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext,
            ValidationResult result)
        {
            var failures = result.Errors
                .Select(error => new ValidationFailure(error.PropertyName, SerializeError(error)));

            return new ValidationResult(failures);
        }

        private static string SerializeError(ValidationFailure failure)
        {
            var error = new FluentValidationError.Error(failure.ErrorCode, failure.ErrorMessage);
            return JsonSerializer.Serialize(error);
        }
    
     
    }
}
