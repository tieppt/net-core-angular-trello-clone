using Microsoft.AspNetCore.Identity;

namespace TrolloAPI.Identity
{
    public class UserRole : IdentityRole
    {
        internal UserRole() { /* Required by EF */ }
        public UserRole(string role) : base(role)
        {}
    }
}