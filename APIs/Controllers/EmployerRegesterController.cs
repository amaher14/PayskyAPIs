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
    public class EmployerRegesterController : ApiControllerBase
    {
        private readonly IEmployerRegesterService _applicantRegesterService;

        public EmployerRegesterController(IEmployerRegesterService applicantRegesterService)
        {
            _applicantRegesterService = applicantRegesterService;
        }

        [HttpPost("EmployerRegester")]
        [AllowAnonymous]
        public async Task<IActionResult> Regester([FromBody] EmployerRegesterModel model)
        {

            var response = await _applicantRegesterService.EmployerRegester(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }
    }
}
