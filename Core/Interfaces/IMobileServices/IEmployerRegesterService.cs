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
    public interface IEmployerRegesterService
    {
        public Task<IServiceSaveResponse<EmployerRegesterDTO>> EmployerRegester(EmployerRegesterModel model);

    }
}
