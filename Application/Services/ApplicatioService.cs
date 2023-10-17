using AutoMapper;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.IMobileServices;
using Core.Interfaces.IMobileServices.ICurrentUserService;
using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Application;
using Core.Models.MobileModels.Regester;
using Core.Models.MobileModels.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Services
{
    public class ApplicatioService : IApplicationService
    {
        private readonly IBaseRepository<Applicant> _applicantRepository;
        private readonly IBaseRepository<Core.Entities.Application> _ApplicationRepository;
        private readonly IBaseRepository<Vacancy> _VacancyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IResourceHandler _resourceHandler;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        private readonly IServiceSaveResponse<bool> _ApplyResponse;
        private readonly IServiceSaveResponse<List<ApplicationDTO>> _GetApplicantResponse;

        public ApplicatioService(IBaseRepository<Applicant> applicantRepository, IBaseRepository<Core.Entities.Application> applicationRepository, IBaseRepository<Vacancy> vacancyRepository, ICurrentUserService currentUserService, IResourceHandler resourceHandler, IMapper mapper, IUnitOfWork uOW, IServiceSaveResponse<bool> applyResponse, IServiceSaveResponse<List<ApplicationDTO>> getApplicantResponse)
        {
            _applicantRepository = applicantRepository;
            _ApplicationRepository = applicationRepository;
            _VacancyRepository = vacancyRepository;
            _currentUserService = currentUserService;
            _resourceHandler = resourceHandler;
            _mapper = mapper;
            _UOW = uOW;
            _ApplyResponse = applyResponse;
            _GetApplicantResponse = getApplicantResponse;
        }

        public async Task<IServiceSaveResponse<bool>> Apply(Guid vacancyId)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Applicant)
            {
                return _ApplyResponse.CreateResponse(false, true, "This Function Valid Only For Applicant");
            }
            var applicant = _applicantRepository.GetBy(_ => _.UserId == _currentUserService.CurrentUserId).Result.FirstOrDefault();
            if(checkApplicationsCount(vacancyId))
                return _ApplyResponse.CreateResponse(false, true, "This Vacancy Reached The Max Applications");

            var remainingTime =await checkLastApplicationTime(applicant.Id);
            if (remainingTime.TotalHours < 24)
            {
                return _ApplyResponse.CreateResponse(false, true, "You Can Apply Only One Applicantion During 24 Hours Please try again in "+Convert.ToString(TimeSpan.FromHours(24)-remainingTime)+" Hours");
            }
            var application = new Core.Entities.Application().init(vacancyId, Core.Enums.ApplicationStatus.Active, applicant.Id);
            var addedapplication = await _ApplicationRepository.Add(application);
            var saved =await _UOW.CommitAsync();
            if (saved > 0)
            {
                return _ApplyResponse.CreateResponse(true, true, "Application Sent Successfully");
            }
            else return _ApplyResponse.CreateResponse(true, true, "Please Try later");
        }

        public async Task<IServiceSaveResponse<List<ApplicationDTO>>> GetApplications(Guid VacancyId)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _GetApplicantResponse.CreateResponse(new List<ApplicationDTO>(), true, "This Function Valid Only For Employee");
            }
            var includes = new string[] { "Applicant", "Applicant.Users"};
            var applicant =await _ApplicationRepository.GetBy(_=>_.VacancyId==VacancyId,includes);
            var LApplicants = _mapper.Map<List<ApplicationDTO>>(applicant);


            return _GetApplicantResponse.CreateResponse(LApplicants, true, "");
        }

        private async Task<TimeSpan> checkLastApplicationTime(Guid ApplicantId)
        {
            var UserApplicatios = await _ApplicationRepository.GetBy(_ => _.ApplicantId == ApplicantId);
            var lastApplication =UserApplicatios.OrderByDescending(_=>_.CreatedBy).FirstOrDefault();
            if (lastApplication != null)
            {
                return (DateTime.Now - lastApplication.CreatedAt);
            }
            else return TimeSpan.FromHours(24);
        }

        private bool checkApplicationsCount(Guid VacancyId)
        {
            var Vacancy =  _VacancyRepository.GetByIdAsync(VacancyId).Result;
            var applications =  _ApplicationRepository.GetBy(_ => _.VacancyId == VacancyId).Result;
            if (Vacancy.MaxApplications <= applications.Count())
                return true;
            else return false;
        }
    }
}
