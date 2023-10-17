namespace Core.Entities
{
    public class Employer : AuditableEntity<Guid>
    {

        #region Properties
        public string JobTitle { get; set; }
        public string Department { get; set; }
       
        public Guid UserId { get; set; }

        #endregion
        #region Navigations
        public Users Users { get; set; }
        #endregion

        public Employer init(string jobTitle,string department,Guid userid)
        {
            Employer employer = new Employer(); 
            employer.JobTitle = jobTitle;
            employer.UserId = userid;
            employer.Department = department;
            return employer;
        }
    }
}
