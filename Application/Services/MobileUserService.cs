using AutoMapper;
using Core.Common;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.IMobileServices;
using Core.Interfaces.ISecurityService;
using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Login;
using Core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Application.Services
{

    public  class MobileUserService : IMobileUserService
      {
        private readonly TokenSetting _tokenSetting;
        private readonly IBaseRepository<Users> _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IResourceHandler _resourceHandler;
        private readonly IServiceSaveResponse<MobileLoginResponseDto> _loginSaveResponse;
        private readonly IMapper _mapper;

        public  MobileUserService(IOptions<TokenSetting> tokenSetting,
            IBaseRepository<Users> userRepository,
            ISecurityService securityService,
            IMapper mapper, 
            IResourceHandler resourceHandler, IServiceSaveResponse<MobileLoginResponseDto> loginSaveResponse

            )

        {

            _tokenSetting = tokenSetting.Value;
            _userRepository = userRepository;
            _securityService = securityService;
            _mapper = mapper;
            _resourceHandler = resourceHandler;
            _loginSaveResponse = loginSaveResponse;
        }

        public async Task<IServiceSaveResponse<MobileLoginResponseDto>> Login(MobileLoginModel model)
        {
            var user = await Getuser(model.UserName,model.Passowrd);

            if (user is not null || user != default)
            {
                var userInfo = _mapper.Map<UserDTO>(user);
                userInfo.TokenExpInMin = _tokenSetting.TokenExpiredInMin;
                userInfo.AuthenticationToken = await GenerateToken(userInfo);
                var randomCode = await GenerateRandomCode();
                var loginResponse = new MobileLoginResponseDto(userInfo, randomCode);
                return _loginSaveResponse.CreateResponse(loginResponse,true, string.Empty);
            }
            
            return _loginSaveResponse.CreateResponse(null, false, _resourceHandler.GetError("NotWorkingNationalId")); 
        }

        #region Helper

        private async Task<Users> Getuser (string userName,string password)
        {
            return  (await _userRepository.GetBy(x => x.UserName == userName&&x.Passowrd==password)).FirstOrDefault();
           
        }
        private async Task<string> GenerateToken(UserDTO user)
         {           
            List<int?> permissions = new List<int?>();
            var claims = await SetUserClaims(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key ?? string.Empty));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var expTime = DateTime.Now.AddMinutes(_tokenSetting.TokenExpiredInMin);
            var tokenData = new JwtSecurityToken(_tokenSetting.Issuer ?? string.Empty, _tokenSetting.Audience ?? string.Empty, claims, expires: expTime, signingCredentials: signIn);
            var accessToken = tokenHandler.WriteToken(tokenData);
            var encryptedToken = _securityService.EncryptPlainText(accessToken);
            return encryptedToken;
        }

        private async Task<Claim[]> SetUserClaims(UserDTO user)
        {
                 List<Claim> claims = new List<Claim>{
                    new Claim(JwtRegisteredClaimNames.Sub, _tokenSetting.Subject ?? string.Empty),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(_tokenSetting.TokenExpiredInMin).ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Name", user.Name ?? string.Empty),
                    new Claim("Role", user.userType ?? string.Empty),
                    new Claim("Email", user.Email?? string.Empty),
                    new Claim("JwtExpiredDate",DateTime.Now.AddMinutes(_tokenSetting.TokenExpiredInMin).ToString())
                   };
            return claims.ToArray();
        }

        private async Task<int> GenerateRandomCode()
        {
                Random rnd = new Random();
                int firstDigit = rnd.Next(1, 10);
                int randomNumber = rnd.Next(1, 9);
                int RandomOTPNumber = int.Parse(firstDigit.ToString() + randomNumber.ToString());
                return RandomOTPNumber;
        }
    
        #endregion
    }
}
