using AutoMapper;
using Core.Common;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Interfaces.IMobileServices;
using Core.Interfaces.IMobileServices.ICurrentUserService;
using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Regester;
using Core.Models.MobileModels.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IBaseRepository<Vacancy> _VacancyRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UOW;
        private readonly IServiceSaveResponse<bool> _VacancyResponse;
        private readonly IServiceSaveResponse<List<GetVacancyDTO>> _LVacancyResponse;

        public VacancyService(IBaseRepository<Vacancy> vacancyRepository, ICurrentUserService currentUserService, IMapper mapper, IUnitOfWork uOW, IServiceSaveResponse<bool> vacancyResponse, IServiceSaveResponse<List<GetVacancyDTO>> lVacancyResponse)
        {
            _VacancyRepository = vacancyRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _UOW = uOW;
            _VacancyResponse = vacancyResponse;
            _LVacancyResponse = lVacancyResponse;
        }

        public async Task<IServiceSaveResponse<bool>> activateVacancy(UpdateVacancyStatusModel model)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _VacancyResponse.CreateResponse(false, true, "This Function Valid Only For Employee");
            }
            var vacancy = await _VacancyRepository.GetByIdAsync(model.VacancyId);
            vacancy.Status = Status.Active;
            _VacancyRepository.Update(vacancy);
            var update = await _UOW.CommitAsync();
            if (update > 0)
            {
                return _VacancyResponse.CreateResponse(true, true, "Vacancy Updated");
            }
            else return _VacancyResponse.CreateResponse(true, true, "Please Try later");

        }

        public async Task<IServiceSaveResponse<bool>> createVacancy(CreateVacacyModel model)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _VacancyResponse.CreateResponse(false, true, "This Function Valid Only For Employee");
            }
            var NewVacacy = new Vacancy().Init( model.JobTitle, model.Description, model.MaxApplications, model.ExpireDate,Status.Active);
            NewVacacy.EmployerId = _currentUserService.CurrentUserId;
            var addedVacancy =_VacancyRepository.Add(NewVacacy);
            var update = await _UOW.CommitAsync();
            if (update > 0)
            {
                return _VacancyResponse.CreateResponse(true, true, "Vacancy Added with ID "+addedVacancy.Id);
            }
            else return _VacancyResponse.CreateResponse(true, true, "Please Try later");
        }

        public async Task<IServiceSaveResponse<bool>> deactivateVacancy(UpdateVacancyStatusModel model)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _VacancyResponse.CreateResponse(false, true, "This Function Valid Only For Employee");
            }
            var vacancy = await _VacancyRepository.GetByIdAsync(model.VacancyId);
            vacancy.Status = Status.Holded;
            _VacancyRepository.Update(vacancy);
            var update = await _UOW.CommitAsync();
            if (update > 0)
            {
                return _VacancyResponse.CreateResponse(true, true, "Vacancy DeActivated with id"+model.VacancyId);
            }
            else return _VacancyResponse.CreateResponse(true, true, "Please Try later");
        }

        public async Task<IServiceSaveResponse<bool>> DeleteVacancy(Guid VacancyId)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _VacancyResponse.CreateResponse(false, true, "This Function Valid Only For Employee");
            }
            var vacancy = await _VacancyRepository.GetByIdAsync(VacancyId);
            vacancy.Status = Status.removed;
            vacancy.IsDeleted = true;
            _VacancyRepository.Update(vacancy);
            var update = await _UOW.CommitAsync();
            if (update > 0)
            {
                return _VacancyResponse.CreateResponse(true, true, "Vacancy Deleted with id" + VacancyId);
            }
            else return _VacancyResponse.CreateResponse(true, true, "Please Try later");
        }

        public async Task<IServiceSaveResponse<List<GetVacancyDTO>>> GetVacancies(string jobtitle, string description)
        {        
            var vacancies =await listSearch(jobtitle, description);
            
            var Lvacancies = _mapper.Map<List<GetVacancyDTO>>(vacancies);

            return _LVacancyResponse.CreateResponse(Lvacancies, true, "");
        }

        public async Task<IServiceSaveResponse<bool>> UpdateVacancy(UpdateVacancyModel model)
        {
            if (_currentUserService.UserRole != Core.Enums.UserType.Employer)
            {
                return _VacancyResponse.CreateResponse(false, true, "This Function Valid Only For Employee");
            }
            var vacancy = await _VacancyRepository.GetByIdAsync(model.VacancyId);
            var updatedVacacy = new Vacancy().Update(vacancy,model.VacancyId, model.JobTitle, model.Description, model.MaxApplications, model.ExpireDate, model.Status);
            _VacancyRepository.Update(updatedVacacy);
            var update = await _UOW.CommitAsync();
            if (update > 0)
            {
                return _VacancyResponse.CreateResponse(true, true, "Vacancy Updated");
            }
            else return _VacancyResponse.CreateResponse(true, true, "Please Try later");
        }

        private async Task<List<Vacancy>> listSearch(string jobtitle, string description)
        {
            var Lvacancies = new List<Vacancy>();
            if (!string.IsNullOrEmpty(jobtitle) && !string.IsNullOrEmpty(description))
            {
                var vacancies =await _VacancyRepository.GetBy(_ => _.Status == Status.Active&&_.IsDeleted==false&&_.Description.Contains(description)&&_.JobTitle.Contains(jobtitle));
            Lvacancies=vacancies.ToList();
            }
            else if (!string.IsNullOrEmpty(jobtitle))
            {
                var vacancies = await _VacancyRepository.GetBy(_ => _.Status == Status.Active && _.IsDeleted == false &&_.JobTitle.Contains(jobtitle));
                Lvacancies=vacancies.ToList();
            }
            else if (!string.IsNullOrEmpty(description))
            {
                var vacancies = await _VacancyRepository.GetBy(_ => _.Status == Status.Active && _.IsDeleted == false && _.Description.Contains(description));
                Lvacancies = vacancies.ToList();
            }
            else
            {
                var vacancies = await _VacancyRepository.GetBy(_ => _.Status == Status.Active && _.IsDeleted == false );
                Lvacancies=vacancies.ToList();
            }


            return Lvacancies;
        }
    }
}
