using Core.Constants;
using Core.Helpers;
using Core.Interfaces.IMobileServices;
using Core.Models.MobileModels.Application;
using Core.Models.MobileModels.Regester;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApplicationController : ApiControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("Apply")]
        public async Task<IActionResult> Apply([FromQuery] string VacancyId)
        {

            var response = await _applicationService.Apply(Guid.Parse(VacancyId));
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpGet("GetApplicant")]
        public async Task<IActionResult> GetApplicant([FromQuery] string VacancyId)
        {

            var response = await _applicationService.GetApplications(Guid.Parse(VacancyId));
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }
    }
}
