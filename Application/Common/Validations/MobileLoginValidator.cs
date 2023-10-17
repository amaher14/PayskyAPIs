using FluentValidation;
using Core.Constants;
using Core.Interfaces;
using Core.Models.MobileModels.Login;

namespace Application.Common.Validations
{
    public class MobileLoginValidator : AbstractValidator<MobileLoginModel>
    {

        private readonly IResourceHandler _resourceHandler;
        public MobileLoginValidator(IResourceHandler resourceHandler) 
        {
            _resourceHandler = resourceHandler;

            RuleFor(_ => _.UserName).NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(_resourceHandler.GetError("RequiredUserName"));
            RuleFor(_ => _.Passowrd).NotEmpty().WithErrorCode(ValidationErrorCodes.Mandatory.ToString()).WithMessage(_resourceHandler.GetError("RequiredPassword"));
     
        }
    }

}

