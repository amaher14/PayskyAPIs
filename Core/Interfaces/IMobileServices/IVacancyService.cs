using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Regester;
using Core.Models.MobileModels.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IMobileServices
{
    public interface IVacancyService
    {
        public Task<IServiceSaveResponse<List<GetVacancyDTO>>> GetVacancies(string jobtitle,string description);
        public Task<IServiceSaveResponse<bool>> createVacancy(CreateVacacyModel model);
        public Task<IServiceSaveResponse<bool>> UpdateVacancy(UpdateVacancyModel model);
        public Task<IServiceSaveResponse<bool>> activateVacancy(UpdateVacancyStatusModel model);
        public Task<IServiceSaveResponse<bool>> deactivateVacancy(UpdateVacancyStatusModel model);
        public Task<IServiceSaveResponse<bool>> DeleteVacancy(Guid VacancyId);

    }
}
