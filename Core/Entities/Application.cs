using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Application : AuditableEntity<Guid>
    {

        #region Properties
        public Guid VacancyId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public Guid ApplicantId { get; set; }


        #endregion
        #region Navigations
        public Vacancy Vacancy { get; set; }
        public Applicant Applicant { get; set; }
        #endregion

        public Application init(Guid vacancyId,ApplicationStatus ApplicationStatus,Guid applicantID)
        {
            var Application = new Application();
            Application.VacancyId = vacancyId;  
            Application.ApplicationStatus = ApplicationStatus;
            Application.CreatedAt = DateTime.Now;
            Application.ApplicantId= applicantID;
            return Application;

        }
    }

}