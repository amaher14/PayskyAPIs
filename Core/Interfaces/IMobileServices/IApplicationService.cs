using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IMobileServices
{
    public interface IApplicationService
    {
        public Task<IServiceSaveResponse<bool>> Apply(Guid vacancyId);
        public Task<IServiceSaveResponse<List<ApplicationDTO>>> GetApplications(Guid VacancyId);

    }
}
