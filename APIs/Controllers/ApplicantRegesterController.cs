using Core.Constants;
using Core.Helpers;
using Core.Interfaces.IMobileServices;
using Core.Models.MobileModels.Login;
using Core.Models.MobileModels.Regester;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantRegesterController : ApiControllerBase
    {
        private readonly IapplicantRegesterService _applicantRegesterService;

        public ApplicantRegesterController(IapplicantRegesterService applicantRegesterService)
        {
            _applicantRegesterService = applicantRegesterService;
        }

        [HttpPost("ApplicantRegester")]
        [AllowAnonymous]
        public async Task<IActionResult> Regester([FromBody] ApplicantRegesterModel model)
        {

            var response = await _applicantRegesterService.ApplicantRegester(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }
    }
}
