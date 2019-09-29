using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Trollo.Identity.Identity
{
    public class AppUser : IdentityUser<string>
    {
        [MaxLength(32)]
        public string
            FirstName
        {
            get;
            private set;
        } // EF migrations require at least private setter - won't work on auto-property

        [MaxLength(32)] public string LastName { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}