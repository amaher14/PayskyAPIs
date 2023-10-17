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
    public class EmployerRegesterService : IEmployerRegesterService
    {
        private readonly IBaseRepository<Users> _userRepository;
        private readonly IBaseRepository<Employer> _employerRepository;
        private readonly IResourceHandler _resourceHandler;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        private readonly IServiceSaveResponse<EmployerRegesterDTO> _regesterSaveResponse;

        public EmployerRegesterService(IBaseRepository<Users> userRepository, IBaseRepository<Employer> employerRepository, IResourceHandler resourceHandler, IMapper mapper, IUnitOfWork uOW, IServiceSaveResponse<EmployerRegesterDTO> regesterSaveResponse)
        {
            _userRepository = userRepository;
            _employerRepository = employerRepository;
            _resourceHandler = resourceHandler;
            _mapper = mapper;
            _UOW = uOW;
            _regesterSaveResponse = regesterSaveResponse;
        }

        public async Task<IServiceSaveResponse<EmployerRegesterDTO>> EmployerRegester(EmployerRegesterModel model)
        {
            var user = new Users().init(model.phoneNumber, model.FullName, model.UserName, model.Passowrd);
            user.UserType = UserType.Employer;
            var savedUser = await _userRepository.Add(user);
            await _UOW.CommitAsync();
            var employer = new Employer().init(model.JobTitle,model.Departmet, savedUser.Id);
            await _employerRepository.Add(employer);
            await _UOW.CommitAsync();
            var userInfo = _mapper.Map<EmployerRegesterDTO>(savedUser);

            return _regesterSaveResponse.CreateResponse(userInfo, true, string.Empty);
        }
    }
}
