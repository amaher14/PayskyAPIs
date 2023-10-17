using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Applicant : AuditableEntity<Guid>
    {
        #region Properties

        public string Email { get; set; }
        public Guid UserId { get; set; }

        #endregion
        #region Navigations
        public Users Users { get; set; }
        #endregion

        public Applicant init(string email,Guid userId)
        {
            Applicant applicant = new Applicant();
            applicant.Email = email;
            applicant.UserId = userId;
            return applicant;
        }
    }
}
