using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.MobileModels.Application
{
    public class ApplyApplicationModel
    {
        public Guid VacancyId { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
