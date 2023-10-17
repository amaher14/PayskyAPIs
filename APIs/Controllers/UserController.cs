using Core.Constants;
using Core.Helpers;
using Core.Interfaces.IMobileServices;
using Core.Models.MobileModels.Login;
using APIs.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jizan.Voting.WebAPIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ApiControllerBase
{
    private readonly IMobileUserService _mobileUserService;

    public  UserController(IMobileUserService mobileUserService)
{
        _mobileUserService = mobileUserService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] MobileLoginModel model)
    {

        var response = await _mobileUserService.Login(model);
        if (!response.Success) 
           return BadRequestResult(response.Success, 
               new List<ErrorResponseObject>() { new ErrorResponseObject { Code = ValidationErrorCodes.NotExisting, Message = response.Message } });
        return OkResult(response);
    }
}
