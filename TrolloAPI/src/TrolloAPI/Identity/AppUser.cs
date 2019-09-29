using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TrolloAPI.Identity
{
    public class AppUser : IdentityUser
    {
        [MaxLength(32)]
        public string FirstName { get; private set; } // EF migrations require at least private setter - won't work on auto-property
        [MaxLength(32)]
        public string LastName { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        internal AppUser() { /* Required by EF */ }

        internal AppUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}