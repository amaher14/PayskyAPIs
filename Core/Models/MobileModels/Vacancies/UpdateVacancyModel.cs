using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.MobileModels.Vacancies
{
    public class UpdateVacancyModel
    {
        public Guid VacancyId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int MaxApplications { get; set; }
        public DateTime ExpireDate { get; set; }
        public Status Status { get; set; }

    }
}
