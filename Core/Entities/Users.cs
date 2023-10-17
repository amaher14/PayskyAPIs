using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Users : AuditableEntity<Guid>
    {
        #region Properties

        public string PhoneNumber { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Passowrd { get; set; }
        public UserType UserType { get; set; }
        #endregion

        public Users init(string phoneNumber, string fullName, string userName, string passowrd)
        {
            var user = new Users();
            user.PhoneNumber = phoneNumber;
            user.FullName = fullName;
            user.UserName = userName;
            user.Passowrd = passowrd;
            return user;
        }

    }
}
