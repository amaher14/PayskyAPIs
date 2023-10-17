using AutoMapper;
using Core.Common;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.IMobileServices;
using Core.Interfaces.ISecurityService;
using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Login;
using Core.Models.MobileModels.Regester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicantRegesterService : IapplicantRegesterService
    {
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Applicant> _ApplicantRepository;
        private readonly IResourceHandler _resourceHandler;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        private readonly IServiceSaveResponse<ApplicantRegesterDTO> _loginSaveResponse;

        public ApplicantRegesterService(IBaseRepository<Users> userRepository, IBaseRepository<Applicant> applicantRepository, IResourceHandler resourceHandler, IMapper mapper, IUnitOfWork uOW, IServiceSaveResponse<ApplicantRegesterDTO> loginSaveResponse)
        {
            _userRepository = userRepository;
            _ApplicantRepository = applicantRepository;
            _resourceHandler = resourceHandler;
            _mapper = mapper;
            _UOW = uOW;
            _loginSaveResponse = loginSaveResponse;
        }

        public async Task<IServiceSaveResponse<ApplicantRegesterDTO>> ApplicantRegester(ApplicantRegesterModel model)
        {
            var user = new Users().init(model.phoneNumber,model.FullName,model.UserName,model.Passowrd);
            user.UserType = UserType.Applicant;
            var savedUser =await _userRepository.Add(user);
           await _UOW.CommitAsync();
            var applicant = new Applicant().init(model.Email, savedUser.Id);
            await _ApplicantRepository.Add(applicant);
            await _UOW.CommitAsync();
            var userInfo = _mapper.Map<ApplicantRegesterDTO>(savedUser);

            return _loginSaveResponse.CreateResponse(userInfo, true, string.Empty);

        }
    }
}
