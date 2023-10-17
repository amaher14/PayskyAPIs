using Core.Enums;
using Waqfi.Application.Common.Models;

namespace Core.Interfaces.IMobileServices.ICurrentUserService
{

    public interface ICurrentUserService
    {
        Guid CurrentUserId { get; }
        UserType UserRole { get; }



    }
}
