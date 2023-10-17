using Core.Interfaces.Resposnes;
using Core.Models.MobileModels.Login;
using Core.Models.MobileModels.Regester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IMobileServices
{
    public interface IapplicantRegesterService
    {
        public Task<IServiceSaveResponse<ApplicantRegesterDTO>> ApplicantRegester(ApplicantRegesterModel model);

    }
}
