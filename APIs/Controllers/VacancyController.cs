using Core.Constants;
using Core.Helpers;
using Core.Interfaces.IMobileServices;
using Core.Models.MobileModels.Login;
using Core.Models.MobileModels.Regester;
using Core.Models.MobileModels.Vacancies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VacancyController : ApiControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpPost("CreateVacacy")]
        public async Task<IActionResult> CreateVacacy([FromBody] CreateVacacyModel model)
        {

            var response = await _vacancyService.createVacancy(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpPost("ActivateVacancy")]
        public async Task<IActionResult> ActivateVacancy([FromBody] UpdateVacancyStatusModel model)
        {

            var response = await _vacancyService.activateVacancy(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpPost("DeactivateVacancy")]
        public async Task<IActionResult> DeactivateVacancy([FromBody] UpdateVacancyStatusModel model)
        {

            var response = await _vacancyService.deactivateVacancy(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpPost("UpdateVacancy")]
        public async Task<IActionResult> UpdateVacancy([FromBody] UpdateVacancyModel model)
        {

            var response = await _vacancyService.UpdateVacancy(model);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }
        [HttpDelete("DeleteVacancy")]
        public async Task<IActionResult> DeleteVacancy([FromBody] string VacancyId)
        {

            var response = await _vacancyService.DeleteVacancy(Guid.Parse(VacancyId));
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpGet("getVacancies")]

        public async Task<IActionResult> getVacancies()
        {

            var response = await _vacancyService.GetVacancies(null,null);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }

        [HttpGet("SearchVacancies")]

        public async Task<IActionResult> SearchVacancies([FromQuery] string? jobTitle, string? description)
        {

            var response = await _vacancyService.GetVacancies(jobTitle, description);
            if (!response.Success)
                return BadRequestResult(response.Success,
                    new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
            return OkResult(response);
        }
    }
}
