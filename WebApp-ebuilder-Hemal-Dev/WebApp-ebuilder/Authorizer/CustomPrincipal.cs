using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApp_ebuilder.Authorizer
{
    public class CustomPrincipal :IPrincipal
    {
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            string[] roles = role.Split(',');
            foreach (string r in roles)
            {
                if (r == Role)
                {
                    return true;
                }

            }
            return false;            
        }

        public CustomPrincipal(string userId)
        {
            this.Identity = new GenericIdentity(userId);
        }

        public string email { get; set; }
        public string EID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}