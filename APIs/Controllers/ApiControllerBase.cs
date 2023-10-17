using Core.Helpers;
using Microsoft.AspNetCore.Mvc;



namespace APIs.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
     
     protected DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;
            return serverTime;
        }
    #region Http Results

    protected IActionResult OkResult(dynamic data, int? totalCount = null) => Ok(new EndpointResult(true, data: data, totalCount: totalCount));

    protected IActionResult OkResult(string message, dynamic data, int? totalCount = null) => Ok(new EndpointResult(true, data: data, totalCount: totalCount, message: message));

    protected IActionResult OkResult(string message, dynamic data) => Ok(new EndpointResult(true, data: data, message: message));

    protected IActionResult NotFoundResult(string message) => NotFound(new EndpointResult(false, message: message));

    protected IActionResult BadRequestResult(string message) => BadRequest(new EndpointResult(false, message: message));

    protected IActionResult UnauthorizedResult(string message) => Unauthorized(new EndpointResult(false, message: message));
    protected IActionResult BadRequestResult(string message, dynamic data, List<ErrorResponseObject> Errors = null) => Ok(new EndpointResult(false, data: data, errors: Errors, message: message));

    protected IActionResult BadRequestResult(bool success, List<ErrorResponseObject> Errors = null) => Ok(new EndpointResult(false, errors: Errors));

    #endregion
}
