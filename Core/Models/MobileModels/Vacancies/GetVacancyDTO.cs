using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.MobileModels.Vacancies
{
    public class GetVacancyDTO
    {
        public Guid VacancyId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
