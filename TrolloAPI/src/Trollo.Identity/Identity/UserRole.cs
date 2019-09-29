using Microsoft.AspNetCore.Identity;

namespace Trollo.Identity.Identity
{
    public class UserRole : IdentityRole
    {
        internal UserRole()
        {
            /* Required by EF */
        }

        public UserRole(string role) : base(role)
        {
        }
    }
}