using Core.Enums;

namespace Core.Entities
{
    public class Vacancy : AuditableEntity<Guid>
    {

        #region Properties
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int MaxApplications { get; set; }
        public DateTime ExpireDate { get; set; }
        public Status Status { get; set; }
        public Guid EmployerId { get; set; }



        #endregion
        #region Navigations
        public List<Application> Applications { get; set; }
        #endregion

        public Vacancy Init(string jobTitle,string description,int maxApplications,DateTime ExpireDate,Status status)
        {
            Vacancy vacancy = new Vacancy();
            vacancy.JobTitle = jobTitle;
            vacancy.Description = description;
            vacancy.MaxApplications = maxApplications;
            vacancy.ExpireDate = ExpireDate;
            vacancy.Status = status;
            return vacancy;
        }

        public Vacancy Update(Vacancy vacancy,Guid Id, string jobTitle, string description, int maxApplications, DateTime ExpireDate, Status status)
        {
            vacancy.Id = Id;
            vacancy.JobTitle = jobTitle;
            vacancy.Description = description;
            vacancy.MaxApplications = maxApplications;
            vacancy.ExpireDate = ExpireDate;
            vacancy.Status = status;
            return vacancy;
        }
    }
}
