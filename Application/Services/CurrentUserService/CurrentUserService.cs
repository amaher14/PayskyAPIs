using Core.Enums;
using Core.Interfaces.IMobileServices.ICurrentUserService;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.CurrentUserService;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
  

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        
    }
    public Guid CurrentUserId => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "UserId") == default ? new Guid() : new Guid(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
    public UserType UserRole => (UserType)Enum.Parse(typeof(UserType), _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "Role").Value);

}
