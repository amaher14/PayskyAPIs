using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Login;
using System.Threading.Tasks;

namespace  Core.Interfaces.IMobileServices
{
    public interface IMobileUserService
    {
        Task<IServiceSaveResponse<MobileLoginResponseDto>> Login(MobileLoginModel model);

    }
}
