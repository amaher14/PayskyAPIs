using Core.Enums;
using Core.Models.MobileModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.MobileModels.Application
{
    public class ApplicationDTO
    {
        public Guid VacancyId { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantPhoneNumber { get; set; }
    }
}
